using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using OpenCvSharp;
using ST4I.Vision;
using ST4I.Vision.Controls;
using ST4I.Vision.Core;
using ST4I.Vision.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;



namespace FinalDLTools
{
    class MainWindowContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Mat image;
        private ImageBoxContext imageBoxView;
        private ObservableCollection<ImageModel> listImage = new ObservableCollection<ImageModel>();
        private ObservableCollection<LabelModel> listLabelClass = new ObservableCollection<LabelModel>();
        private ObservableCollection<ProjectModel> listProjectCreate = new ObservableCollection<ProjectModel>();
        private ObservableCollection<string> listLabelName = new ObservableCollection<string>();
        private ObservableCollection<string> listLabelColor = new ObservableCollection<string>();
        private int selectedIndex;
        private int selectedLabelIndex;
        public Mat Image
        {
            get { return image; }
            set { image = value; }
        }

        
        public bool IsEnableButonLabel
        {
            get { return ListLabelClass.Count > 0; }
        }
        public bool IsVisibilityListBox
        {
            get { return ListProjectCreate.Count > 0; }
        }

        public ImageBoxContext ImageBoxView
        {
            get
            {
                return imageBoxView;
            }
        }
        public IRoi Roi { get; set; }

        public ObservableCollection<ImageModel> ListImage
        {
            get { return listImage; }
            set { listImage = value; OnPropertyChanged(); }
        }

