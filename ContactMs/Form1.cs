using ContactMs.econtactClasses;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ContactMs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNom = txtBoxTelephone.Text;
            c.Address = txtBoxAddress.Text;
            c.Gmail = textBoxGmail.Text;
            c.Gender = cmbGender.Text;

            bool success = c.Insert(c);
            if(success==true)
            {
                MessageBox.Show("New Contact Successfully Inserted");

                Clear();
            }
            else
            {
                MessageBox.Show("Failed to add New Contact. Try Again.");
            }
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void Econtact_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'econtactDataSet.tbl_contact' table. You can move, or remove it, as needed.
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtBoxTelephone.Text = "";
            textBoxGmail.Text = "";
            txtBoxAddress.Text = "";
            cmbGender.Text = "";
            txtboxContactID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(txtboxContactID.Text);
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNom = txtBoxTelephone.Text;
            c.Address = txtBoxAddress.Text;
            c.Gmail = textBoxGmail.Text;
            c.Gender = cmbGender.Text;

            bool success = c.Update(c);
            if(success==true)
            {
                MessageBox.Show("Contact has been successfully Updated.");

                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Update Contact.Try Again.");
            }
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxTelephone.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxGmail.Text = dgvContactList.Rows[rowIndex].Cells[6].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }
        


        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            bool success = c.Delete(c);

            if(success==true)
            {
                MessageBox.Show("Contact successfully deleted.");

                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Delete Dontact. Try Again.");
            }
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtboxSearch.Text;
            
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE FirstName LIKE '%"+keyword + "%' OR LastName LIKE '%" + keyword +  "%' OR Gmail LIKE '%" + keyword + "%' OR ContactNom LIKE '%" + keyword + "%' OR Address LIKE '%" +keyword+"%'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;
        }

  

        private void finishButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
