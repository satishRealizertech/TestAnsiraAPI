using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Interface
{
   public interface IBackbonePageElementRepository
    {
        BackbonePageElementResponseModel GetBackbonePageElementList();
        bool CreateBackbonePageElement(BackbonePageElement backbonepageelement);
        bool UpdateBackbonePageElement(BackbonePageElement backbonepageelement);
        bool DeleteBackbonePageElement(BackbonePageElement backbonepageelement);
    }
}
