using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPA.Services;
using System.Collections.Specialized;

namespace BPAClassLibrary.Repository
{
   public class DealerRepository: IDealerRepository
    {
      public IList<Dealer> GetDealerData()
        {
            List<Dealer> dealer = DataAccess.ExecuteSPGetList<Dealer>(DataAccess.ConnectionStrings.Ansira, "GetAllDealerDetails");
            return dealer;
        }

        public bool CreateDealer(Dealer dealer_Data)

        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("DealerName", dealer_Data.DealerName);
            param.Add("DealerUrl", dealer_Data.DealerUrl);
            param.Add("OEMId", dealer_Data.OEMId);
            param.Add("BackboneId", dealer_Data.BackboneId);
            param.Add("DealerCode", dealer_Data.DealerCode);
            param.Add("Zone", dealer_Data.Zone);
            param.Add("Region", dealer_Data.Region);
            param.Add("CreatedBy", dealer_Data.CreatedBy);
            param.Add("CreateTs", dealer_Data.CreateTs);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateDealer",param);
            return Convert.ToBoolean(result);
        }

        public bool UpdateDealer(Dealer dealer_Data)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("DealerId", dealer_Data.DealerId);
            param.Add("DealerName", dealer_Data.DealerName);
            param.Add("DealerUrl", dealer_Data.DealerUrl);
            param.Add("OEMId", dealer_Data.OEMId);
            param.Add("BackboneId", dealer_Data.BackboneId);
            param.Add("DealerCode", dealer_Data.DealerCode);
            param.Add("Zone", dealer_Data.Zone);
            param.Add("Region", dealer_Data.Region);
            param.Add("UpdatedBy", dealer_Data.UpdatedBy);
            param.Add("UpdateTs", dealer_Data.UpdateTs);
            param.Add("IsActive", dealer_Data.IsActive);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateDealerInfo",param);
            return Convert.ToBoolean(result);
        }

        public bool DeleteDealer(Dealer dealer_Data)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("DealerId", dealer_Data.DealerId);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteDealer",param);
            return Convert.ToBoolean(result);
        }

    }
}
