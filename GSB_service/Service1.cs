using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSBservice
{
    public partial class Service1 : ServiceBase
    {
        private ConnexionSql BDD;

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

        public Service1()
        {
            InitializeComponent();

            this.BDD = ConnexionSql.getInstance("localhost", "gsb", "root", "");

            BDD.openConnection();
        }

        protected override void OnStart(string[] args)
        {        
        }

        protected override void OnStop()
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string mois = getYear().ToString() + getLastMonth().ToString("00");

            if (getDay() >= 20)
            {
                
                MySqlCommand commande = BDD.reqExec("update fichefrais set idEtat = 'RB' where idEtat = 'CL' AND mois='" + mois + "' ");

                commande.ExecuteNonQuery();

            }

            if (getDay() <= 10)
            {

                MySqlCommand commande = BDD.reqExec("update fichefrais set idEtat = 'CL' where mois= '" + mois + "' ");

                commande.ExecuteNonQuery();

            }
        }

        private void eventLog2_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}
