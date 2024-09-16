using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Utils;
using CustomControlSystem.ViewModel;
using CustomControlSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlSystem.Commands.RegisterCommand
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterWindowViewModel _windowViewModel;
        public RegisterCommand(RegisterWindowViewModel windowViewModel)
        {
            _windowViewModel = windowViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string password = ((PasswordBox)parameter).Password;
            User user = new User
            {
                Username = _windowViewModel.RegisterModel.Username,
                Email = _windowViewModel.RegisterModel.Email,
                PasswordHash = HashHelper.Hash(password)
            };

            ApplicationContext.DB.UserRepository.Add(user);

            LoginWindow window = new LoginWindow();
            window.DataContext = new LoginWindowViewModel(window);

            window.Show();

            _windowViewModel.Window.Close();

        }
    }
}
