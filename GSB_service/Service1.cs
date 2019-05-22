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

        GestionDate date = new GestionDate();

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
            string mois = date.getYear().ToString() + date.getLastMonth().ToString("00");

            if (date.getDay() >= 20)
            {
                
                MySqlCommand commande = BDD.reqExec("update fichefrais set idEtat = 'RB' where idEtat = 'CL' AND mois='" + mois + "' ");

                commande.ExecuteNonQuery();

            }

            if (date.getDay() <= 10)
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
