using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;

namespace ServicesLibrary.Interfaces
{
    public interface IGlobalAttributeService
    {
        bool Save(List<GlobalAttribute> entListConfig, int IdApplication);

        bool Save(GlobalAttribute entGlobalAtt, int IdApplication);

        List<GlobalAttribute> GetConfiguration(int IdApplication);

        GlobalAttribute GetCaptchaStatus(int IdApplication);
    }
}
