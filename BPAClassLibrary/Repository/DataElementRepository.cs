using BPA.Services;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Repository
{
   public class DataElementRepository: IDataElementRepository
    {
        public DataElementResponseModel GetDataElementList()
        {
            DataElementResponseModel response = new DataElementResponseModel();
            response.DataElementList = DataAccess.ExecuteSQLGetList<DataElement>(DataAccess.ConnectionStrings.Ansira, "GetAllDataElement");
            return response;
           
        }

        public bool CreateDataElement(DataElement dataelement)
        {

            ListDictionary param = new ListDictionary();
            param.Add("DataElementName", dataelement.DataElementName);
            param.Add("CreatedBy", dataelement.CreatedBy);
            param.Add("CreateTs", dataelement.CreateTs);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateDataElement", param);
            return Convert.ToBoolean(result);

        }

        public bool UpdateDataElement(DataElement dataelement)
        {
            ListDictionary param = new ListDictionary();
            param.Add("DataElementTypeId", dataelement.DataElementTypeId);
            param.Add("DataElementName", dataelement.DataElementName);
            param.Add("UpdatedBy", dataelement.UpdatedBy);
            param.Add("UpdateTs", dataelement.UpdateTs);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateDataElement", param);
            return Convert.ToBoolean(result);
        }

        public bool DeleteDataElement(DataElement dataelement)
        {
            ListDictionary param = new ListDictionary();
            param.Add("DataElementTypeId", dataelement.DataElementTypeId);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteDataElement", param);
            return Convert.ToBoolean(result);
        }
    }
}
