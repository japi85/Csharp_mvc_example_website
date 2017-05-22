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
    class AsiakasOlio1:PerusOlio1
    {
        public bool HaeAsiakkaat()
        {
            bool ok = true;
            try
            {
                string lause = "select * from asiakas order by nimi asc;";
                this.komento = new MySqlCommand(lause, this.yhteys);
                this.tulos = this.komento.ExecuteReader();
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // HaeASiakkaat


        public bool LisaaAsiakas(string nimi,string lahiosoite,string postinumero,
                                 string postitoimipaikka, string puh)
        {
            bool ok = true;
            try
            {
                string lause = "insert into asiakas " +
                               "(nimi,lahiosoite,postinumero,postitoimipaikka,puh) " +
                               "values (?,?,?,?,?);";
                this.komento = new MySqlCommand(lause, this.yhteys);

                this.komento.Parameters.Add("@nimi", MySqlDbType.VarChar, 30);
                this.komento.Parameters.Add("@lahiosoite", MySqlDbType.VarChar, 80);
                this.komento.Parameters.Add("@postinumero", MySqlDbType.VarChar, 5);
                this.komento.Parameters.Add("@postitoimipaikka", MySqlDbType.VarChar, 30);
                this.komento.Parameters.Add("@puh", MySqlDbType.VarChar, 30);

                this.komento.Parameters["@nimi"].Value = nimi;
                this.komento.Parameters["@lahiosoite"].Value = lahiosoite;
                this.komento.Parameters["@postinumero"].Value = postinumero;
                this.komento.Parameters["@postitoimipaikka"].Value = postitoimipaikka;
                this.komento.Parameters["@puh"].Value = puh;

                this.komento.Prepare();
                this.komento.ExecuteNonQuery();
            }
            catch (MySqlException e1)
            {
                ok = false;
            }
            return ok;
        }  // LisaaAsiakas
    }  // class
}  // namespace
