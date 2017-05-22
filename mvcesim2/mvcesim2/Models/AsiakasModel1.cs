using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Tämä jos MySQL Connector NET
// Muista References MySql.Data
using MySql.Data.MySqlClient;

namespace mvc.asiakasmalli
{
    public class AsiakasModel1
    {
        public MySqlDataReader tulos = null;
    } // class
}  // namespace