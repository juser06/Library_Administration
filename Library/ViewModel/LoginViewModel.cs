﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string username;
        private SecureString password;
        private string errorMessage;
        private bool isViewVisible = true;

        //properties
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage 
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible 
        {
            get
            {
                return isViewVisible;
            }
            set
            {
                isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        // -> Command
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructors
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand ( "", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password.Length < 3 || Password == null)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRecoverPassCommand(string v1, string v2)
        {
            throw new NotImplementedException();
        }

    }
}
