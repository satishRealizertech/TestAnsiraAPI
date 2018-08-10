using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPA.Services;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;

namespace BPAClassLibrary.Repository
{
    public class BackboneRepository : IBackboneRepository
    {
        public BackboneResponseModel GetBackboneList()
        {
            BackboneResponseModel response = new BackboneResponseModel();
            List<Backbone> listBackbone = new List<Backbone>();
            //DataSet ds = DataAccess.ExecuteSQLGetList<Backbone>(DataAccess.ConnectionStrings.Ansira, "");
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllBackbone", sqlconnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Backbone backbonedata = new Backbone();
                            backbonedata.BackboneId= Convert.ToInt32(sdr["BackboneId"].ToString());
                            backbonedata.BackboneName = sdr["BackboneName"].ToString();
                            listBackbone.Add(backbonedata);
                        }
                        response.BackboneList = listBackbone;
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
        public bool CreateBackbone(Backbone backbone)
        {
            bool result=false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Backbone (BackboneName) values (@BackboneName)", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackboneName", backbone.BackboneName));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public bool UpdateBackbone(Backbone backbone)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Update Backbone set BackboneName=@BackboneName where BackboneId=@BackboneId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackboneName", backbone.BackboneName));
                    cmd.Parameters.Add(new SqlParameter("@BackboneId", backbone.BackboneId));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public bool DeleteBackbone(Backbone backbone)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Backbone where BackboneId=@BackboneId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackboneId", backbone.BackboneId));
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

        public List<BackboneIdentifier> GetIdentifiersList()
        {
            //List<BackboneIdentifier> listBackboneIdentifier = DataAccess.ExecuteSQLGetList<BackboneIdentifier>(DataAccess.ConnectionStrings.Ansira, "select * from BackboneIdentifiers");
            List<BackboneIdentifier> listBackboneIdentifier = new List<BackboneIdentifier>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllBackboneIdentifier", sqlconnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            BackboneIdentifier backboneIdentifierdata = new BackboneIdentifier();
                            backboneIdentifierdata.BackboneId = Convert.ToInt32(sdr["BackboneId"].ToString());
                            backboneIdentifierdata.BackboneIdentifierId = Convert.ToInt32(sdr["BackboneIdentifierId"]);
                            backboneIdentifierdata.BackboneName = sdr["BackboneName"].ToString();
                            backboneIdentifierdata.Type = sdr["Type"].ToString();
                            backboneIdentifierdata.Value = sdr["Value"].ToString();
                            backboneIdentifierdata.SerialNo = sdr["SerialNo"].ToString();
                            backboneIdentifierdata.Identifier = sdr["Identifier"].ToString();
                            backboneIdentifierdata.IsActive = Convert.ToBoolean(sdr["IsActive"]);
                            listBackboneIdentifier.Add(backboneIdentifierdata);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return listBackboneIdentifier;
        }

        public bool CreateBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            var result = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into BackboneIdentifiers (BackboneId,Type,Identifier,SerialNo,Value,IsActive) values (@BackboneId,@Type,@Identifier,@SerialNo,@Value,@IsActive)", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackboneId", backboneIdentifier.BackboneId));
                    cmd.Parameters.Add(new SqlParameter("@Type", backboneIdentifier.Type));
                    cmd.Parameters.Add(new SqlParameter("@Identifier", backboneIdentifier.Identifier));
                    cmd.Parameters.Add(new SqlParameter("@SerialNo", backboneIdentifier.SerialNo));
                    cmd.Parameters.Add(new SqlParameter("@Value", backboneIdentifier.Value));
                    //cmd.Parameters.Add(new SqlParameter("@CreatedBy", backboneIdentifier.CreatedBy));
                    //cmd.Parameters.Add(new SqlParameter("@UpdatedBy", backboneIdentifier.UpdatedBy));
                    //cmd.Parameters.Add(new SqlParameter("@CreatedTs", backboneIdentifier.CreatedTs));
                    //cmd.Parameters.Add(new SqlParameter("@UpdatedTs", backboneIdentifier.UpdatedTs));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", backboneIdentifier.IsActive));
                    result = cmd.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return Convert.ToBoolean(result);
        }

        public bool UpdateBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("update BackboneIdentifiers set BackboneId=@BackboneId,Type=@Type,Identifier=@Identifier,SerialNo=@SerialNo,Value=@Value,IsActive=@IsActive where BackboneIdentifierId=@BackboneIdentifierId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackboneId", backboneIdentifier.BackboneId));
                    cmd.Parameters.Add(new SqlParameter("@Type", backboneIdentifier.Type));
                    cmd.Parameters.Add(new SqlParameter("@Identifier", backboneIdentifier.Identifier));
                    cmd.Parameters.Add(new SqlParameter("@SerialNo", backboneIdentifier.SerialNo));
                    cmd.Parameters.Add(new SqlParameter("@Value", backboneIdentifier.Value));
                    //cmd.Parameters.Add(new SqlParameter("@CreatedBy", backboneIdentifier.CreatedBy));
                    //cmd.Parameters.Add(new SqlParameter("@UpdatedBy", backboneIdentifier.UpdatedBy));
                    //cmd.Parameters.Add(new SqlParameter("@CreatedTs", backboneIdentifier.CreatedTs));
                    //cmd.Parameters.Add(new SqlParameter("@UpdatedTs", backboneIdentifier.UpdatedTs));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", backboneIdentifier.IsActive));
                    cmd.Parameters.Add(new SqlParameter("@BackboneIdentifierId", backboneIdentifier.BackboneIdentifierId));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public bool DeleteBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from BackboneIdentifiers where BackboneIdentifierId=@BackboneIdentifierId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackboneIdentifierId", backboneIdentifier.BackboneIdentifierId));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
