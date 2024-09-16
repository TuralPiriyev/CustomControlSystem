using CustomControlSystem;
using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Utils;
using CustomControlSystem.ViewModel;
using CustomControlSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CustomControlSystem.Commands.LoginCommands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginWindowViewModel _loginWindowViewModel;
        

        public LoginCommand(LoginWindowViewModel loginWindowViewModel)
        {
            _loginWindowViewModel = loginWindowViewModel ?? throw new ArgumentNullException(nameof(loginWindowViewModel)); 
        }

      
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           
            
            string username = _loginWindowViewModel.LoginModel.Username;


            User user = ApplicationContext.DB.UserRepository.Get(username);

            if(user == null)
            {
                this.Fail(username);
                return;
            }
            string password = ((PasswordBox)parameter).Password;
            string passwordHash = HashHelper.Hash(password);

            if(user.PasswordHash != passwordHash)
            {
                this.Fail(username);
                return;

            }

            ApplicationContext.CurrentUser = user;

            AdminWindow window = new AdminWindow();

            AdminWindowViewModel viewModel = new AdminWindowViewModel(window);
            viewModel.CenterGrid = window.grdCenter;

            window.DataContext = viewModel;
            //TODO: add viewmodel to data context
            window.Show();
            _loginWindowViewModel.Window.Close();
        }

        

        private void Fail(string username)
        {
            _loginWindowViewModel.LoginModel = new Model.LoginModel
            {
                Password = "",
                Username = username,

            };

            _loginWindowViewModel.ErrorVisibility = Visibility.Visible;
        }

  
        
    }
}

