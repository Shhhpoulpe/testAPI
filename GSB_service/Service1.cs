using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB_service
{
    public partial class Service1 : ServiceBase
    {
        private ConnexionSql BDD;
        private GestionDate date;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.BDD = ConnexionSql.getInstance("localhost", "gsb", "root", "");

            BDD.openConnection();
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
    }
}
