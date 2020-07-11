using LoginApplication.Classes;
using LoginApplication.Controls;
using LoginApplication.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class frmMain : Form
    {
        private bool isEdit = false;
        private User editedUser = null;

        public static string connectionString = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(connectionString);
        private static SqlDataAdapter _dataAdapter = DataAdapters.EmployeeAdapter(conn);
        private DataSet employees;

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

            populateGridView();
        }

        private void populateGridView()
        {
            gvUsers.AutoGenerateColumns = true;
            gvUsers.EditMode = DataGridViewEditMode.EditOnEnter;

            employees = new DataSet();
            try
            {
                _dataAdapter.Fill(employees, "Employees");
                gvUsers.DataSource = employees.Tables["Employees"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske!");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        private void UpdateGridView()
        {
            try
            {
                _dataAdapter.Update(employees, "Employees");
                populateGridView();
                MessageBox.Show("Usplesno snimanje");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neuspesno snimanje: {0}", ex.Message);
            }
        }

        private void populateList(IList<User> userList)
        {
            // set events
            // sort columns on column click
            this.lstUsers.ColumnClick += new ColumnClickEventHandler(OnColumnClick);
            ColumnClickEventArgs eArgs = new ColumnClickEventArgs(0);
            OnColumnClick(lstUsers, eArgs);

            this.lstUsers.MouseClick += LstUsers_OnMouseClick;

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
            lstUsers.Sorting = System.Windows.Forms.SortOrder.Descending;
            lstUsers.GridLines = true;
            lstUsers.FullRowSelect = true;
        }

        private void populateForm(ListViewItem item)
        {
            User u = new User();
            // populate boxes
            txtName.Text = item.SubItems[1].Text;
            txtEmail.Text = item.SubItems[2].Text;
            txtID.Text = item.SubItems[0].Text;

            // set edit data
            int id = int.Parse(item.SubItems[0].Text);
            var user = u.GetUser(id);
            user.Name = item.SubItems[1].Text;
            user.Email = item.SubItems[2].Text;

            editedUser = user;
        }

        private void clearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtID.Text = "";

            var txtStreetAddress = _address.Controls.Find("txtStreetAddress", true);
            if (txtStreetAddress != null)
            {
                TextBox tb = txtStreetAddress[0] as TextBox;
                tb.Clear();
            }

            var txtCity = _address.Controls.Find("txtCity", true);
            if (txtCity != null)
            {
                TextBox tb = txtCity[0] as TextBox;
                tb.Clear();
            }


            _address.City = "";
            var txtPostcode = _address.Controls.Find("txtPostCode", true);
            if (txtPostcode != null)
            {
                TextBox tb = txtPostcode[0] as TextBox;
                tb.Clear();
            }
            _address.CountryId = 1;
        }

        #region Events

        private void LstUsers_OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstUsers.FocusedItem != null && lstUsers.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ContextMenu m = new ContextMenu();
                    MenuItem editMenuItem = new MenuItem("Edit");
                    editMenuItem.Click += delegate (object sender2, EventArgs e2)
                    {
                        EditClick(sender, e, lstUsers.FocusedItem);
                    };
                    m.MenuItems.Add(editMenuItem);
                    
                    MenuItem editAddressMenuItem = new MenuItem("Edit Address");
                    editAddressMenuItem.Click += delegate (object sender3, EventArgs e3)
                    {
                        EditAddressClick(sender, e, lstUsers.FocusedItem);
                    };
                    m.MenuItems.Add(editAddressMenuItem);

                    MenuItem separatorMenuItem = new MenuItem("-");
                    m.MenuItems.Add(separatorMenuItem);

                    MenuItem deleteMenuItem = new MenuItem("Delete");
                    deleteMenuItem.Click += delegate (object sender2, EventArgs e2)
                    {
                        DeleteClick(sender, e, lstUsers.FocusedItem);
                    };
                    m.MenuItems.Add(deleteMenuItem);

                    m.Show(lstUsers, new Point(e.X, e.Y));
                }
            }
        }

        private void DeleteClick(object sender, MouseEventArgs e, ListViewItem item)
        {
            int id = int.Parse(item.Text);
            User user = new User();
            bool isDeleted = user.DeleteUser(id);

            if (isDeleted)
            {
                this.Refresh();
                // update list
                lstUsers.Items.Clear();
                populateList(user.GetUserList());
            }
            else
            {
                MessageBox.Show("Error deleting user");
            }
        }

        private void EditClick(object sender, MouseEventArgs e, ListViewItem item)
        {
            isEdit = true;
            populateForm(item);
        }
        private void EditAddressClick(object sender, MouseEventArgs e, ListViewItem focusedItem)
        {
            int id = int.Parse(focusedItem.Text);
            User user = new User();
            var u = user.GetUser(id);
            frmAddressEditor fm = new frmAddressEditor(u.AddressId);
            fm.Show();
        }

        private void OnColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lstUsers.ListViewItemSorter = new ListViewItemComparer(e.Column);
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
            _address = this.ctlAddress;
            _address.OnChildTextChanged += new EventHandler(child_OnChildTextChanged);

            if (isEdit && editedUser != null)
            {
                editedUser.Name = txtName.Text;
                editedUser.Email = txtEmail.Text;
                bool isSucessful = u.EditUser(editedUser.ID, editedUser);

                if (isSucessful)
                {
                    lstUsers.Items.Clear();
                    this.populateList(u.GetUserList());
                    editedUser = null;
                    isEdit = false;
                }
            }
            else
            {
                // save new user 
                
                string streetAddress = _address.StreetAddress;
                string city = _address.City;
                int postCode = _address.PostCode;
                int countryId = _address.CountryId;

                // save address 
                int addressId = a.SaveAddress(streetAddress, city, postCode, countryId);

                //save user
                u.SaveUser(txtName.Text, txtEmail.Text, 0, addressId);
            }

            // clear fields

            clearFields();

            // update list
            lstUsers.Items.Clear();
            this.populateList(u.GetUserList());
            
        }
        
        void child_OnChildTextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSync_Click(object sender, EventArgs e)
        {   
            UpdateGridView();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvUsers.SelectedRows)
            {
                gvUsers.Rows.RemoveAt(row.Index);
            }
            UpdateGridView();
        }
        #endregion


    }
}
