using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class DTO_Member
    {
        private int _memberId;
        private string _memberFullName;
        private int _memberPhone;
        private string _memberEmail;

        public int MemberId { get { return _memberId; } set { _memberId = value; } }
        public string MemberFullName { get { return _memberFullName; } set { _memberFullName = value; } }
        public int MemberPhone { get { return _memberPhone; } set { _memberPhone = value; } }
        public string MemberEmail { get { return _memberEmail; } set { _memberEmail = value;} }

        public DTO_Member() { }
        public DTO_Member(int memberId, string memberFullName, int memberPhone, string memberEmail)
        {
            _memberId = memberId;
            _memberFullName = memberFullName;
            _memberPhone = memberPhone;
            _memberEmail = memberEmail;
        }
    }
}
