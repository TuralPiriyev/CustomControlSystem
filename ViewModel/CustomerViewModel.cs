using CustomControlSystem.Commands.CustomerCommands;
using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Model;
using CustomControlSystem.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CustomControlSystem.ViewModel
{
    public class CustomerViewModel : IDataLoader
    {
        public CustomerViewModel()
        {
            this.OpenAddCustomer = new OpenSaveCustomerCommand(this);
            this.OpenUpdateCustomer = new OpenSaveCustomerCommand(this).SetAsUpdate();
            this.OpenDeleteCustomer = new OpenDeleteCustomerCommand(this);
            this.OpenSearchCustomer = new OpenSearchCustomerCommand(this);

        }

        public ObservableCollection<CustomerModel> CustomerModels { get; set; }
        public ICommand OpenAddCustomer { get; set; }
        public ICommand OpenUpdateCustomer { get; set; }
        public ICommand OpenDeleteCustomer { get; set; }
        public ICommand OpenSearchCustomer { get; set; }
        public string SearchText { get; set; }
        public int SelectedCustomerIndex { get; set; }

        public void Load()
        {
            List<Customer> customers = ApplicationContext.DB.CustomerRepository.Get();
            CustomerModels = new ObservableCollection<CustomerModel>();

            foreach (Customer c in customers)
            {
                CustomerModel model = new CustomerModel

                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    CustomerSurName = c.CustomerSurName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Status = c.Status
                };     
                CustomerModels.Add(model);
                }

        }
    }
}
