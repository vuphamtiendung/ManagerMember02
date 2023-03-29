using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BUS_Member
    {
        DAL_Member dalMember = new DAL_Member();

        public DataTable GetMember()
        {
            return dalMember.GetData();
        }

        public bool AddMember(DTO_Member member)
        {
            return dalMember.InsertData(member);
        }

        public bool UpdateMember(DTO_Member member)
        {
            return dalMember.UpdateData(member);
        }

        public bool DeleteMember(int id)
        {
            return dalMember.DeleteData(id);
        }
    }
}
