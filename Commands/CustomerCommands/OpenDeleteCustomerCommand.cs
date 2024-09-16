using CustomControlSystem.Model;
using CustomControlSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CustomControlSystem.Commands.CustomerCommands
{
    public class OpenDeleteCustomerCommand : ICommand

    {
        private readonly CustomerViewModel _viewModel;

        public OpenDeleteCustomerCommand(CustomerViewModel viewModel)
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
            int index = _viewModel.SelectedCustomerIndex;
            CustomerModel model = _viewModel.CustomerModels[index];
            MessageBoxResult result = MessageBox.Show($"Are you sure to delete {model.CustomerName} {model.CustomerSurName} {model.Email} {model.PhoneNumber} {model.Address} {model.Status}?", "Delete Customer", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            ApplicationContext.DB.CustomerSaleRepository.DeleteBySale(model.CustomerId);
            ApplicationContext.DB.CustomerSaleRepository.Delete(model.CustomerId);
            _viewModel.CustomerModels.Remove(model);
        }
    }
}
