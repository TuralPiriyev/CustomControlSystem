using CustomControlSystem.Model;
using CustomControlSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControlSystem.Commands.SaleCommands
{
    public class AddCustomerToListCommand : ICommand
    {
        private readonly SaveSaleViewModel _viewModel;
        public AddCustomerToListCommand(SaveSaleViewModel viewModel)
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
            CustomerModel customer = _viewModel.Customer[_viewModel.SelectedCustomerToAdd];

            _viewModel.Customer.Remove(customer);
            _viewModel.SelectedCustomer.Add(customer);
        }
    }
}
