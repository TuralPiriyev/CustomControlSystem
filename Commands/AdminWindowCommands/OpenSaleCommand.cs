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
    public class OpenSaleCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenSaleCommand(AdminWindowViewModel viewModel)
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
            SaleControl control = new SaleControl();
            SaleViewModel saleViewModel = new SaleViewModel();
            saleViewModel.Load();

            control.DataContext = saleViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
