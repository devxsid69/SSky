using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Utils;
using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace DataAccessLibrary.Services
{
    public class ConfigurationService :IGlobalAttributeService
    {
        #region Miembros de IConfigurationService

        public bool Save(List<GlobalAttribute> entListConfig, int IdApplication)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            //List<tbl_GlobalAttributes> listConfiguration = context.tbl_GlobalAttributes.ToList();
            try
            {
                switch (IdApplication)
                {
                    case 1:
                        {
                            foreach (GlobalAttribute item in entListConfig)
                            {
                                tbl_GlobalAttributes dbGlobalAttribute = context.tbl_GlobalAttributes.Where(ga => ga.IdAttribute == item.IdGlobalAttribute).FirstOrDefault();
                                //GlobalAttribute entConfig = entListConfig.Where(c => c.IdGlobalAttribute == item.IdAttribute).FirstOrDefault();
                                if (dbGlobalAttribute != null)
                                {
                                    dbGlobalAttribute.Value = item.Value;
                                    context.SubmitChanges();
                                }
                            }
                        }
                        break;
                    case 3:
                        foreach (GlobalAttribute item in entListConfig)
                        {
                            tbl_GlobalAttributesSCM dbGlobalAttribute = context.tbl_GlobalAttributesSCM.Where(ga => ga.IdAttribute == item.IdGlobalAttribute).FirstOrDefault();
                            //GlobalAttribute entConfig = entListConfig.Where(c => c.IdGlobalAttribute == item.IdAttribute).FirstOrDefault();
                            if (dbGlobalAttribute != null)
                            {
                                dbGlobalAttribute.Value = item.Value;
                                context.SubmitChanges();
                            }
                        }
                        break;
                }
                
                
                return true;
            }
            catch { 
            }
            return false;
        }

        public bool Save(GlobalAttribute entGlobalAtt, int IdApplication)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            //List<tbl_GlobalAttributes> listConfiguration = context.tbl_GlobalAttributes.ToList();
            try
            {
                switch (IdApplication)
                {
                    case 1:
                        {

                            tbl_GlobalAttributes dbGlobalAttribute = context.tbl_GlobalAttributes.Where(ga => ga.IdAttribute == entGlobalAtt.IdGlobalAttribute).FirstOrDefault();
                            //GlobalAttribute entConfig = entListConfig.Where(c => c.IdGlobalAttribute == item.IdAttribute).FirstOrDefault();
                            if (dbGlobalAttribute != null)
                            {
                                dbGlobalAttribute.Value = entGlobalAtt.Value;
                                context.SubmitChanges();
                            }

                        }
                        break;
                    case 3:

                        tbl_GlobalAttributesSCM dbGlobalSCMAttribute = context.tbl_GlobalAttributesSCM.Where(ga => ga.IdAttribute == entGlobalAtt.IdGlobalAttribute).FirstOrDefault();
                        //GlobalAttribute entConfig = entListConfig.Where(c => c.IdGlobalAttribute == item.IdAttribute).FirstOrDefault();
                        if (dbGlobalSCMAttribute != null)
                        {
                            dbGlobalSCMAttribute.Value = entGlobalAtt.Value;
                            context.SubmitChanges();
                        }

                        break;
                }


                return true;
            }
            catch
            {
            }
            return false;
        }

        public List<GlobalAttribute> GetConfiguration(int IdApplication)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            List<GlobalAttribute> entListConfig= new List<GlobalAttribute>();            
            switch (IdApplication)
            {
                case 1:
                    {
                        List<tbl_GlobalAttributes> listConfiguration = context.tbl_GlobalAttributes.ToList();
                        foreach (tbl_GlobalAttributes item in listConfiguration)
                        {
                            entListConfig.Add(new GlobalAttribute()
                            {
                                IdGlobalAttribute = item.IdAttribute,
                                Description = item.Description,
                                Name = item.Name,
                                Value = item.Value
                            });
                        }
                        break;
                    }
                case 3:
                    {
                        List<tbl_GlobalAttributesSCM> listConfiguration = context.tbl_GlobalAttributesSCM.Where(gs=> gs.ShowInGrid==true).ToList();
                        foreach (tbl_GlobalAttributesSCM item in listConfiguration)
                        {
                            entListConfig.Add(new GlobalAttribute()
                            {
                                IdGlobalAttribute = item.IdAttribute,
                                Description = item.Description,
                                Name = item.Name,
                                Value = item.Value
                            });
                        }
                        break;
                    }
            }

            return entListConfig;
        }

        public GlobalAttribute GetCaptchaStatus(int IdApplication)
        { 
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            GlobalAttribute gAtt = new GlobalAttribute();
            switch(IdApplication)
            {
            case 1:
                    {
                    }
                    break;
            case 3:
                    {
                        tbl_GlobalAttributesSCM dbAtt = context.tbl_GlobalAttributesSCM.Where(g => g.Name == "Captcha").FirstOrDefault();
                        gAtt = new GlobalAttribute() { 
                            IdGlobalAttribute = dbAtt.IdAttribute,
                            Description = dbAtt.Description,
                            Name = dbAtt.Name
                        };

                    }
                    break;
            }
            if(gAtt ==null)
                gAtt = new GlobalAttribute();
            return gAtt;
        }

        #endregion
    }
}

