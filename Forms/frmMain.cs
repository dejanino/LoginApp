using LoginApplication.Classes;
using LoginApplication.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class frmMain : Form
    {
        // private AddressControl _address;
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_OnLoad;
        }

        private void FrmMain_OnLoad(object sender, EventArgs e)
        {
            User user = new User();
            var userList = user.GetUserList(); // OR 
            populateList(userList);
            this.lstUsers.ColumnClick += new ColumnClickEventHandler(OnColumnClick);

            ColumnClickEventArgs eArgs = new ColumnClickEventArgs(0);
            OnColumnClick(lstUsers, eArgs);
        }

        // Implements the manual sorting of items by columns.
        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                int nr = 0;
                
                bool isNumber = int.TryParse(((ListViewItem)x).SubItems[col].Text, out nr);

                if (!isNumber)
                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                else
                {
                    int firstnumber = int.Parse(((ListViewItem)x).SubItems[col].Text);
                    int secondNumber = int.Parse(((ListViewItem)y).SubItems[col].Text);

                    return firstnumber.CompareTo(secondNumber);
                }
            }
        }

        private void OnColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lstUsers.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void populateList(IList<User> userList)
        {
            //set view
            lstUsers.View = View.Details; // Tile

            // perpare ListView beforehand
            lstUsers.Columns.Add("ID");
            lstUsers.Columns.Add("Name");
            lstUsers.Columns.Add("Email");

            //populate list
            foreach (var user in userList)
            {
                ListViewItem item = new ListViewItem(new string[]
                    { user.ID.ToString(), user.Name, user.Email });

                // other way
                //item.Text = student.ID.ToString();
                //item.SubItems.Add(student.Name);
                //item.SubItems.Add(student.Age.ToString());

                lstUsers.Items.Add(item);
            }
            lstUsers.Sorting = SortOrder.Descending;
            lstUsers.GridLines = true;
            lstUsers.FullRowSelect = true;
        }

        private void SelectionChanged()
        {
            MessageBox.Show(String.Format("This is ID: {0}!", _address.CountryId));
            this.Close();
        }

        //btn_LogOut Click Event
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = new frmLogin();
            fl.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Address a = new Address();
            User u = new User();

            // get data from address control
            _address = this.addressControl1;
            string streetAddress = _address.StreetAddress;
            string city = _address.City;
            int postCode = _address.PostCode;
            int countryId = _address.CountryId;

            // save address 
            int addressId = a.SaveAddress(streetAddress, city, postCode, countryId);

            //save user
            u.SaveUser("Joca", "joca@sedc.com", 0, addressId);

            // clear fields
            _address.StreetAddress = "";
            _address.City = "";
            var txtPostcode = _address.Controls.Find("txtPostCode", true);
            if (txtPostcode != null)
            {
                TextBox tb = txtPostcode[0] as TextBox;
                tb.Clear();
            }
            _address.CountryId = 1;

            // update list
            lstUsers.Clear();
            this.populateList(u.GetUserList());


            int[] users = new int[lstUsers.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in lstUsers.SelectedItems)
            {
                //fill the text boxes
                var id = item.Text;
                var name = item.SubItems[1].Text;
                var age = item.SubItems[2].Text;
                users[i] = int.Parse(id);
                i++;
            }
        }
    }
}
