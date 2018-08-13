using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            response.BackboneList = DataAccess.ExecuteSQLGetList<Backbone>(DataAccess.ConnectionStrings.Ansira, "GetAllBackbone");
            return response;
        }
        public bool CreateBackbone(Backbone backbone)
        {
            //List Dictionary object for parameters of Store procedure
            ListDictionary param = new ListDictionary();
            param.Add("BackboneName", backbone.BackboneName);
            param.Add("CreatedBy", backbone.CreatedBy);
            param.Add("CreateTs", backbone.CreateTs);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateBackbone", param);
            return Convert.ToBoolean(result);
        }
        public bool UpdateBackbone(Backbone backbone)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackboneName", backbone.BackboneName);
            param.Add("BackboneId", backbone.BackboneId);
            param.Add("UpdatedBy", backbone.UpdatedBy);
            param.Add("UpdateTs", backbone.UpdateTs);
            param.Add("IsActive", backbone.IsActive);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateBackbone", param);
            return Convert.ToBoolean(result);
        }
        public bool DeleteBackbone(Backbone backbone)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackboneId", backbone.BackboneId);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteBackbone", param);
            return Convert.ToBoolean(result);
        }

        public List<BackboneIdentifier> GetIdentifiersList()
        {
            List<BackboneIdentifier> listBackboneIdentifier = DataAccess.ExecuteSQLGetList<BackboneIdentifier>(DataAccess.ConnectionStrings.Ansira, "GetAllBackboneIdentifier");
            return listBackboneIdentifier;
        }

        public bool CreateBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            ListDictionary param = new ListDictionary();
            param.Add("@BackboneId", backboneIdentifier.BackboneId);
            param.Add("@Type", backboneIdentifier.Type);
            param.Add("@Identifier", backboneIdentifier.Identifier);
            param.Add("@SerialNo", backboneIdentifier.SerialNo);
            param.Add("@Value", backboneIdentifier.Value);
            param.Add("@CreatedBy", backboneIdentifier.CreatedBy);
            param.Add("@CreateTs", backboneIdentifier.CreatedTs);
            param.Add("@Comment", backboneIdentifier.Comment);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateBackboneIdentifiers", param);
            return Convert.ToBoolean(result);
        }

        public bool UpdateBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            ListDictionary param = new ListDictionary();
            param.Add("@BackboneIdentifierId", backboneIdentifier.BackboneIdentifierId);
            param.Add("@BackboneId", backboneIdentifier.BackboneId);
            param.Add("@Type", backboneIdentifier.Type);
            param.Add("@Identifier", backboneIdentifier.Identifier);
            param.Add("@SerialNo", backboneIdentifier.SerialNo);
            param.Add("@Value", backboneIdentifier.Value);
            param.Add("@UpdatedBy", backboneIdentifier.UpdatedBy);
            param.Add("@UpdatedTs", backboneIdentifier.UpdatedTs);
            param.Add("@Comment", backboneIdentifier.Comment);
            param.Add("@IsActive", backboneIdentifier.IsActive);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateBackboneIdentifiers", param);
            return Convert.ToBoolean(result);
        }
        public bool DeleteBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            ListDictionary param = new ListDictionary();
            param.Add("@BackboneIdentifierId", backboneIdentifier.BackboneIdentifierId);
            var result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteBackboneIdentifiers", param);
            return Convert.ToBoolean(result);
        }
    }
}
