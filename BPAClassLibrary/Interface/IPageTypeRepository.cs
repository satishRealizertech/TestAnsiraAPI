using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPAClassLibrary.Model;

namespace BPAClassLibrary.Interface
{
    public interface IPageTypeRepository
    {
        List<PageTypes> GetPageType();
        bool CreatePageType(PageTypes pageTypeData);
        bool UpdatePageType(PageTypes pageTypeData);
        bool DeletePageType(PageTypes pageTypeData);

        List<BackbonePageType> GetBackbonePageType();
        bool CreateBackbonePage(BackbonePageType backbonePage);
        bool UpdateBackbonePage(BackbonePageType backbonePage);
        bool DeleteBackbonePage(BackbonePageType backbonePage);
    }
}
