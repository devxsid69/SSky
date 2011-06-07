using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;
[assembly: System.Security.AllowPartiallyTrustedCallers]
namespace CoreLibrary.Comment
{
    public class Controller:ICommentService
    {
        #region Miembros de ICommentService

        public bool Save(ServicesLibrary.Entities.Comment entComment)
        {
            return ServiceFactory.GetCommentService().Save(entComment);
        }

        public int GetAllCommentsCount()
        {
            return ServiceFactory.GetCommentService().GetAllCommentsCount();
        }

        public List<ServicesLibrary.Entities.Comment> GetAllComments()
        {
            return ServiceFactory.GetCommentService().GetAllComments();
        }

        public int GetAllCommentsByFilterCount(string slCompany, DateTime StartDate, DateTime EndDate, string IsRead)
        {
            return ServiceFactory.GetCommentService().GetAllCommentsByFilterCount(slCompany, StartDate, EndDate, IsRead);
        }

        public List<ServicesLibrary.Entities.Comment> GetAllCommentsByFilter(string slCompany, DateTime StartDate, DateTime EndDate, string IsRead)
        {
            return ServiceFactory.GetCommentService().GetAllCommentsByFilter(slCompany, StartDate, EndDate, IsRead);
        }

        public bool MarkAsRead(int IdComment)
        {
            return ServiceFactory.GetCommentService().MarkAsRead(IdComment);
        }

        public ServicesLibrary.Entities.Comment GetCommentByID(int IdComment)
        {
            return ServiceFactory.GetCommentService().GetCommentByID(IdComment);
        }

        #endregion
    }
}
