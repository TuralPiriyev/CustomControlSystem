using CustomControlSystem.Core.Domain.Entities;
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
    public class SaveSaleCommand : ICommand
    {
        private readonly SaveSaleViewModel _viewModel;

        public SaveSaleCommand(SaveSaleViewModel viewModel)
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
            Sale sale = new Sale
            {
                SaleId = _viewModel.SaleModel.SaleId,
                ProductName = _viewModel.SaleModel.ProductName,
                Amount = _viewModel.SaleModel.Amount,
                SaleDate = _viewModel.SaleModel.SaleDate,
                Status =    _viewModel.SaleModel.Status
            };

            if(sale.SaleId>0)
            {
                this.UpdateSale(sale);
            }
            else
            {
                ApplicationContext.DB.SaleRepository.Add(sale);
                _viewModel.SaleModel.SaleId = sale.SaleId;
                _viewModel.Parent.SaleModels.Add(_viewModel.SaleModel);
            }

            foreach(CustomerModel model in _viewModel.SelectedCustomer)
            {
                CustomerSale cs = new CustomerSale
                {
                    SaleId = model.CustomerId,
                    CustomerId = model.CustomerId,

                };
                ApplicationContext.DB.CustomerSaleRepository.Add(cs);
            }

            _viewModel.Window.Close();

        }

     

        private void UpdateSale(Sale sale)
        {
            ApplicationContext.DB.SaleRepository.Update(sale);

            ApplicationContext.DB.CustomerSaleRepository.DeleteBySale(sale.SaleId);
        }
    }
}
