using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class frmMain : Form
    {
        private Address _address;
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_OnLoad;
        }

        private void FrmMain_OnLoad(object sender, EventArgs e)
        {
            Student students = new Student();
            var studentList = students.GetStudents();
            populateList(studentList);
            this.lstStudents.ColumnClick += new ColumnClickEventHandler(OnColumnClick);
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
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }

        private void OnColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lstStudents.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void populateList(IList<Student> studentList)
        {
            //set view
            lstStudents.View = View.Details; // Tile

            // perpare ListView beforehand
            lstStudents.Columns.Add("ID");
            lstStudents.Columns.Add("Name");
            lstStudents.Columns.Add("Age");

            //populate list
            foreach (var student in studentList)
            {
                ListViewItem item = new ListViewItem(new string[]
                    { student.ID.ToString(), student.Name, student.Age.ToString() });
                //item.Text = student.ID.ToString();
                //item.SubItems.Add(student.Name);
                //item.SubItems.Add(student.Age.ToString());
                lstStudents.Items.Add(item);
            }
            lstStudents.Sorting = SortOrder.Descending;
            lstStudents.GridLines = true;
            lstStudents.FullRowSelect = true;
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
            string streetAddress = ctlAddress.StreetAddress;
            string city = ctlAddress.City;
            int postCode = ctlAddress.PostCode;
            int countryId = ctlAddress.CountryId;
            int[] students = new int[lstStudents.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in lstStudents.SelectedItems)
            {
                //fill the text boxes
                var id = item.Text;
                var name = item.SubItems[1].Text;
                var age = item.SubItems[2].Text;
                students[i] = int.Parse(id);
                i++;
            }
        }
    }
}
