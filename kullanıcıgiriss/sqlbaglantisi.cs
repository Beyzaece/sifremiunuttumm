using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;


namespace kullanıcıgiriss
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti() { 
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-5GC8I8FF\\SQLEXPRESS;Initial Catalog=kullanıcıgiriss;Integrated Security=True");
            baglanti.Open();
            return baglanti;
        }
    }
}
