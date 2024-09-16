using CustomControlSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControlSystem.Commands.CustomerCommands
{
    public class OpenSearchCustomerCommand : ICommand
    {
        private readonly CustomerViewModel _viewModel;

        public OpenSearchCustomerCommand(CustomerViewModel viewModel)
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
            string searchQuery = _viewModel.SearchText; // İstifadəçinin daxil etdiyi axtarış mətni

            if (!string.IsNullOrEmpty(searchQuery))
            {
                var filteredCustomers = _viewModel.CustomerModels
                    .Where(customer => customer.CustomerName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                       customer.CustomerSurName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Nəticələri CustomerModels olaraq yeniləyin
                _viewModel.CustomerModels.Clear();
                foreach (var customer in filteredCustomers)
                {
                    _viewModel.CustomerModels.Add(customer);
                }
            }
        }
    }
}
