using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBConnect
    {
        protected SqlConnection _conn = new SqlConnection("Server=Admin; Database=MemberManager; Integrated Security=True");
    }
}
