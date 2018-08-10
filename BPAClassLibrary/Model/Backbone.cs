using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
    public class Backbone
    {
        public int BackboneId { get; set; }
        public string BackboneName { get; set; }
    }
    public class BackboneResponseModel
    {
        public string Success { get; set; }
        public string Error { get; set; }
        public List<Backbone> BackboneList { get; set; }
    }
    public class BackboneIdentifier
    {
        public int BackboneIdentifierId { get; set; }
        public int BackboneId { get; set; }
        public string BackboneName { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; }
        public string SerialNo { get; set; }
        public string Value { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedTs { get; set; }
        public DateTime UpdatedTs { get; set; }
        public bool IsActive { get; set; }
    }
}
