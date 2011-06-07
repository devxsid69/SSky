using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    public class Comment
    {
        private int _IdComment;

        public int IdComment
        {
            get { return _IdComment; }
            set { _IdComment = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _Subject;

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        private string _CommentSuggestion;

        public string CommentSuggestion
        {
            get { return _CommentSuggestion; }
            set { _CommentSuggestion = value; }
        }

        private DateTime _CreatedOn;

        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }

        private bool _IsRead;

        public bool IsRead
        {
            get { return _IsRead; }
            set { _IsRead = value; }
        }
        private string _CompanyWorking;

        public string CompanyWorking
        {
            get { return _CompanyWorking; }
            set { _CompanyWorking = value; }
        }
        private string _SecurityRating;

        public string SecurityRating
        {
            get { return _SecurityRating; }
            set { _SecurityRating = value; }
        }
        private string _CompanyOpinionRating;

        public string CompanyOpinionRating
        {
            get { return _CompanyOpinionRating; }
            set { _CompanyOpinionRating = value; }
        }
        private string _SupervisorRating;

        public string SupervisorRating
        {
            get { return _SupervisorRating; }
            set { _SupervisorRating = value; }
        }
        private string _GroupDirectorRating;

        public string GroupDirectorRating
        {
            get { return _GroupDirectorRating; }
            set { _GroupDirectorRating = value; }
        }
        private string _WorkEnviromentRating;

        public string WorkEnviromentRating
        {
            get { return _WorkEnviromentRating; }
            set { _WorkEnviromentRating = value; }
        }

    }
}
