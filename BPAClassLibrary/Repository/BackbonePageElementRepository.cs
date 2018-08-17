using BPA.Services;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            response.BackbonePageElementList = DataAccess.ExecuteSQLGetList<BackbonePageElement>(DataAccess.ConnectionStrings.Ansira, "GetAllBackbonePageElement");
            return response;    
        }

        public List<Backbone> GetBackbone()
        {
            var backbone = DataAccess.ExecuteSPGetList<Backbone>(DataAccess.ConnectionStrings.Ansira, "GetPageBackbone");
            return backbone;
        }

        public List<PageTypes> GetBackbonePageType()
        {
            var pageType = DataAccess.ExecuteSPGetList<PageTypes>(DataAccess.ConnectionStrings.Ansira, "");
            return pageType;
        } 

        public bool CreateBackbonePageElement(BackbonePageElement backbonepageelement)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageId", backbonepageelement.BackbonePageId);
            param.Add("DataElementTypeId", backbonepageelement.DataElementTypeId);
            param.Add("CreatedBy", backbonepageelement.CreatedBy);
            param.Add("CreateTs", backbonepageelement.CreateTs);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateBackbonePageElement", param);
            return Convert.ToBoolean(result);
        
       
    }

        public bool UpdateBackbonePageElement(BackbonePageElement backbonepageelement)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageElementId", backbonepageelement.BackbonePageElementId);
            param.Add("BackbonePageId", backbonepageelement.BackbonePageId);
            param.Add("DataElementTypeId", backbonepageelement.DataElementTypeId);
            param.Add("UpdatedBy", backbonepageelement.UpdatedBy);
            param.Add("UpdateTs", backbonepageelement.UpdateTs);
            // param.Add("IsActive", backbonepageelement.IsActive);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateBackbonePageElement", param);
            return Convert.ToBoolean(result);
        }

        public bool DeleteBackbonePageElement(BackbonePageElement backbonepageelement)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageElementId", backbonepageelement.BackbonePageElementId);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteBackbonePageElement", param);
            return Convert.ToBoolean(result);
        }


    }
}
