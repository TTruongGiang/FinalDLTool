using ST4I.Vision.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace FinalDLTools
{
    class EditLabelContext : INotifyPropertyChanged
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

        private bool isEnableChange;
        public bool IsEnableChange
        {
            get { return isEnableChange; }
            set { isEnableChange = value; OnPropertyChanged(); }
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
                    IsEnableChange = true;
                }
                else
                {
                    IsEnableChange = false;
                }
                OnPropertyChanged();
                OnPropertyChanged("IsEnableChange");
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
                OnPropertyChanged("IsEnableChange");
            }
        }

        private ObservableCollection<LabelModel> listLabel = new ObservableCollection<LabelModel>();
        public ObservableCollection<LabelModel> ListLabel
        {
            get { return listLabel; }
            set { listLabel = value; OnPropertyChanged(); }
        }

        public RelayCommand EditLabelCommand { get; set; }
        public RelayCommand CancelCommad { get; set; }

        public EditLabelContext()
        {
            EditLabelCommand = new RelayCommand(EditLabel);
            CancelCommad = new RelayCommand(Cancel);
            
        }

        private void Cancel(object obj)
        {
            Window editLabel = obj as Window;
            editLabel.Close();
        }

        private void EditLabel(object obj)
        {
            Window editLabel = obj as Window;
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
                                editLabel.Close();
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
                    editLabel.Close();
                }
            }
        }
    }
}
