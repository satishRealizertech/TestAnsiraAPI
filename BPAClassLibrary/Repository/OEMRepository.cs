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

namespace BPAClassLibrary.Repository
{

   public class OEMRepository : IOEMRepository
    {
        public IList<OEM> GetOEM()
        {
            List<OEM> oems = new List<OEM>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllOEMs", sqlconnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            OEM oem_data = new OEM();
                            oem_data.OEM_Id = Convert.ToInt32(sdr["OEMId"].ToString());
                            oem_data.OEM_Name = sdr["OEMName"].ToString();
                            oems.Add(oem_data);

                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            //DataSet ds = DataAccess.ExecuteSQLSelect(DataAccess.ConnectionStrings.Ansira, "select * from OEM");
            //DataTable dtBasic = ds.Tables[0];
            //foreach (DataRow row in dtBasic.Rows)
            //{
            //    OEM oem_data = new OEM();
            //    oem_data.OEM_Id = row.Field<int>("OEMId");
            //    oem_data.OEM_Name = row.Field<string>("OEMName");
            //    oems.Add(oem_data);
            //}
            return oems;
        }

        public bool CreateOEM(OEM OEM_Data)
        {
            //var result = DataAccess.ExecuteSQLNonQuery(DataAccess.ConnectionStrings.Ansira, "Insert into OEM (OEMName) values (" + OEM_Data.OEM_Name + ")");
            //return Convert.ToBoolean(result);
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into OEM(OEMName) Values('" + OEM_Data.OEM_Name + "')", sqlconnection);
                    result=Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return true;
        }

        public bool UpdateOEM(OEM OEM_Data)
        {
            //var result = DataAccess.ExecuteSQLNonQuery(DataAccess.ConnectionStrings.Ansira, "Update OEM SET OEMName='"+ OEM_Data.OEM_Name+ "' Where OEMId='" + Convert.ToInt32(OEM_Data.OEM_Id) + "'");
            //return Convert.ToBoolean(result);
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Update OEM SET OEMName = '"+ OEM_Data.OEM_Name+ "' Where OEMId = " + Convert.ToInt32(OEM_Data.OEM_Id) + "",sqlconnection);
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }

        public bool DeleteOEM(OEM OEM_Data)
        {
            //var result = DataAccess.ExecuteSQLNonQuery(DataAccess.ConnectionStrings.Ansira, "Delete From OEM Where OEMId='" + Convert.ToInt32(OEM_Data.OEM_Id) + "'");
            //return Convert.ToBoolean(result);

            bool result = false;

            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete From OEM Where OEMId = " + Convert.ToInt32(OEM_Data.OEM_Id) + "",sqlconnection);
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }


    }
}
