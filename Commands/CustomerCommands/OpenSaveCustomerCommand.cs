using CustomControlSystem.ViewModel;
using CustomControlSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControlSystem.Commands.CustomerCommands
{
    public class OpenSaveCustomerCommand : ICommand
    {
        private readonly CustomerViewModel _viewModel;
        private bool _isUpdate;

        public OpenSaveCustomerCommand(CustomerViewModel viewModel)
        {
            _viewModel = viewModel; 
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public OpenSaveCustomerCommand SetAsUpdate()
        {
            _isUpdate = true;
            return this;
        }
        public void Execute(object? parameter)
        {
            SaveCustomerWindow window = new SaveCustomerWindow();
            SaveCustomerWindowViewModel viewModel = new SaveCustomerWindowViewModel(window, _viewModel);  
             
            window.DataContext = viewModel;

            if(_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedCustomerIndex;

                viewModel.CustomerModel = _viewModel.CustomerModels[selectedIndex];
            }
            window.Show();
        }
    }
}
