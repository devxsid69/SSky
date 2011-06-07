using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;
using ServicesLibrary.Interfaces;

namespace ServicesLibrary.Interfaces
{
    public interface ICommentService
    {
        bool Save(Comment entComment);

        int GetAllCommentsCount();
        List<Comment> GetAllComments();

        int GetAllCommentsByFilterCount(string Company, DateTime StartDate, DateTime EndDate, string IsRead);
        List<Comment> GetAllCommentsByFilter(string slCompany, DateTime StartDate, DateTime EndDate, string IsRead);

        bool MarkAsRead(int IdComment);

        Comment GetCommentByID(int IdComment);
    }
}
