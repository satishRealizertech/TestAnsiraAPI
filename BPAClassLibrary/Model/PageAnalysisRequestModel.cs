using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BPAClassLibrary.Model
{
    public class PageAnalysisRequestModel
    {
        public BPA.Core.Domain.Dealer dealer { get; set; }
        public int PageId { get; set; }
    }
}
