using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Entities
{
    public class GlobalAttribute
    {
        private int _IdGlobalAttribute;

        public int IdGlobalAttribute
        {
            get { return _IdGlobalAttribute; }
            set { _IdGlobalAttribute = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Value;

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

    }
}
