using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
    public class PageTypes
    {
        public int PageId { get; set; }
        public string PageType { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public string CreatedTs { get; set; }
        public string UpdatedTs { get; set; }
        public bool IsActive { get; set; }

    }

    public class BackbonePageType
    {
        public int BackbonePageId { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; }
        public int BackboneId { get; set; }
        public string BackboneName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateTs { get; set; }
        public DateTime UpdateTs { get; set; }
        public bool IsActive { get; set; }

    }
}
