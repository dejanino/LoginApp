using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class Address : UserControl
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int PostCode { get; set; }

        public Address()
        {
            InitializeComponent();
            this.Load += Address_OnLoad;
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
        }

        private void txtCity_OnTextChanged(object sender, EventArgs e)
        {
            this.City = txtCity.Text;
        }

        private void txtPostCode_OnTextChanged(object sender, EventArgs e)
        {
            this.PostCode = int.Parse(txtPostCode.Text);
        }

        private void ddlCountry_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //Country sc = ddlCountry.SelectedValue as Country;
            //this.CountryId = sc.ID;

            ComboBox combo = (ComboBox)sender; // ddlCountry
            var selectedItem = combo.SelectedItem as Country;
            this.CountryId = selectedItem.ID;
        }
    }
}
