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
using BPA.Services;
using System.Collections.Specialized;

namespace BPAClassLibrary.Repository
{
    public class PageTypeRepository : IPageTypeRepository
    {
        public List<PageTypes> GetPageType()
        {
            List<PageTypes> listPageTypes = DataAccess.ExecuteSPGetList<PageTypes>(DataAccess.ConnectionStrings.Ansira, "GetAllPageTypes");            
            return listPageTypes;
        }

        public bool CreatePageType(PageTypes pageTypeData)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("PageType", pageTypeData.PageType);
            param.Add("CreatedBy", pageTypeData.CreatedBy);
            param.Add("UpdatedBy", pageTypeData.UpdateBy);
            param.Add("CreateTs", null);
            param.Add("UpdateTs", null);
            int Id = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreatePageType", param);
            return Convert.ToBoolean(Id);
        }

        public bool UpdatePageType(PageTypes pageTypeData)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("PageId", pageTypeData.PageId);
            param.Add("PageType", pageTypeData.PageType);
            param.Add("UpdatedBy", pageTypeData.UpdateBy);
            param.Add("IsActive", pageTypeData.IsActive);
            int Id = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdatePageType", param);
            return Convert.ToBoolean(Id);
        }
        public bool DeletePageType(PageTypes pageTypeData)
        {
            ListDictionary param = new ListDictionary();
            param.Add("PageId", pageTypeData.PageId);
            int Id = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeletePageType", param);
            return Convert.ToBoolean(Id);
        }

        public List<BackbonePageType> GetBackbonePageType()
        {
            List<BackbonePageType> listBackbonePageTypes = DataAccess.ExecuteSPGetList<BackbonePageType>(DataAccess.ConnectionStrings.Ansira, "GetAllBackbonePageType");
            return listBackbonePageTypes;
        }

        public bool CreateBackbonePage(BackbonePageType backbonePage)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("PageId", backbonePage.PageId);
            param.Add("BackboneId", backbonePage.BackboneId);
            param.Add("CreatedBy", backbonePage.CreatedBy);
            int res = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateBackbonePage",param);
            return Convert.ToBoolean(res);
        }

        public bool UpdateBackbonePage(BackbonePageType backbonePage)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageId", backbonePage.BackbonePageId);
            param.Add("PageId", backbonePage.PageId);
            param.Add("BackboneId", backbonePage.BackboneId);
            param.Add("UpdatedBy", backbonePage.UpdatedBy);
            param.Add("IsActive", backbonePage.IsActive);
            int res = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateBackbonePage", param);
            return Convert.ToBoolean(res);
        }
        public bool DeleteBackbonePage(BackbonePageType backbonePage)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageId", backbonePage.BackbonePageId);
            int res = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteBackbonePage", param);
            return Convert.ToBoolean(res);
        }
    }
}
