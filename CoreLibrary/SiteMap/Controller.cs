using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Interfaces;

namespace CoreLibrary.SiteMap
{
    public class Controller : ISiteMapService
    {
        #region Miembros de ISiteMapService

        public List<ServicesLibrary.Entities.SiteMap> GetMenuByIdRole(int ID)
        {
            return ServiceFactory.GetSiteMapService().GetMenuByIdRole(ID);
        }

        public List<ServicesLibrary.Entities.SiteMap> GetAll()
        {
            return ServiceFactory.GetSiteMapService().GetAll();
        }

        #endregion
    }
}
