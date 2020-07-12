using App2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App2.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public MainVM ViewModel { get; set; }

        public LoginCommand(MainVM viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (Users)parameter;

            if (user == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
           {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            ViewModel.Login();
        }
    }
}
