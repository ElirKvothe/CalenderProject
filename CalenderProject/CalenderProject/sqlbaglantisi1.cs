using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CalenderProject
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-F7N4R39\\SQLEXPRESS;Initial Catalog=TakvimProje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
