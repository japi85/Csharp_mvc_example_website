using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace mvc.tietokantaesimerkki

{
    class TilausOlio1 : PerusOlio1
    {
        public bool HaeTilausTiedot()
        {
            bool ok = true;
            try
            {
                //haetaan tilaustiedot
                string lause = "select tilaus.tilausnumero, asiakas.nimi, tilaus.pvm, tilaus.tuotenumero from tilaus INNER JOIN asiakas ON tilaus.tilausnumero = asiakas.asiakasnumero;";
                this.komento = new MySqlCommand(lause, this.yhteys);
                this.tulos = this.komento.ExecuteReader();
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // HaeASiakkaat

        public bool LisaaTilaus(string pvm, int asiakasnumero, int tuotenumero,
                         int maara)
        {
            bool ok = true;
            try
            {
                string lause = "insert into tilaus " +
                               "(pvm,asiakasnumero,tuotenumero,maara) " +
                               "values (?,?,?,?);";
                this.komento = new MySqlCommand(lause, this.yhteys);

                this.komento.Parameters.Add("@pvm", MySqlDbType.VarChar, 30);
                this.komento.Parameters.Add("@asiakasnumero", MySqlDbType.Int16);
                this.komento.Parameters.Add("@tuotenumero", MySqlDbType.Int16);
                this.komento.Parameters.Add("@maara", MySqlDbType.Int16);

                this.komento.Parameters["@pvm"].Value = pvm;
                this.komento.Parameters["@asiakasnumero"].Value = asiakasnumero;
                this.komento.Parameters["@tuotenumero"].Value = tuotenumero;
                this.komento.Parameters["@maara"].Value = maara;


                this.komento.Prepare();
                this.komento.ExecuteNonQuery();
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // LisaaTilaus


    }  // class
}  // namespace