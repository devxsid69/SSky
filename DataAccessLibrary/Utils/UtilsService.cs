using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccessLibrary.Utils
{
    public class UtilsService
    {
        public bool HasData(DataSet dsData)
        {
            if (dsData.Tables.Count > 0)
                if (dsData.Tables[0].Rows.Count > 0)
                    return true;

            return false;
        }
    }
}
