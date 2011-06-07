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
    public class CommentService :ICommentService
    {
        #region Functions
        private bool Insert(Comment entComment)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            try
            {
                tbl_Comments dbComment = new tbl_Comments() { 
                    Comment = entComment.CommentSuggestion,
                    CreatedOn = DateTime.Now,
                    Email = entComment.Email,
                    Name = entComment.Name,
                    SupervisorRating = entComment.SupervisorRating,
                    CompanyOpinionRating = entComment.CompanyOpinionRating,
                    WorkEnviromentRating = entComment.WorkEnviromentRating,
                    CompanyWorking = entComment.CompanyWorking,
                    GroupDirectorRating = entComment.GroupDirectorRating,
                    SecurityRating = entComment.SecurityRating,                    
                    Subject = entComment.Subject,
                    IsRead = false
                };

                context.tbl_Comments.InsertOnSubmit(dbComment);
                context.SubmitChanges();
                return true;
            }
            catch
            {
            }

            return false;
        }
        #endregion
        #region Miembros de ICommentService

        public bool Save(Comment entComment)
        {
            if (entComment != null)
            {
                if (entComment.IdComment == 0)
                    return Insert(entComment);
            }
            return false;
        }

        public int GetAllCommentsCount()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public int GetAllCommentsByFilterCount(string Company,DateTime StartDate, DateTime EndDate, string IsRead)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllCommentsByFilter(string slCompany,DateTime StartDate, DateTime EndDate, string IsRead)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            
            List<tbl_Comments> dbListComments = new List<tbl_Comments>();
            switch(IsRead)
            {
                case "-1":
                    dbListComments = context.tbl_Comments.Where(s => s.CreatedOn >= StartDate && s.CreatedOn <= EndDate.AddDays(1)  ).ToList();
                    break;
                case "1":
                    dbListComments = context.tbl_Comments.Where(s => s.CreatedOn >= StartDate && s.CreatedOn <= EndDate.AddDays(1) && s.IsRead == true).ToList();
                    break;
                case "0":
                    dbListComments = context.tbl_Comments.Where(s => s.CreatedOn >= StartDate && s.CreatedOn <= EndDate.AddDays(1) && s.IsRead== false).ToList();
                    break;

            }
            if(slCompany!= "Todas")
                dbListComments = dbListComments.Where(c => c.CompanyWorking == slCompany).ToList();

            
            //List<tbl_Comments> dbListComments = context.tbl_Comments.ToList();
            List<Comment> entListComments = new List<Comment>();

            foreach (var item in dbListComments)
            { 
                entListComments.Add( new Comment()
                {
                    IdComment = item.IdComment,
                    Name = item.Name,
                    Email = item.Email,
                    CommentSuggestion = item.Comment,
                    CreatedOn = item.CreatedOn,
                    Subject = item.Subject,
                    SupervisorRating = item.SupervisorRating,
                    CompanyOpinionRating= item.CompanyOpinionRating,
                    WorkEnviromentRating = item.WorkEnviromentRating,
                    CompanyWorking = item.CompanyWorking,
                    GroupDirectorRating = item.GroupDirectorRating,
                    SecurityRating = item.SecurityRating,                    
                    IsRead = item.IsRead
                });
            }
            return entListComments;
        }

        public bool MarkAsRead(int IdComment)
        {
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            tbl_Comments dbComment = context.tbl_Comments.Where(c => c.IdComment == IdComment).FirstOrDefault();
            if (dbComment!=null)
            {
                dbComment.IsRead = true;
                context.SubmitChanges();
                return true;
            }
            return false;


        }

        public Comment GetCommentByID(int IdComment)
        { 
            TCRepositoryDataContext context = DataBaseUtils.GetContext();
            tbl_Comments dbComment = context.tbl_Comments.Where(c => c.IdComment == IdComment).FirstOrDefault();
            if (dbComment != null)
            {
                Comment EntComment = new Comment()
                    {
                        IdComment = dbComment.IdComment,
                        Name = dbComment.Name,
                        Email = dbComment.Email,
                        CommentSuggestion = dbComment.Comment,
                        CreatedOn = dbComment.CreatedOn,
                        Subject = dbComment.Subject,
                        SupervisorRating = dbComment.SupervisorRating,
                        CompanyOpinionRating = dbComment.CompanyOpinionRating,
                        WorkEnviromentRating = dbComment.WorkEnviromentRating,
                        CompanyWorking = dbComment.CompanyWorking,
                        GroupDirectorRating = dbComment.GroupDirectorRating,
                        SecurityRating = dbComment.SecurityRating,
                        IsRead = dbComment.IsRead
                    };
                return EntComment;
            }
            return new Comment();
        }

        #endregion
    }
}
