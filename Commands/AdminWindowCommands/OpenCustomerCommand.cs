using CustomControlSystem.ViewModel;
using CustomControlSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControlSystem.Commands.AdminWindowCommands
{
    public class OpenCustomerCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenCustomerCommand(AdminWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            CustomerControl control = new CustomerControl();
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Load();
            control.DataContext = customerViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
