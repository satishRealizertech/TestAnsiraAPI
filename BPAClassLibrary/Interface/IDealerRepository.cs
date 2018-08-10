using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Interface
{
   public interface IDealerRepository
    {
        IList<Dealer> GetDealerData();
        bool CreateDealer(Dealer dealer_Data);
        bool UpdateDealer(Dealer dealer_Data);
        bool DeleteDealer(Dealer dealer_Data);

    }
}
