using CustomControlSystem.Commands.CustomerCommands;
using CustomControlSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CustomControlSystem.ViewModel
{
    public class SaveCustomerWindowViewModel : BaseWindowViewModel
    {
        public SaveCustomerWindowViewModel(Window window, CustomerViewModel parent) : base(window)
        {
            this.CustomerModel = new CustomerModel();
            this.Parent = parent;
            this.SaveCustomer = new SaveCustomerCommand(this);
        }

        public CustomerModel CustomerModel { get; set; }
        public ICommand SaveCustomer { get; set; }
        public CustomerViewModel  Parent { get; set; }
    }
}
