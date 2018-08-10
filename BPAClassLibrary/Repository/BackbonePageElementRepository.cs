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
   public class BackbonePageElementRepository: IBackbonePageElementRepository
    {
        public BackbonePageElementResponseModel GetBackbonePageElementList()
        {
            BackbonePageElementResponseModel response = new BackbonePageElementResponseModel();
            List<BackbonePageElement> listpageelement = new List<BackbonePageElement>();
            //DataSet ds = DataAccess.ExecuteSQLGetList<Backbone>(DataAccess.ConnectionStrings.Ansira, "");
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllBackbonePageElement", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            BackbonePageElement backboneelement = new BackbonePageElement();
                            backboneelement.BackbonePageElementId = Convert.ToInt32(sdr["BackbonePageElementId"].ToString());
                            backboneelement.BackbonePageId = Convert.ToInt32(sdr["BackbonePageId"].ToString());
                            backboneelement.PageType = sdr["PageType"].ToString();
                            backboneelement.DataElementName= sdr["DataElementName"].ToString();
                           // backboneelement.BackboneName = sdr["BackboneName"].ToString();
                            backboneelement.DataElementTypeId = Convert.ToInt32(sdr["DataElementTypeId"].ToString());
                            listpageelement.Add(backboneelement);
                        }
                        response.BackbonePageElementList = listpageelement;
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

        public bool CreateBackbonePageElement(BackbonePageElement backbonepageelement)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into BackbonePageElement (BackbonePageId,DataElementTypeId) values (@BackbonePageId,@DataElementTypeId)", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageId", backbonepageelement.BackbonePageId));
                    cmd.Parameters.Add(new SqlParameter("@DataElementTypeId", backbonepageelement.DataElementTypeId));
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

        public bool UpdateBackbonePageElement(BackbonePageElement backbonepageelement)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Update BackbonePageElement set BackbonePageId=@BackbonePageId,DataElementTypeId=@DataElementTypeId where BackbonePageElementId=@BackbonePageElementId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageId",backbonepageelement.BackbonePageId));
                    cmd.Parameters.Add(new SqlParameter("@DataElementTypeId", backbonepageelement.DataElementTypeId));
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageElementId", backbonepageelement.BackbonePageElementId));
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

        public bool DeleteBackbonePageElement(BackbonePageElement backbonepageelement)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from BackbonePageElement where BackbonePageElementId=@BackbonePageElementId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageElementId", backbonepageelement.BackbonePageElementId));
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
