using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace checkbox_Notifier_changes_implementation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            private ColumnSelection _column;

        public ColumnSelection Column
        {
            get { return _column; }
            set { _column = value; }
        }


        ObservableCollection<ColumnSelection> observable = new ObservableCollection<ColumnSelection>();
            chkSelection.DataContext = observable;
            observable.Add(new ColumnSelection("Himanshu", true));
            observable.Add(new ColumnSelection("sonu", true));

            //chkSelection.DataContext = observable;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test1");
        }
    }

    public class ColumnSelection : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string __myString;

        public string MyString
        {
            get { return __myString; }
            set { __myString = value;            
            }
        }

        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value;
                NotifyPropertyChanged("IsChecked");
            }
        }

        public ColumnSelection(string myString, bool isChecked)
        {
            MyString = myString;
            IsChecked = isChecked;
        }
    }
}
