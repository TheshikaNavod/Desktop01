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
using System.Windows.Shapes;

namespace Desktop01
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow(AddUserVM vm)

        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }
   


        private void ClearText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = "";
            textBox.Foreground = Brushes.Black; // Set the foreground color back to black
            textBox.GotFocus -= ClearText;
        }

        private void SetDefaultText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text)&& textBox == firstNameTextBox)
            {
                textBox.Text = "Enter First Name Here";
                textBox.Foreground = Brushes.Gray; // Set the foreground color to gray
                textBox.GotFocus += ClearText;
            }
            if (string.IsNullOrEmpty(textBox.Text) && textBox == lastNameTextBox)
            {
                textBox.Text = "Enter last Name Here";
                textBox.Foreground = Brushes.Gray; // Set the foreground color to gray
                textBox.GotFocus += ClearText;
            }
            if (string.IsNullOrEmpty(textBox.Text) && textBox == ageTextBox)
            {
                textBox.Text = "Enter age Here";
                textBox.Foreground = Brushes.Gray; // Set the foreground color to gray
                textBox.GotFocus += ClearText;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetDefaultText(firstNameTextBox, null);
            SetDefaultText(lastNameTextBox, null);
            SetDefaultText(ageTextBox, null);
        }
    }
}

    










 
