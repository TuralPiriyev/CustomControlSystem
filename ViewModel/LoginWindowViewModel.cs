﻿using CustomControlSystem.Commands.LoginCommands;
using CustomControlSystem.Model;
using System.Windows;
using System.Windows.Input;

namespace CustomControlSystem.ViewModel
{
    public class LoginWindowViewModel : BaseWindowViewModel
    {
        public LoginWindowViewModel(Window window) : base(window)
        {
            LoginModel = new LoginModel();
            Login = new LoginCommand(this);
            OpenRegister = new OpenRegisterCommand(this);
        }

        public ICommand Login { get; set; }
        public ICommand OpenRegister { get; set; }



        private LoginModel loginModel;
        public LoginModel LoginModel
        {
            get { return loginModel; }
            set
            {
                loginModel = value;
                this.NotifyChanged(nameof(LoginModel));
            }
        }

        private Visibility errorVisibility = Visibility.Hidden;
        public Visibility ErrorVisibility
        {
            get { return errorVisibility; }
            set
            {
                errorVisibility = value;
                this.NotifyChanged(nameof(ErrorVisibility));
            }

        }
    }
}
