using CustomControlSystem.Commands.AdminWindowCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlSystem.ViewModel
{
    public class AdminWindowViewModel : BaseWindowViewModel
    {
        public AdminWindowViewModel(Window window) : base(window)
        {
            OpenCustomer = new OpenCustomerCommand(this);
            OpenSale = new OpenSaleCommand(this);
        }

        public ICommand OpenCustomer { get; set; }
        public ICommand OpenSale { get; set;}
        public Grid CenterGrid { get; set; }
    }
}
