using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Model;
using CustomControlSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControlSystem.Commands.CustomerCommands
{
    public class SaveCustomerCommand : ICommand
    {
        private readonly SaveCustomerWindowViewModel _viewModel;

        public SaveCustomerCommand(SaveCustomerWindowViewModel viewModel)
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
            CustomerModel model = _viewModel.CustomerModel;

            Customer customer = new Customer
            {
                CustomerId = model.CustomerId,
                CustomerName = model.CustomerName,
                CustomerSurName = model.CustomerSurName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Status = model.Status,
            };
            if(customer.CustomerId>0)
            {
                ApplicationContext.DB.CustomerRepository.Update(customer);
            }
            else
            {
                ApplicationContext.DB.CustomerRepository.Add(customer);
                model.CustomerId = customer.CustomerId;

                _viewModel.Parent.CustomerModels.Add(model);
            }
            _viewModel.Window.Close();

        }
    }
}
