namespace LoginApplication.Forms
{
    partial class frmAddressEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addressControl1 = new LoginApplication.Controls.AddressControl();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.brnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addressControl1
            // 
            this.addressControl1.City = null;
            this.addressControl1.CountryId = 1;
            this.addressControl1.Location = new System.Drawing.Point(11, 11);
            this.addressControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addressControl1.Name = "addressControl1";
            this.addressControl1.PostCode = 0;
            this.addressControl1.Size = new System.Drawing.Size(338, 149);
            this.addressControl1.StreetAddress = null;
            this.addressControl1.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(33, 165);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // brnCancel
            // 
            this.brnCancel.Location = new System.Drawing.Point(213, 165);
            this.brnCancel.Name = "brnCancel";
            this.brnCancel.Size = new System.Drawing.Size(75, 23);
            this.brnCancel.TabIndex = 2;
            this.brnCancel.Text = "Cancel";
            this.brnCancel.UseVisualStyleBackColor = true;
            this.brnCancel.Click += new System.EventHandler(this.brnCancel_Click);
            // 
            // frmAddressEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 221);
            this.Controls.Add(this.brnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.addressControl1);
            this.Name = "frmAddressEditor";
            this.Text = "frmAddressEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AddressControl addressControl1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button brnCancel;
    }
}