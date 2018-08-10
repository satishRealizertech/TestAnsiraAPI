using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPAClassLibrary.Model;

namespace BPAClassLibrary.Interface
{
    public interface IBackboneRepository
    {
        BackboneResponseModel GetBackboneList();
        bool CreateBackbone(Backbone backbone);
        bool UpdateBackbone(Backbone backbone);
        bool DeleteBackbone(Backbone backbone);

        List<BackboneIdentifier> GetIdentifiersList();
        bool CreateBackboneIdentifier(BackboneIdentifier backboneIdentifier);
        bool UpdateBackboneIdentifier(BackboneIdentifier backboneIdentifier);
        bool DeleteBackboneIdentifier(BackboneIdentifier backboneIdentifier);
    }
}
