using CustomControlSystem.Model;
using CustomControlSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CustomControlSystem.Commands.SaleCommands
{
    public class OpenDeleteSaleCommand : ICommand
    {
        private readonly SaleViewModel _viewModel;

        public event EventHandler? CanExecuteChanged;

        public OpenDeleteSaleCommand(SaleViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            int index = _viewModel.SelectedSaleIndex;
            SaleModel model = _viewModel.SaleModels[index];
            MessageBoxResult result = MessageBox.Show($"Are you sure to delete '{model.ProductName}, {model.Amount}, {model.SaleDate},{model.Status}'?", "Delete Customer", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                return;
            }
            ApplicationContext.DB.CustomerSaleRepository.DeleteBySale(model.SaleId);
            ApplicationContext.DB.SaleRepository.Delete(model.SaleId);
            _viewModel.SaleModels.Remove(model);
        }
    }
}
