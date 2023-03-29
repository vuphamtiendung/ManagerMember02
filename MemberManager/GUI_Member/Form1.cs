using BusinessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Member
{
    public partial class Form1 : Form
    {
        BUS_Member member = new BUS_Member();
        List<DTO_Member> listMember = new List<DTO_Member> ();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public void DisplayData()
        {
            listMember = (from DataRow dr in member.GetMember().Rows
                          select new DTO_Member()
                          {
                              MemberId = Convert.ToInt32(dr["TV_ID"]),
                              MemberFullName = dr["TV_NAME"].ToString(),
                              MemberPhone = Convert.ToInt32(dr["TV_PHONE"]),
                              MemberEmail = dr["TV_EMAIL"].ToString()
                          }).ToList();
            lsvMember.Items.Clear();
            listMember.ForEach(x =>
            {
                ListViewItem item = new ListViewItem(x.MemberId + "");

            });
        }
    }
}
