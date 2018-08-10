using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
    public class Dealer
    {
        public int BackboneId { get; set; }
        public string CreatedBy { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerUrl { get; set; }
        public bool IsActive { get; set; }
        public int OEMId { get; set; }
        public string OEMName { get; set; }
        public string BackboneName { get; set; }
       public string UpdatedBy { get; set; }
    }
}
