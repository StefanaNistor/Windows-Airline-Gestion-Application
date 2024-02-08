namespace AirlinePAW.views
{
    partial class MainStaffView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainStaffView));
            this.bookingsDV = new System.Windows.Forms.DataGridView();
            this.routesDV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addRouteBtn = new System.Windows.Forms.Button();
            this.deleteFlightBtn = new System.Windows.Forms.Button();
            this.deleteBookingBtn = new System.Windows.Forms.Button();
            this.addBookingBtn = new System.Windows.Forms.Button();
            this.usersDV = new System.Windows.Forms.DataGridView();
            this.deleteUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.companyTV = new System.Windows.Forms.TreeView();
            this.addCompanyBtn = new System.Windows.Forms.Button();
            this.deleteCompanyBtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routesDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDV)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookingsDV
            // 
            this.bookingsDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookingsDV.Location = new System.Drawing.Point(300, 74);
            this.bookingsDV.Name = "bookingsDV";
            this.bookingsDV.RowHeadersWidth = 51;
            this.bookingsDV.RowTemplate.Height = 24;
            this.bookingsDV.Size = new System.Drawing.Size(247, 150);
            this.bookingsDV.TabIndex = 0;
            // 
            // routesDV
            // 
            this.routesDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routesDV.Location = new System.Drawing.Point(12, 74);
            this.routesDV.Name = "routesDV";
            this.routesDV.RowHeadersWidth = 51;
            this.routesDV.RowTemplate.Height = 24;
            this.routesDV.Size = new System.Drawing.Size(247, 150);
            this.routesDV.TabIndex = 1;
            this.routesDV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.routesDV_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "All Routes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "All bookings:";
            // 
            // addRouteBtn
            // 
            this.addRouteBtn.Location = new System.Drawing.Point(28, 239);
            this.addRouteBtn.Name = "addRouteBtn";
            this.addRouteBtn.Size = new System.Drawing.Size(221, 28);
            this.addRouteBtn.TabIndex = 4;
            this.addRouteBtn.Text = "Add Route";
            this.addRouteBtn.UseVisualStyleBackColor = true;
            this.addRouteBtn.Click += new System.EventHandler(this.addRouteBtn_Click);
            // 
            // deleteFlightBtn
            // 
            this.deleteFlightBtn.Location = new System.Drawing.Point(28, 290);
            this.deleteFlightBtn.Name = "deleteFlightBtn";
            this.deleteFlightBtn.Size = new System.Drawing.Size(221, 28);
            this.deleteFlightBtn.TabIndex = 5;
            this.deleteFlightBtn.Text = "Delete Route";
            this.deleteFlightBtn.UseVisualStyleBackColor = true;
            this.deleteFlightBtn.Click += new System.EventHandler(this.deleteFlightBtn_Click);
            // 
            // deleteBookingBtn
            // 
            this.deleteBookingBtn.Location = new System.Drawing.Point(313, 290);
            this.deleteBookingBtn.Name = "deleteBookingBtn";
            this.deleteBookingBtn.Size = new System.Drawing.Size(221, 28);
            this.deleteBookingBtn.TabIndex = 6;
            this.deleteBookingBtn.Text = "Delete booking";
            this.deleteBookingBtn.UseVisualStyleBackColor = true;
            this.deleteBookingBtn.Click += new System.EventHandler(this.deleteBookingBtn_Click);
            // 
            // addBookingBtn
            // 
            this.addBookingBtn.Location = new System.Drawing.Point(313, 239);
            this.addBookingBtn.Name = "addBookingBtn";
            this.addBookingBtn.Size = new System.Drawing.Size(221, 28);
            this.addBookingBtn.TabIndex = 7;
            this.addBookingBtn.Text = "Add booking";
            this.addBookingBtn.UseVisualStyleBackColor = true;
            this.addBookingBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // usersDV
            // 
            this.usersDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDV.Location = new System.Drawing.Point(572, 74);
            this.usersDV.Name = "usersDV";
            this.usersDV.RowHeadersWidth = 51;
            this.usersDV.RowTemplate.Height = 24;
            this.usersDV.Size = new System.Drawing.Size(247, 150);
            this.usersDV.TabIndex = 8;
            // 
            // deleteUser
            // 
            this.deleteUser.Location = new System.Drawing.Point(585, 263);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Size = new System.Drawing.Size(221, 28);
            this.deleteUser.TabIndex = 10;
            this.deleteUser.Text = "Delete user";
            this.deleteUser.UseVisualStyleBackColor = true;
            this.deleteUser.Click += new System.EventHandler(this.deleteUser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(664, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "All users:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "All companies:";
            // 
            // companyTV
            // 
            this.companyTV.Location = new System.Drawing.Point(126, 332);
            this.companyTV.Name = "companyTV";
            this.companyTV.Size = new System.Drawing.Size(200, 98);
            this.companyTV.TabIndex = 14;
            this.companyTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.companyTV_AfterSelect);
            this.companyTV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.companyTV_MouseDoubleClick);
            // 
            // addCompanyBtn
            // 
            this.addCompanyBtn.Location = new System.Drawing.Point(348, 353);
            this.addCompanyBtn.Name = "addCompanyBtn";
            this.addCompanyBtn.Size = new System.Drawing.Size(221, 26);
            this.addCompanyBtn.TabIndex = 15;
            this.addCompanyBtn.Text = "Add company";
            this.addCompanyBtn.UseVisualStyleBackColor = true;
            this.addCompanyBtn.Click += new System.EventHandler(this.addCompanyBtn_Click);
            // 
            // deleteCompanyBtn
            // 
            this.deleteCompanyBtn.Location = new System.Drawing.Point(348, 404);
            this.deleteCompanyBtn.Name = "deleteCompanyBtn";
            this.deleteCompanyBtn.Size = new System.Drawing.Size(221, 26);
            this.deleteCompanyBtn.TabIndex = 16;
            this.deleteCompanyBtn.Text = "Delete Company";
            this.deleteCompanyBtn.UseVisualStyleBackColor = true;
            this.deleteCompanyBtn.Click += new System.EventHandler(this.deleteCompanyBtn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(845, 31);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.SystemColors.WindowText;
            this.toolStripButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.BackgroundImage")));
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "&Log Out!";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(845, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // MainStaffView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.deleteCompanyBtn);
            this.Controls.Add(this.addCompanyBtn);
            this.Controls.Add(this.companyTV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deleteUser);
            this.Controls.Add(this.usersDV);
            this.Controls.Add(this.addBookingBtn);
            this.Controls.Add(this.deleteBookingBtn);
            this.Controls.Add(this.deleteFlightBtn);
            this.Controls.Add(this.addRouteBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.routesDV);
            this.Controls.Add(this.bookingsDV);
            this.Name = "MainStaffView";
            this.ShowIcon = false;
            this.Text = "Main Page";
            this.Load += new System.EventHandler(this.MainStaffView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingsDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routesDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDV)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView bookingsDV;
        private System.Windows.Forms.DataGridView routesDV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addRouteBtn;
        private System.Windows.Forms.Button deleteFlightBtn;
        private System.Windows.Forms.Button deleteBookingBtn;
        private System.Windows.Forms.Button addBookingBtn;
        private System.Windows.Forms.DataGridView usersDV;
        private System.Windows.Forms.Button deleteUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView companyTV;
        private System.Windows.Forms.Button addCompanyBtn;
        private System.Windows.Forms.Button deleteCompanyBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}