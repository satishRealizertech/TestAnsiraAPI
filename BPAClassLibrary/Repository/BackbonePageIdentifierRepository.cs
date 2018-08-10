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
   public class BackbonePageIdentifierRepository: IBackbonePageIdentifierRepository
    {
        public BackbonePageIdentifierResponseModel GetBackbonePageIdentifierList()
        {
            BackbonePageIdentifierResponseModel response = new BackbonePageIdentifierResponseModel();
            List<BackbonePageIdentifier> listpageidentifier = new List<BackbonePageIdentifier>();
            //DataSet ds = DataAccess.ExecuteSQLGetList<Backbone>(DataAccess.ConnectionStrings.Ansira, "");
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllBackbonePageIdentifier", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            BackbonePageIdentifier backboneidentifier = new BackbonePageIdentifier();
                            backboneidentifier.BackbonePageIdentifierId = Convert.ToInt32(sdr["BackbonePageIdentifierId"].ToString());
                            backboneidentifier.BackboneId = Convert.ToInt32(sdr["BackboneId"].ToString());
                            backboneidentifier.BackbonePageId = Convert.ToInt32(sdr["BackbonePageId"].ToString());
                            backboneidentifier.BackboneName = sdr["BackboneName"].ToString();
                            backboneidentifier.PageType= sdr["PageType"].ToString();
                            backboneidentifier.Type =sdr["Type"].ToString();
                            backboneidentifier.Identifier = sdr["Identifier"].ToString();
                            backboneidentifier.SerialNo = Convert.ToInt32(sdr["SerialNo"].ToString());
                            backboneidentifier.IsActive = Convert.ToBoolean(sdr["IsActive"].ToString());
                            backboneidentifier.Value = sdr["Value"].ToString();
                            listpageidentifier.Add(backboneidentifier);
                        }
                        response.BackbonePageIdentifierList = listpageidentifier;
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

        public bool CreateBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {

                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into BackbonePageIdentifiers (BackbonePageIdentifierId,BackboneId,BackbonePageId,Type,Identifier,SerialNo,IsActive,Value) values (@BackbonePageIdentifierId,@BackboneId,@BackbonePageId,@Type,@Identifier,@SerialNo,@IsActive,@Value)", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageIdentifierId", backbonepageidentifier.BackbonePageIdentifierId));
                    cmd.Parameters.Add(new SqlParameter("@BackboneId", backbonepageidentifier.BackboneId));
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageId", backbonepageidentifier.BackbonePageId));
                    cmd.Parameters.Add(new SqlParameter("@Type", backbonepageidentifier.Type));
                    cmd.Parameters.Add(new SqlParameter("@Identifier", backbonepageidentifier.Identifier));
                    cmd.Parameters.Add(new SqlParameter("@SerialNo", backbonepageidentifier.SerialNo));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", true));
                    cmd.Parameters.Add(new SqlParameter("@Value", backbonepageidentifier.Value));
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

        public bool UpdateBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Update BackbonePageIdentifiers set BackboneId=@BackboneId,BackbonePageId=@BackbonePageId,Type=@Type,Identifier=@Identifier,SerialNo=@SerialNo,IsActive=@IsActive,Value=@Value where BackbonePageIdentifierId=@BackbonePageIdentifierId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageIdentifierId", backbonepageidentifier.BackbonePageIdentifierId));
                    cmd.Parameters.Add(new SqlParameter("@BackboneId", backbonepageidentifier.BackboneId));
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageId", backbonepageidentifier.BackbonePageId));
                    cmd.Parameters.Add(new SqlParameter("@Type", backbonepageidentifier.Type));
                    cmd.Parameters.Add(new SqlParameter("@Identifier", backbonepageidentifier.Identifier));
                    cmd.Parameters.Add(new SqlParameter("@SerialNo", backbonepageidentifier.SerialNo));
                    cmd.Parameters.Add(new SqlParameter("@IsActive",true));
                    cmd.Parameters.Add(new SqlParameter("@Value", backbonepageidentifier.Value));
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

        public bool DeleteBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from BackbonePageIdentifiers where BackbonePageIdentifierId=@BackbonePageIdentifierId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageIdentifierId",Convert.ToInt32(backbonepageidentifier.BackbonePageIdentifierId)));
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
