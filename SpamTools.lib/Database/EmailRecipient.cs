using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTools.lib.Database
{
    public partial class EmailRecipient : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name": if (columnName.Length < 3) return $"Имя {columnName} имеет длину меньше 3 символов."; break;
                }

                return "";
            }
        }

        public string Error => "";
    }
}
