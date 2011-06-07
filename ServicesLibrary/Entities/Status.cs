using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    [Serializable]
    public class Status
    {
        private int _IdStatus;

        public int IdStatus
        {
            get { return _IdStatus; }
            set { _IdStatus = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
