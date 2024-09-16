using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Model;
using CustomControlSystem.ViewModel;
using CustomControlSystem.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControlSystem.Commands.SaleCommands
{
    public class OpenSaveSaleCommand : ICommand
    {
        private readonly SaleViewModel _saleViewModel;

        public bool _isUpdate;
        public OpenSaveSaleCommand(SaleViewModel saleViewModel)
        {
            _saleViewModel = saleViewModel;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public OpenSaveSaleCommand SetAsUpdate()
            {
            _isUpdate = true;
            return this;
        }
        public void Execute(object? parameter)
        {
            SaveSaleWindow window = new SaveSaleWindow();
            SaveSaleViewModel viewModel = new SaveSaleViewModel(window, _saleViewModel);

            List<Customer> AllCustomer = ApplicationContext.DB.CustomerRepository.Get();

            if(_isUpdate)
            {

                int selectedIndex = _saleViewModel.SelectedSaleIndex;

                viewModel.SaleModel = _saleViewModel.SaleModels[selectedIndex];

                List<CustomerSale> customers = ApplicationContext.DB.CustomerSaleRepository.GetBySaleId(viewModel.SaleModel.SaleId);
                foreach (CustomerSale customerSale in customers)
                {

                    viewModel.SelectedCustomer.Add(new Model.CustomerModel
                    {
                        CustomerId = (int)customerSale.CustomerId,
                        CustomerName = customerSale.Customer.CustomerName,
                        CustomerSurName = customerSale.Customer.CustomerSurName,
                        Email = customerSale.Customer.Email,
                        PhoneNumber = customerSale.Customer.PhoneNumber,
                        Address = customerSale.Customer.Address,
                        Status = customerSale.Customer.Status

                    });

                    AllCustomer.RemoveAll(x => x.CustomerId == customerSale.CustomerId);
                    viewModel.Customer = new ObservableCollection<CustomerModel>((IEnumerable<CustomerModel>)AllCustomer);
                }
                viewModel.Load(AllCustomer);
                window.DataContext = viewModel;
                window.Show();
            }
      
        }
        
    }
}
