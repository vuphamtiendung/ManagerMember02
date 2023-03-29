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
        BUS_Member busMember = new BUS_Member();
        List<DTO_Member> listMember = new List<DTO_Member> ();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public void DisplayData()
        {
            listMember = (from DataRow dr in busMember.GetMember().Rows
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
                item.SubItems.Add(x.MemberFullName);
                item.SubItems.Add(x.MemberPhone + "");
                item.SubItems.Add(x.MemberEmail);
                lsvMember.Items.Add(item);
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void lsvMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvMember.SelectedItems.Count == 0) return;
            ListViewItem lsv = lsvMember.SelectedItems[0]; // Take the line user choose
            int code = Convert.ToInt32(lsv.SubItems[0].Text); // Take ID
            DTO_Member item = (from DataRow dr in busMember.GetMember().Rows
                               where Convert.ToInt32(dr["TV_ID"]) == code
                               select new DTO_Member()
                               {
                                   MemberId = Convert.ToInt32(dr["TV_ID"]),
                                   MemberFullName = dr["TV_NAME"].ToString(),
                                   MemberPhone = Convert.ToInt32(dr["TV_PHONE"]),
                                   MemberEmail = dr["TV_EMAIL"].ToString()
                               }).FirstOrDefault();
            if(item != null)
            {
                txtFullName.Text = item.MemberFullName;
                txtPhone.Text = item.MemberPhone + "";
                txtEmail.Text = item.MemberEmail;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtFullName.Text;
                int phone = Convert.ToInt32(txtPhone.Text);
                string email = txtEmail.Text;
                if(txtFullName.Text != "" && txtPhone.Text != "" & txtEmail.Text != "")
                {
                    DTO_Member member = new DTO_Member(0, name, phone, email);
                    if (busMember.AddMember(member))
                    {
                        MessageBox.Show("Add success!");
                        DisplayData();
                    }
                    else
                    {
                        MessageBox.Show("Add false");
                    }
                }
                else
                {
                    MessageBox.Show("Please input full textbox!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Has been error! detail: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = txtFullName.Text;
                int phone = Convert.ToInt32(txtPhone.Text);
                string email = txtEmail.Text;
                if(txtFullName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "")
                {
                    ListViewItem lsv = lsvMember.SelectedItems[0]; // Line choose
                    int code = Convert.ToInt32(lsv.SubItems[0].Text); // Take the id 
                    DTO_Member member = new DTO_Member(code, fullName, phone, email);
                    if (busMember.UpdateMember(member))
                    {
                        MessageBox.Show("Update success!");
                        DisplayData();
                    }
                    else
                    {
                        MessageBox.Show("Update fail");
                    }
                }
                else
                {
                    MessageBox.Show("You need input fully the fields");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Has been error, detail: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = txtFullName.Text;
                int phone = Convert.ToInt32( txtPhone.Text);
                string email = txtEmail.Text;
                if(txtFullName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "")
                {
                    ListViewItem lsv = lsvMember.SelectedItems[0]; // line choose
                    int id = Convert.ToInt32(lsv.SubItems[0].Text);
                    if (busMember.DeleteMember(id))
                    {
                        MessageBox.Show("Delete success!");
                        DisplayData();
                    }
                    else
                    {
                        MessageBox.Show("Delete false");
                    }
                }
                else
                {
                    MessageBox.Show("You need input fully the fields");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Has been error, detail: " + ex.Message);
            }
        }
    }
}
