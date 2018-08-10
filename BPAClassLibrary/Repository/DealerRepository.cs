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

namespace BPAClassLibrary.Repository
{
   public class DealerRepository: IDealerRepository
    {
      public IList<Dealer> GetDealerData()
        {
            List<Dealer> dealer = new List<Dealer>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllDealerDetails", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Dealer dealer_data = new Dealer();
                            dealer_data.DealerId = Convert.ToInt32(sdr[0].ToString());
                            dealer_data.DealerName = sdr[1].ToString();
                            dealer_data.DealerUrl = sdr[2].ToString();
                            dealer_data.OEMId = Convert.ToInt32(sdr[3].ToString());
                            dealer_data.BackboneId = Convert.ToInt32(sdr[4].ToString());
                            dealer_data.CreatedBy = sdr[5].ToString();
                            dealer_data.UpdatedBy = sdr[6].ToString();
                            dealer_data.BackboneName = sdr["BackboneName"].ToString();
                            dealer_data.OEMName = sdr["OEMName"].ToString();
                            dealer_data.IsActive= Convert.ToBoolean(sdr[9].ToString());
                            dealer.Add(dealer_data);

                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return dealer;
        }

        public bool CreateDealer(Dealer dealer_Data)
        {
            //var result = DataAccess.ExecuteSQLNonQuery(DataAccess.ConnectionStrings.Ansira, "Insert into OEM (OEMName) values (" + OEM_Data.OEM_Name + ")");
            //return Convert.ToBoolean(result);
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Dealer (DealerName,DealerUrl,OEMId,BackboneId,IsActive) Values('" + dealer_Data.DealerName + "','" + dealer_Data.DealerUrl + "','" + dealer_Data.OEMId + "','" + dealer_Data.BackboneId + "','"+true+"')", sqlconnection);
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


        public bool UpdateDealer(Dealer dealer_Data)
        {
            //var result = DataAccess.ExecuteSQLNonQuery(DataAccess.ConnectionStrings.Ansira, "Update OEM SET OEMName='"+ OEM_Data.OEM_Name+ "' Where OEMId='" + Convert.ToInt32(OEM_Data.OEM_Id) + "'");
            //return Convert.ToBoolean(result);

            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Update Dealer SET DealerName = '" + dealer_Data.DealerName + "',DealerUrl = '" + dealer_Data.DealerUrl + "',OEMId = " + Convert.ToInt32(dealer_Data.OEMId) + ",BackboneId = " + Convert.ToInt32(dealer_Data.BackboneId) + " Where DealerId = " + Convert.ToInt32(dealer_Data.DealerId) + "", sqlconnection);
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

        public bool DeleteDealer(Dealer dealer_Data)
        {
            //var result = DataAccess.ExecuteSQLNonQuery(DataAccess.ConnectionStrings.Ansira, "Delete From OEM Where OEMId='" + Convert.ToInt32(OEM_Data.OEM_Id) + "'");
            //return Convert.ToBoolean(result);

            bool result = false;

            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete From Dealer Where DealerId = " + Convert.ToInt32(dealer_Data.DealerId) + "", sqlconnection);
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