        public ObservableCollection<LabelModel> ListLabelClass
        {
            get { return listLabelClass; }
            set { listLabelClass = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ProjectModel> ListProjectCreate
        {
            get { return listProjectCreate; }
            set { listProjectCreate = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> ListLabelName
        {
            get { return listLabelName; }
            set { listLabelName = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> ListLabelColor
        {
            get { return listLabelColor; }
            set { listLabelColor = value; OnPropertyChanged(); }
        }

        public int SelectedLabelIndex
        {
            get { return selectedLabelIndex; }
            set { selectedLabelIndex = value; OnPropertyChanged(); }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (ListImage.Count > 0)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    else if ((value >= 0) && (value < ListImage.Count))
                    {
                        selectedIndex = value;
                    }
                    else if (value >= ListImage.Count)
                    {
                        value = ListImage.Count - 1;
                    }

                    //selectedIndex = value;
                    ImageBoxView.ImageBitmap = new BitmapImage(new Uri(ListImage[value].PathFile));
                    Image?.Dispose();
                    Image = Cv2.ImRead(ListImage[value].PathFile, ImreadModes.AnyColor);
                    OnPropertyChanged();
                }

            }
        }

        public int TotalFile
        {
            get { return ListImage.Count; }
        }


        // Add New Project
        public RelayCommand NewProjectCommand { get; set; }
        // Open Project
        public RelayCommand OpenProjectCommand { get; set; }
        // Load Image Command
        public RelayCommand LoadImageCommand { get; set; }
        // Load Folder Image Command
        public RelayCommand LoadFolderImageCommand { get; set; }
        // Remove Image Command
        public RelayCommand RemoveImageCommand { get; set; }
        // Next Image Command
        public RelayCommand NextImageCommand { get; set; }
        // Previous Image Command
        public RelayCommand PreviousImageCommand { get; set; }
        // Add Label Command
        public RelayCommand AddLabelCommand { get; set; }
        // Remove Label Command
        public RelayCommand RemoveLabelCommand { get; set; }
        // Edit Label Command
        public RelayCommand EditLabelCommand { get; set; }


        public MainWindowContext()
        {
            imageBoxView = new ImageBoxContext()
            {
                RotatedRectRegionEnabled = false,
                CircleRegionEnabled = false,
                PolygonRegionEnabled = false,
                AnnulusRegionEnabled = false,
                RectRegionEnabled = true,
                MaxNumRoi = 1
            };
            ImageBoxView.RoiToolboxEnabled = true;
            ImageBoxView.ShowPanelProperties = false;

            ImageBoxView.RoiAdded += OnRoiAdded;
            ImageBoxView.RoiDeleted += OnRoiDeleted;
            ImageBoxView.RoiChanged += OnRoiChanged;
            RemoveLabelCommand = new RelayCommand(OnRemoveLabelCommand);
            EditLabelCommand = new RelayCommand(OnEditLabelCommand);
            OpenProjectCommand = new RelayCommand(OnOpenProjectCommand);
            NewProjectCommand = new RelayCommand(OnNewProjectCommand);
            LoadImageCommand = new RelayCommand(OnLoadImageCommand);
            LoadFolderImageCommand = new RelayCommand(OnLoadFolderImageCommand);
            AddLabelCommand = new RelayCommand(OnAddLabelCommand);
            NextImageCommand = new RelayCommand(OnNextImageCommand);
            PreviousImageCommand = new RelayCommand(OnPreviousImageCommand);
            RemoveImageCommand = new RelayCommand(OnRemoveImageCommand);
        }

        private void OnRoiChanged(object sender, IRoi roi)
        {
            Roi = roi;
            try
            {
                var imageSample = ImageUtils.ExtractImageByRoi(image, Roi);

            }
            catch (Exception err)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(err.ToString());
            }
        }

        private void OnEditLabelCommand(object obj)
        {

        }

        private void OnRemoveLabelCommand(object obj)
        {
            if (SelectedLabelIndex > -1)
            {
                if (Xceed.Wpf.Toolkit.MessageBox.Show("Are you sure you want to delete this label?", "Delete Label", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var index = SelectedLabelIndex;
                    var label = ListLabelClass[index].LabelName;
                    var color = ListLabelClass[index].Color;
                    ListLabelClass.RemoveAt(SelectedLabelIndex);
                    ListLabelName.Remove(label);
                    ListLabelColor.Remove(color);
                    if (index != 0)
                    {
                        SelectedLabelIndex = index - 1;
                    }
                    else
                    {
                        if (ListLabelClass.Count > 0)
                        {
                            SelectedLabelIndex = index;
                        }

                    }
                }
            }
        }

        private void OnRoiDeleted(object sender, IRoi roi)
        {
            Roi = null;
        }

        private void OnRoiAdded(object sender, IRoi roi)
        {
            Roi = roi;
            try
            {
                var imageSample = ImageUtils.ExtractImageByRoi(image, Roi);

            }
            catch (Exception err)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(err.ToString());
            }
        }

        private void OnOpenProjectCommand(object obj)
        {
            // Open Folder Dialog
            VistaFolderBrowserDialog imgFileDialog = new VistaFolderBrowserDialog();
            imgFileDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            imgFileDialog.ShowNewFolderButton = true;
            imgFileDialog.Multiselect = true;
            imgFileDialog.ShowDialog();
        }

        private void OnNewProjectCommand(object obj)
        {
            var frm1 = new NewProjectUI();
            frm1.ShowDialog();
            var add1 = frm1.DataContext as NewProjectContext;
            if (add1.Result != string.Empty && add1.Result != null)
            {
                if (ListProjectCreate.FirstOrDefault(item => item.Name == add1.Result && item.Path == add1.PathSelected) == null)
                {
                    ProjectModel newProjectModel = new ProjectModel();
                    newProjectModel.Name = add1.Result;
                    newProjectModel.Path = add1.PathSelected;
                    newProjectModel.Describe = add1.DescriptionProject;
                    // add method classification, detection, segmentation 
                    if (add1.IsClassification)
                    {
                        newProjectModel.Method = "Classification";
                    }
                    else if (add1.IsDetection)
                    {
                        newProjectModel.Method = "Detection";
                    }
                    else if (add1.IsSegmentation)
                    {
                        newProjectModel.Method = "Segmentation";
                    }
                    ListProjectCreate.Add(newProjectModel);
                    OnPropertyChanged("IsVisibilityListBox");
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Project Name already exists", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void OnRemoveImageCommand(object obj)
        {

            System.Collections.IList items = (System.Collections.IList)obj;
            var collection = items.Cast<ImageModel>();
            List<int> lstIndex = new List<int>();
            foreach (var item in collection)
            {
                lstIndex.Add(ListImage.IndexOf(item));
            }
            foreach (var idx in lstIndex)
            {
                if (idx != 0)
                {
                    SelectedIndex = idx - 1;
                }
                else
                {
                    if (ListImage.Count > 0)
                    {
                        SelectedIndex = idx + 1;
                    }
                    else { SelectedIndex = 0; }
                }
                ListImage.RemoveAt(idx);
                
                OnPropertyChanged("SelectedIndex");
                OnPropertyChanged("TotalFile");

            }

            // Update the number of image
            for (int i = 0; i < ListImage.Count; i++)
            {
                ListImage[i].NumofImage = i + 1;
            }

            // Update list image after remove
            var newListImage = new ObservableCollection<ImageModel>(ListImage);

            // Clear the list of added file paths and update it
            addedFilePaths.Clear();
            foreach (var item in newListImage)
            {
                addedFilePaths.Add(item.PathFile);
            }
        }

        private void OnPreviousImageCommand(object obj)
        {

            if (SelectedIndex != 0 && SelectedIndex > 0)
            {
                SelectedIndex -= 1;
            }
            else
            {
                SelectedIndex = ListImage.Count - 1;
            }
        }

        private void OnNextImageCommand(object obj)
        {

            if (SelectedIndex < ListImage.Count - 1)
            {
                SelectedIndex += 1;
            }
            else
            {
                SelectedIndex = 0;
            }
        }

        private void OnAddLabelCommand(object obj)
        {
            var frm = new NewLabelUI();
            frm.ShowDialog();
            var add = frm.DataContext as NewLabelContext;
            if (add.Result != string.Empty && add.Result != null)
            {
                if (ListLabelClass.FirstOrDefault(item => item.LabelName == add.Result) == null)
                {
                    ListLabelClass.Add(new LabelModel() { LabelName = add.Result, Color = add.SelectedColor.ToString(), NumofSample = 0 });
                    ListLabelName.Add(add.Result);
                    ListLabelColor.Add(add.SelectedColor.ToString());
                    SelectedLabelIndex = ListLabelClass.Count - 1;
                    OnPropertyChanged("IsEnableButtonLabel");

                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Label name already exists", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void OnLoadFolderImageCommand(object obj)
        {
            VistaFolderBrowserDialog imgFolderDialog = new VistaFolderBrowserDialog();
            imgFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            imgFolderDialog.ShowNewFolderButton = true;

            if (imgFolderDialog.ShowDialog() == true)
            {

                foreach (var filePath in Directory.GetFiles(imgFolderDialog.SelectedPath))
                {
                    if (IsImageFile(filePath))
                    {
                        if (!addedFilePaths.Contains(filePath))
                        {
                            ImageBoxView.ImageBitmap = new BitmapImage(new Uri(Directory.GetFiles(imgFolderDialog.SelectedPath)[0]));
                            BitmapImage bitmap = new BitmapImage();
                            FileInfo nameFile = new FileInfo(filePath);
                            var fileNameOnly = nameFile.Name;
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(filePath);
                            bitmap.EndInit();
                            ListImage.Add(new ImageModel() { ImageBitmap = bitmap, PathFile = filePath, ImageName = fileNameOnly, NumofImage = ListImage.Count + 1 });
                            addedFilePaths.Add(filePath);
                        }
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Folder " + filePath + " is not an image file", "Notice", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    }
                }
                OnPropertyChanged("SelectedIndex");
                OnPropertyChanged("TotalFile");


            }
        }
        private bool IsImageFile(string filePath)
        {
            var imageExtensions = new[] { ".png", ".jpeg", ".jpg", ".tif", ".jpe", ".bmp" };
            var extension = Path.GetExtension(filePath);
            return imageExtensions.Contains(extension.ToLower());
        }

        private HashSet<string> addedFilePaths = new HashSet<string>();
        private void OnLoadImageCommand(object obj)
        {
            OpenFileDialog imgFileDialog = new OpenFileDialog();
            imgFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.tif, *.png,*.bmp) | *.jpg; *.jpeg; *.jpe; *.tif; *.png; *.bmp";
            imgFileDialog.Multiselect = true;
            imgFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            if (imgFileDialog.ShowDialog() == true)
            {
                // How to add file Image and Name file to ListImage
                foreach (var file in imgFileDialog.FileNames)
                {
                    if (!addedFilePaths.Contains(file))
                    {
                        // ImageBoxView file add
                        ImageBoxView.ImageBitmap = new BitmapImage(new Uri(imgFileDialog.FileNames[0]));
                        BitmapImage bitmap = new BitmapImage();
                        FileInfo nameFile = new FileInfo(file);
                        var fileNameOnly = nameFile.Name;
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(file);
                        bitmap.EndInit();
                        ListImage.Add(new ImageModel() { ImageBitmap = bitmap, PathFile = file, ImageName = fileNameOnly, NumofImage = ListImage.Count + 1 });
                        addedFilePaths.Add(file);
                    }
                }
                OnPropertyChanged("SelectedIndex");
                OnPropertyChanged("TotalFile");

            }
        }
    }
}
