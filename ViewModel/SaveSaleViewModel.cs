using CustomControlSystem.Commands.SaleCommands;
using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Model;
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
    public class SaveSaleViewModel : BaseWindowViewModel
    {
        public SaveSaleViewModel(Window window, SaleViewModel parent) : base(window)
        {
            AddCustomerToList = new AddCustomerToListCommand(this);
            SaveSale = new SaveSaleCommand(this);
            Parent = parent;

        }

        public SaleViewModel Parent { get; set; }
        public ICommand AddCustomerToList { get; set; }
        public ICommand SaveSale { get; set; }
        public ICommand DeleteCustomerFromList { get; set; }
        public SaleModel SaleModel { get; set; } = new SaleModel();
        public ObservableCollection<CustomerModel> Customer { get; set; } = new ObservableCollection<CustomerModel>();
        public ObservableCollection<CustomerModel> SelectedCustomer { get; set; } = new ObservableCollection<CustomerModel>();
        public int SelectedCustomerToAdd { get; set; }
        public int SelectedCustomerToDelete { get; set; }


        public void Load(List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                CustomerModel model = new CustomerModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    CustomerSurName = customer.CustomerSurName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    Status = customer.Status
                };
                Customer.Add(model);
            }

        }
    }
}
