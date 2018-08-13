using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPAClassLibrary.Model;
using BPA.Core.Services;
using System.Data;
using BPAClassLibrary.Interface;
using BPA.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace BPAClassLibrary.Repository
{

   public class OEMRepository : IOEMRepository
    {
        public IList<OEM> GetOEM()
        {
            List<OEM> oems = DataAccess.ExecuteSPGetList<OEM>(DataAccess.ConnectionStrings.Ansira, "GetAllOEMs");
            return oems;
        }

        public bool CreateOEM(OEM OEM_Data)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("OEMName", OEM_Data.OEMName);
            param.Add("CreatedBy", OEM_Data.CreatedBy);
            param.Add("CreateTs", OEM_Data.CreateTs);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateOEM",param);
            return Convert.ToBoolean(result);
        }

        public bool UpdateOEM(OEM OEMData)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("OEMName", OEMData.OEMName);
            param.Add("OEMId", OEMData.OEMId);
            param.Add("UpdatedBy", OEMData.UpdatedBy);
            param.Add("UpdateTs", OEMData.UpdateTs);
            param.Add("IsActive", OEMData.IsActive);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateOEM", param);
            return Convert.ToBoolean(result);
        }

        public bool DeleteOEM(OEM OEMData)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("OEMId", OEMData.OEMId);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteOEM",param);
            return Convert.ToBoolean(result);
        }


    }
}
