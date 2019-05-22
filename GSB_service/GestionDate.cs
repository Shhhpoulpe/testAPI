using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBservice
{
    class GestionDate
    {
        System.DateTime date = DateTime.Now;

        /**
         * Création de l'objet GestionDate
         */
        public GestionDate()
        {
            this.date = DateTime.Now;
        }

        /**
         * Retourne le mois
         */

        public int getMonth()
        {
            return date.Month;
        }

        /**
         * Retourne le mois dernier
         */

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

        /**
         * Retourne le jour
         */

        public int getDay()
        {
            return date.Day;
        }

        /**
         * Retourne l'année précédente
         */

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
