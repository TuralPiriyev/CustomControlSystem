using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Model;
using CustomControlSystem.ViewModel;
using System;
using System.Linq;
using System.Windows.Input;

namespace CustomControlSystem.Commands.SaleCommands
{
    public class OpenSearchSaleCommand : ICommand
    {
        private readonly SaleViewModel _viewModel;

        public event EventHandler? CanExecuteChanged;

        public OpenSearchSaleCommand(SaleViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            // Axtarışın həyata keçirilməsinə icazə verilirmi?
            return true;
        }

        public void Execute(object? parameter)
        {
            // Axtarış məntiqini burada yazırıq
            string searchQuery = _viewModel.SearchText; // İstifadəçinin daxil etdiyi axtarış mətni

            if (!string.IsNullOrEmpty(searchQuery))
            {
                var filteredSales = _viewModel.SaleModels
                    .Where(sale => sale.ProductName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                   sale.Amount.ToString().Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

                // Nəticələri SaleModels olaraq yeniləyin
                _viewModel.SaleModels.Clear();
                foreach (var sale in filteredSales)
                {
                    _viewModel.SaleModels.Add(sale);
                }
            }
        }
    }
}
