namespace LoginApplication
{
    partial class frmMain
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
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.lstStudents = new System.Windows.Forms.ListView();
            this.ctlAddress = new LoginApplication.Address();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.Location = new System.Drawing.Point(704, 15);
            this.btn_LogOut.Margin = new System.Windows.Forms.Padding(4);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(100, 28);
            this.btn_LogOut.TabIndex = 0;
            this.btn_LogOut.Text = "Log out";
            this.btn_LogOut.UseVisualStyleBackColor = true;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // lstStudents
            // 
            this.lstStudents.Location = new System.Drawing.Point(38, 89);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(275, 183);
            this.lstStudents.TabIndex = 1;
            this.lstStudents.UseCompatibleStateImageBehavior = false;
            // 
            // ctlAddress
            // 
            this.ctlAddress.City = null;
            this.ctlAddress.CountryId = 0;
            this.ctlAddress.Location = new System.Drawing.Point(351, 89);
            this.ctlAddress.Name = "ctlAddress";
            this.ctlAddress.PostCode = 0;
            this.ctlAddress.Size = new System.Drawing.Size(450, 183);
            this.ctlAddress.StreetAddress = null;
            this.ctlAddress.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(704, 343);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(97, 32);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 415);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.ctlAddress);
            this.Controls.Add(this.lstStudents);
            this.Controls.Add(this.btn_LogOut);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.ListView lstStudents;
        private Address ctlAddress;
        private System.Windows.Forms.Button btnSubmit;
    }
}