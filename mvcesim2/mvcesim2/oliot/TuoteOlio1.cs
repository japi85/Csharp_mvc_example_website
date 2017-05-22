using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace mvc.tietokantaesimerkki
{
     class TuoteOlio1: PerusOlio1
    {
        public bool HaeTuotteet()
        {
            bool ok = true;
            try
            {
                string lause = "select * from tuote;";
                this.komento = new MySqlCommand(lause, this.yhteys);
                this.tulos = this.komento.ExecuteReader();
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // HaeASiakkaat


        public bool LisaaTuote(string tuotenimi, double hinta, int varasto)
        {
            bool ok = true;
            try
            {
                string lause = "insert into tuote " +
                               "(tuotenimi,hinta,varasto) " +
                               "values (?,?,?);";
                this.komento = new MySqlCommand(lause, this.yhteys);

                this.komento.Parameters.Add("@tuotenimi", MySqlDbType.VarChar, 30);
                this.komento.Parameters.Add("@hinta", MySqlDbType.Double);
                this.komento.Parameters.Add("@varasto", MySqlDbType.Int16);


                this.komento.Parameters["@tuotenimi"].Value = tuotenimi;
                this.komento.Parameters["@hinta"].Value = hinta;
                this.komento.Parameters["@varasto"].Value = varasto;


                this.komento.Prepare();
                this.komento.ExecuteNonQuery();
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // LisaaTuote
        
        public bool PaivitaTuote(string tuotenimi, double hinta, int varasto)
        {
            bool ok = true;
            try
            {

                string lause = "update tuote " +
                               "set tuotenimi = @tuotenimi, hinta = @hinta, varasto = @varasto" +
                               "where tuotenumero = @tuotenumero;";
                this.komento = new MySqlCommand(lause, this.yhteys);

                this.komento.Parameters.Add("@tuotenimi", MySqlDbType.VarChar, 30);
                this.komento.Parameters.Add("@hinta", MySqlDbType.Double);
                this.komento.Parameters.Add("@varasto", MySqlDbType.Int16);
                this.komento.Parameters.Add("@tuotenumero", MySqlDbType.Int16);

                this.komento.Parameters["@tuotenimi"].Value = tuotenimi;
                this.komento.Parameters["@hinta"].Value = hinta;
                this.komento.Parameters["@varasto"].Value = varasto;


                this.komento.Prepare();
                this.komento.ExecuteNonQuery();
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // LisaaTuote

    }
}