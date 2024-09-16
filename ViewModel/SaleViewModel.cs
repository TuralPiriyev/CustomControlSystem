using CustomControlSystem.Commands.AdminWindowCommands;
using CustomControlSystem.Commands.SaleCommands;
using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Model;
using CustomControlSystem.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControlSystem.ViewModel
{
    public class SaleViewModel : IDataLoader
    {
        public SaleViewModel()
        {

            OpenAddSale = new OpenSaveSaleCommand(this);
            OpenUpdateSale = new OpenSaveSaleCommand(this).SetAsUpdate();
            OpenDeleteSale = new OpenDeleteSaleCommand(this);
            OpenSearchSale = new OpenSearchSaleCommand(this);
        }
         

        public ObservableCollection<SaleModel> SaleModels { get; set; }
        public string SearchText { get; set; }
        public ICommand OpenAddSale { get; set; }
        public ICommand OpenUpdateSale { get; set; }
        public ICommand OpenDeleteSale { get; set; }
        public ICommand OpenSearchSale { get; set; }
        public int SelectedSaleIndex { get; set; }
        public void Load()
        {
            SaleModels = new ObservableCollection<SaleModel>();
            List<Sale> sales = ApplicationContext.DB.SaleRepository.Get();

            foreach (Sale s in sales)
            {
                SaleModel model = new SaleModel()
                {
                    SaleId = s.SaleId,
                    ProductName = s.ProductName,
                    Amount = s.Amount,
                    SaleDate = s.SaleDate,
                    Status = s.Status
                };
                SaleModels.Add(model);

            }

        }
    }
}
