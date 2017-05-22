using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tämä jos MySQL Connector NET
// Muista References MySql.Data
using MySql.Data.MySqlClient;

namespace mvc.tietokantaesimerkki
{
    class PerusOlio1
    {
        // Ominaisuudet
        protected MySqlConnection yhteys = null;
        protected MySqlCommand komento = null;
        protected MySqlDataReader tulos = null;

        public MySqlDataReader GetTulos()
        {
            return this.tulos;
        }  // GetTulos

        // Metodit
        public bool AvaaYhteys(string ktunnus,string sala)
        {
            bool ok = true;
            try
            {
                string yhteysjono = @"server=localhost;userid=" +
                              ktunnus + ";password=" + sala + 
                              ";database=winkanta2";
                this.yhteys = new MySqlConnection(yhteysjono);
                this.yhteys.Open();
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // AvaaYhtys

        public bool SuljeYhteys()
        {
            bool ok = true;
            try
            {
                if (this.yhteys != null)
                {
                    this.yhteys.Close();
                }  // if
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // SuljeYhteys
    } // class
}  // namespace
