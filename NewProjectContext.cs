using System;
using System.Collections.Generic;
using System.ComponentModel;
using ST4I.Vision;
using ST4I.Vision.Controls;
using Ookii.Dialogs.Wpf;
using ST4I.Vision.UI;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FinalDLTools
{
    class NewProjectContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Selected method Classification for project
        /// </summary>
        private bool isClassification;
        public bool IsClassification
        {
            get { return isClassification; }
            set { isClassification = value; OnPropertyChanged(); }
        }

        
        private bool isDetection;
        public bool IsDetection
        {
            get { return isDetection; }
            set { isDetection = value; OnPropertyChanged(); }
        }
        private bool isSegmentation;
        public bool IsSegmentation
        {
            get { return isSegmentation; }
            set { isSegmentation = value; OnPropertyChanged(); }
        }
        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        private bool isEnableCreate;
        public bool IsEnableCreate
        {
            get { return isEnableCreate; }
            set { isEnableCreate = value; OnPropertyChanged(); }
        }

        private string projectName;
        public string ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                if (value != string.Empty)
                {
                    IsEnableCreate = true;
                }
                else
                {
                    IsEnableCreate = false;
                }
                OnPropertyChanged();
                OnPropertyChanged("IsEnableCreate");
            }
        }

        
        private string pathSelected;
        public string PathSelected
        {
            get { return pathSelected; }
            set
            {
                pathSelected = value;
                if (value != string.Empty)
                {
                    IsEnableCreate = true;
                }
                else
                {
                    IsEnableCreate = false;
                    
                }
                OnPropertyChanged();
                OnPropertyChanged("IsEnableCreate");
            }
        }

        private string descriptionProject;
        public string DescriptionProject
        {
            get { return descriptionProject; }
            set 
            { 
                descriptionProject = value;
                if (value != string.Empty)
                {
                    IsEnableCreate = true;
                }
                else
                {
                    IsEnableCreate = false;
                }
                OnPropertyChanged();
                OnPropertyChanged("IsEnableCreate");
            }
        }

        private ObservableCollection<ProjectModel> listProject = new ObservableCollection<ProjectModel>();
        public ObservableCollection<ProjectModel> ListProject
        {
            get { return listProject; }
            set { listProject = value; OnPropertyChanged(); }
        }

        public RelayCommand CreateCommand { get; set; }
        public RelayCommand BrowseCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public NewProjectContext()
        {
            CreateCommand = new RelayCommand(Create);
            BrowseCommand = new RelayCommand(Browse);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Create(object obj)
        {
            Window newProject = obj as Window;
            // If not choose method show message
            if (IsClassification == false && IsDetection == false && IsSegmentation == false)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Please choose method", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // If ProjectName and PathSelected is emty or null show message
                if (ProjectName == null || ProjectName == string.Empty || PathSelected == null || PathSelected == string.Empty)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Please enter Project Name and Path", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Result = ProjectName;
                    if (ListProject.Count > 0)
                    {
                        if (Result != string.Empty)
                        {
                            if (ListProject.FirstOrDefault(item => item.Name == Result && item.Path == PathSelected) == null)
                            {
                                newProject.Close();
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Project Name is exist at Path", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Plese Project Name is inappropriate", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        newProject.Close();
                    }
                }
           
            }

        }

        private void Cancel(object obj)
        {
            Window newProject = obj as Window;
            newProject.Close();
        }

        private void Browse(object obj)
        {
            VistaFolderBrowserDialog pathFileDialog = new VistaFolderBrowserDialog();
            if (pathFileDialog.ShowDialog() == true)
            {
                PathSelected = pathFileDialog.SelectedPath;
            }
        }
    }
}
