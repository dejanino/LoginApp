using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LoginApplication.Classes;

namespace LoginApplication.Controls
{
    public partial class AddressControl : UserControl
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int PostCode { get; set; }
        private bool nonNumber = false;

        public event EventHandler OnChildTextChanged;

        public AddressControl()
        {
            InitializeComponent();
            this.Load += Address_OnLoad;
            txtPostCode.KeyPress += txtPostCode_OnKeyPress;
            txtPostCode.MouseLeave += txtPostCode_OnMouseLeave;
            txtPostCode.TextChanged += txtPostCode_OnTextChanged;
        }

        public void Populate(int addressId)
        {
            Address a = new Address();
            var address = a.GetAddress(addressId);
            if (address != null)
            {
                txtStreetAddress.Text = address.StreetAddress;
                txtCity.Text = address.City;
            }
            else
            {
                MessageBox.Show("This address does not exist");
            }

        }

        private void Address_OnLoad(object sender, EventArgs e)
        {
            Country c = new Country();
            var countries = c.GetCountries();
            ddlCountry.DataSource = countries;
            ddlCountry.DisplayMember = "Name";
            ddlCountry.ValueMember = "ID";
        }

        private void txtStreetAddress_OnTextChanged(object sender, EventArgs e)
        {
            this.StreetAddress = txtStreetAddress.Text;
            if (OnChildTextChanged != null)
                OnChildTextChanged(txtStreetAddress.Text, null);
        }

        private void txtCity_OnTextChanged(object sender, EventArgs e)
        {
            this.City = txtCity.Text;
            if (OnChildTextChanged != null)
                OnChildTextChanged(txtCity.Text, null);
        }

        private void txtPostCode_OnKeyDown(object sender, KeyEventArgs e)
        {
            nonNumber = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    nonNumber = true;
                }
            }
        }

        private void txtPostCode_OnKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumber == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtPostCode_OnMouseLeave(object sender, EventArgs e)
        {
            if (txtPostCode.Text != "")
            {
                this.PostCode = int.Parse(txtPostCode.Text);
            }
        }
        private void txtPostCode_OnTextChanged(object sender, EventArgs e)
        {
            if (OnChildTextChanged != null)
                OnChildTextChanged(txtPostCode.Text, null);
        }

        private void ddlCountry_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender; // ddlCountry
            var selectedItem = combo.SelectedItem as Country;
            this.CountryId = selectedItem.ID;
        }
    }
}
