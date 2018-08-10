using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Interface
{
   public interface IBackbonePageElementIdentifierRepository
    {
        BackbonePageElementIdentifierResponseModel GetBackbonePageElementIdentifierList();
        bool CreateBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier);
        bool UpdateBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier);
        bool DeleteBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier);

    }
}
