using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;

namespace ServicesLibrary.Interfaces
{
    public interface ISiteMapService
    {
        List<SiteMap> GetMenuByIdRole(int ID);

        List<ServicesLibrary.Entities.SiteMap> GetAll();
        
    }
}
