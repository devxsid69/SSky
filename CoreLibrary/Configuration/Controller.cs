using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Interfaces;

namespace CoreLibrary.Configuration
{
    public class Controller :IGlobalAttributeService
    {
        #region Miembros de IGlobalAttributeService

        public bool Save(List<ServicesLibrary.Entities.GlobalAttribute> entListConfig,int IdApplication)
        {
            return ServiceFactory.GetConfigurationService().Save(entListConfig, IdApplication);
        }

        public bool Save(ServicesLibrary.Entities.GlobalAttribute entGlobalAtt, int IdApplication)
        {
            return ServiceFactory.GetConfigurationService().Save(entGlobalAtt, IdApplication);
        }

        public List<ServicesLibrary.Entities.GlobalAttribute> GetConfiguration(int IdApplication)
        {
            return ServiceFactory.GetConfigurationService().GetConfiguration(IdApplication);
        }

        public ServicesLibrary.Entities.GlobalAttribute GetCaptchaStatus(int IdApplication)
        {
            return ServiceFactory.GetConfigurationService().GetCaptchaStatus(IdApplication);
        }

        #endregion
    }
}
