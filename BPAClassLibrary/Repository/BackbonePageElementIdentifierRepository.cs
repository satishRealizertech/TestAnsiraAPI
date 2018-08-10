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
  public  class BackbonePageElementIdentifierRepository: IBackbonePageElementIdentifierRepository
    {
        public BackbonePageElementIdentifierResponseModel GetBackbonePageElementIdentifierList()
        {
            BackbonePageElementIdentifierResponseModel response = new BackbonePageElementIdentifierResponseModel();
            List<BackbonePageElementIdentifier> listpageidentifier = new List<BackbonePageElementIdentifier>();
            //DataSet ds = DataAccess.ExecuteSQLGetList<Backbone>(DataAccess.ConnectionStrings.Ansira, "");
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllBackbonePageElementIdentifiers", sqlconnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            BackbonePageElementIdentifier pageelementidentifier = new BackbonePageElementIdentifier();
                            pageelementidentifier.BackbonePageElementIdentifierId = Convert.ToInt32(sdr["BackbonePageElementIdentifierId"].ToString());
                            pageelementidentifier.BackbonePageElementId = Convert.ToInt32(sdr["BackbonePageElementId"].ToString());
                            pageelementidentifier.BackbonePageId = Convert.ToInt32(sdr["BackbonePageId"].ToString());
                            pageelementidentifier.Type = sdr["Type"].ToString();
                            pageelementidentifier.PageType = sdr["PageType"].ToString();
                            pageelementidentifier.DataElementName = sdr["DataElementName"].ToString();
                            pageelementidentifier.BackboneName= sdr["BackboneName"].ToString();
                            pageelementidentifier.Identifier = sdr["Identifier"].ToString();
                            pageelementidentifier.SerialNo = Convert.ToInt32(sdr["SerialNo"].ToString());
                            pageelementidentifier.IsActive = Convert.ToBoolean(sdr["IsActive"].ToString());
                            pageelementidentifier.Value = sdr["Value"].ToString();
                            listpageidentifier.Add(pageelementidentifier);
                        }
                        response.BackbonePageElementIdentifierList = listpageidentifier;
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
        public bool CreateBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into BackbonePageElementIdentifiers (BackbonePageElementId,BackbonePageId,Type,Identifier,SerialNo,IsActive,Value) values (@BackbonePageElementId,@BackbonePageId,@Type,@Identifier,@SerialNo,@IsActive,@Value)", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageElementId", backbonepageidentifier.BackbonePageElementId));
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
        public bool UpdateBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Update BackbonePageElementIdentifiers set BackbonePageElementId=@BackbonePageElementId,BackbonePageId=@BackbonePageId,Type=@Type,Identifier=@Identifier,SerialNo=@SerialNo,IsActive=@IsActive,Value=@Value where BackbonePageElementIdentifierId=@BackbonePageElementIdentifierId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageElementIdentifierId", backbonepageidentifier.BackbonePageElementIdentifierId));
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageElementId", backbonepageidentifier.BackbonePageElementId));
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
        public bool DeleteBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from BackbonePageElementIdentifiers where BackbonePageElementIdentifierId=@BackbonePageElementIdentifierId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageElementIdentifierId", backbonepageidentifier.BackbonePageElementIdentifierId));
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
