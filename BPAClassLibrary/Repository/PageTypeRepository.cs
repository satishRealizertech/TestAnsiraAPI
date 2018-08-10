using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System.Data;

namespace BPAClassLibrary.Repository
{
    public class PageTypeRepository : IPageTypeRepository
    {
        public List<PageTypes> GetPageType()
        {
            //List<BackboneIdentifier> listBackboneIdentifier = DataAccess.ExecuteSQLGetList<BackboneIdentifier>(DataAccess.ConnectionStrings.Ansira, "select * from BackboneIdentifiers");
            List<PageTypes> listPageTypes= new List<PageTypes>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllPageTypes", sqlconnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            PageTypes backboneIdentifierdata = new PageTypes();
                            backboneIdentifierdata.PageId = Convert.ToInt32(sdr["PageId"].ToString());
                            backboneIdentifierdata.PageType = sdr["PageType"].ToString();
                            backboneIdentifierdata.IsActive = Convert.ToBoolean(sdr["IsActive"]);
                            listPageTypes.Add(backboneIdentifierdata);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return listPageTypes;
        }

        public bool CreatePageType(PageTypes pageTypeData)
        {
            var result = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into PageType (PageType,IsActive) values (@PageType,@IsActive)", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@PageType", pageTypeData.PageType));
                    //cmd.Parameters.Add(new SqlParameter("@CreatedBy", pageTypeData.CreatedBy));
                    //cmd.Parameters.Add(new SqlParameter("@CreateTs", pageTypeData.CreatedTs));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", true));
                    result = cmd.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return Convert.ToBoolean(result);
        }

        public bool UpdatePageType(PageTypes pageTypeData)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("update PageType set PageType=@PageType where PageId=@PageId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@PageId", pageTypeData.PageId));
                    cmd.Parameters.Add(new SqlParameter("@PageType", pageTypeData.PageType));
                    //cmd.Parameters.Add(new SqlParameter("@UpdatedBy", pageTypeData.CreatedBy));
                    //cmd.Parameters.Add(new SqlParameter("@UpdateTs", pageTypeData.CreatedTs));
                    //cmd.Parameters.Add(new SqlParameter("@IsActive", pageTypeData.IsActive));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public bool DeletePageType(PageTypes pageTypeData)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from PageType where PageId=@PageId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@PageId", pageTypeData.PageId));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public List<BackbonePageType> GetBackbonePageType()
        {
            List<BackbonePageType> listBackbonePageTypes = new List<BackbonePageType>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllBackbonePageType", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            BackbonePageType backbonePageType = new BackbonePageType();
                            backbonePageType.PageId = Convert.ToInt32(sdr["PageId"].ToString());
                            backbonePageType.BackboneId = Convert.ToInt32(sdr["BackboneId"]);
                            backbonePageType.BackboneName = sdr["BackboneName"].ToString();
                            backbonePageType.PageName = sdr["PageType"].ToString();
                            backbonePageType.BackbonePageId= Convert.ToInt32(sdr["BackbonePageId"]);
                            backbonePageType.IsActive = Convert.ToBoolean(sdr["IsActive"]);
                            listBackbonePageTypes.Add(backbonePageType);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return listBackbonePageTypes;
        }

        public bool CreateBackbonePage(BackbonePageType backbonePage)
        {
            var result = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into BackbonePage (PageId,BackboneId,IsActive) values (@PageId,@BackboneId,@IsActive)", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@PageId", backbonePage.PageId));
                    cmd.Parameters.Add(new SqlParameter("@BackboneId", backbonePage.BackboneId));
                    //cmd.Parameters.Add(new SqlParameter("@CreatedBy", pageTypeData.CreatedBy));
                    //cmd.Parameters.Add(new SqlParameter("@CreateTs", pageTypeData.CreatedTs));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", true));
                    result = cmd.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return Convert.ToBoolean(result);
        }

        public bool UpdateBackbonePage(BackbonePageType backbonePage)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("update BackbonePage set PageId=@PageId,BackboneId=@BackboneId where BackbonePageId=@BackbonePageId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@PageId", backbonePage.PageId));
                    cmd.Parameters.Add(new SqlParameter("@BackboneId", backbonePage.BackboneId));
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageId", backbonePage.BackbonePageId));
                    //cmd.Parameters.Add(new SqlParameter("@UpdatedBy", pageTypeData.CreatedBy));
                    //cmd.Parameters.Add(new SqlParameter("@UpdateTs", pageTypeData.CreatedTs));
                    //cmd.Parameters.Add(new SqlParameter("@IsActive", pageTypeData.IsActive));
                    result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public bool DeleteBackbonePage(BackbonePageType backbonePage)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ansira"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from BackbonePage where BackbonePageId=@BackbonePageId", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@BackbonePageId", backbonePage.BackbonePageId));
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
