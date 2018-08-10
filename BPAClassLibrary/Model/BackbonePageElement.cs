using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
   public class BackbonePageElement
    {
        public int BackbonePageElementId { get; set; }
        public int BackbonePageId { get; set;}
        public string PageType { get; set; }
        public int DataElementTypeId { get; set; }
        public string DataElementName { get; set; }
        public string  CreatedBy { get; set; }
        public string BackboneName { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateTs { get; set; }
        public DateTime UpdateTs { get; set; }
        public bool IsActive { get; set; }
    }

    public class BackbonePageElementResponseModel
    {
        public string Success { get; set; }
        public string Error { get; set; }
        public List<BackbonePageElement> BackbonePageElementList { get; set; }
    }
}
