﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser=null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }


       

        //[RelayCommand]
        //public void messeag()
        //{

        //    MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4.", "Error");
        //}

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();
            //student ta details dunnd blala save wenw nattm worning ekk denw
            if (vm.Student  != null)
            {
                users.Add(vm.Student);
            }
            else
            {
                MessageBox.Show("Enter student details to save");
            } 
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");
                
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");
            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();
                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);

            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(13, "kasun", "sumudu", "12/1/2010",image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(22, "amal", "asela", "12/1/2001",image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(24, "nimal", "kumara", "2/11/1999",image3));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(25, "sanath", "salitha", "12/1/1998", image4));

        }
    }
}
