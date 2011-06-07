using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;
using DataAccessLibrary;
using DataAccessLibrary.Services;
using DataAccessLibrary.Security;

namespace CoreLibrary
{
    public class ServiceFactory
    {
        public static IMembershipService GetMembershipService()
        {
            return new MembershipService();
        }
        public static IRoleService GetRoleService()
        {
            return new RoleService();
        }
        public static ISiteMapService GetSiteMapService()
        {
            return new SiteMapService();
        }
        public static IStatusService GetStatusService()
        {
            return new StatusService();
        }
        public static ITicketService GetTicketService()
        {
            return new TicketService();
        }
        public static ICompanyService GetCompanyService()
        {
            return new CompanyService();
        }
        public static ICategoryService GetCategoryService()
        {
            return new CategoryService();
        }
        public static IGlobalAttributeService GetConfigurationService()
        {
            return new ConfigurationService();
        }
        public static ICommentService GetCommentService()
        {
            return new CommentService();
        }
    }
}
