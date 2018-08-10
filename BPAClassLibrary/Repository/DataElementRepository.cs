using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
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
            List<DataElement> listDataelement = new List<DataElement>();
            //DataSet ds = DataAccess.ExecuteSQLGetList<Backbone>(DataAccess.ConnectionStrings.Ansira, "");
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllDataElement", sqlconnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            DataElement dataelement = new DataElement();
                            dataelement.DataElementTypeId = Convert.ToInt32(sdr["DataElementTypeId"].ToString());
                            dataelement.DataElementName = sdr["DataElementName"].ToString();
                            listDataelement.Add(dataelement);
                        }
                        response.DataElementList = listDataelement;
                        response.Success = "true";
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.Success = "false";
            }
            return response;
        }

        public bool CreateDataElement(DataElement dataelement)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into DataElementType (DataElementName) values (@DataElementName)", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@DataElementName", dataelement.DataElementName));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
            return result;
        }

        public bool UpdateDataElement(DataElement dataelement)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Update DataElementType set DataElementName=@DataElementName where DataElementTypeId=@DataElementTypeId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@DataElementName", dataelement.DataElementName));
                    cmd.Parameters.Add(new SqlParameter("@DataElementTypeId", dataelement.DataElementTypeId));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
            return result;
        }

        public bool DeleteDataElement(DataElement dataelement)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from DataElementType where DataElementTypeId=@DataElementTypeId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@DataElementTypeId", dataelement.DataElementTypeId));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
            return result;
        }
    }
}
