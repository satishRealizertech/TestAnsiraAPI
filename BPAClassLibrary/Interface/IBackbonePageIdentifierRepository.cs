using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Interface
{
   public interface IBackbonePageIdentifierRepository
    {
        BackbonePageIdentifierResponseModel GetBackbonePageIdentifierList();
        bool CreateBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier);
        bool UpdateBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier);
        bool DeleteBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier);

    }
}
