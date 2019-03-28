using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_service
{
    class GestionDate
    {
        System.DateTime date = DateTime.Now;

        public int getMonth()
        {
            return date.Month;
        }

        public int getLastMonth()
        {
            if (date.Month - 1 != 0)
            {
                return date.Month - 1;
            }
            else
            {
                return 12;
            }
        }

        public int getDay()
        {
            return date.Day;
        }

        public int getYear()
        {
            if (getLastMonth() != 12)
            {
                return date.Year;
            }
            else
            {
                return date.Year - 1;
            }

        }
    }
}
