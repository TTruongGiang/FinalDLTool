using System;
using System.Collections.Generic;
using System.ComponentModel;
using ST4I.Vision;
using ST4I.Vision.Controls;
using Ookii.Dialogs.Wpf;
using ST4I.Vision.UI;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace FinalDLTools
{
    class NewLabelContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

       

        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        private bool isEnableAdd;
        public bool IsEnableAdd
        {
            get { return isEnableAdd; }
            set { isEnableAdd = value; OnPropertyChanged(); }
        }

        private string label;

        public string Label
        {
            get { return label; }
            set
            {
                label = value;
                if (value != string.Empty)
                {
                    IsEnableAdd = true;
                }
                else
                {
                    IsEnableAdd = false;
                }
                OnPropertyChanged();
                OnPropertyChanged("IsEnableAdd");
            }
        }

        private ColorPicker color;

        public ColorPicker Color
        {
            get { return color; }
            set
            {
                color = value;
                if (color != null)
                {
                    IsEnableAdd = true;
                }
                else
                {
                    IsEnableAdd = false;
                }
                OnPropertyChanged();
                OnPropertyChanged("IsEnableAdd");
            }
        }

        private Color selectedColor;
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                selectedColor = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LabelModel> listLabel = new ObservableCollection<LabelModel>();
        public ObservableCollection<LabelModel> ListLabel
        {
            get { return listLabel; }
            set { listLabel = value; OnPropertyChanged(); }
        }

        public RelayCommand AddLabelCommand { get; set; }
        public RelayCommand CancelCommad { get; set; }

        public NewLabelContext()
        {
            AddLabelCommand = new RelayCommand(AddLabel);
            CancelCommad = new RelayCommand(Cancel);
            
            
        }

        private void Cancel(object obj)
        {
            Window newLabel = obj as Window;
            newLabel.Close();
        }

        private void AddLabel(object obj)
        {
            Window newLabel = obj as Window;
            // if Label and ShortCut is empty show message
            if (Label == string.Empty || Label == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Please enter Label", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Result = Label;
                if (ListLabel.Count > 0)
                {
                    if (Result != string.Empty)
                    {
                        if (ListLabel.FirstOrDefault(item => item.LabelName == Result) == null)
                        {
                            // Check if the color already exists
                            if (ListLabel.Any(x => x.Color == SelectedColor.ToString()))
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Color already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                newLabel.Close();
                            }
                        }

                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Label already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Please Label inappropriate", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    newLabel.Close();
                }
            }
        }
    }
}
