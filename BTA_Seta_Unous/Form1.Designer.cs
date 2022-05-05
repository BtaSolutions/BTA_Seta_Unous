
namespace BTA_Seta_Unous
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLocations = new System.Windows.Forms.Button();
            this.dtpDate01 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate02 = new System.Windows.Forms.DateTimePicker();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnOpenOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Token";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Criar Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(125, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 48);
            this.button3.TabIndex = 3;
            this.button3.Text = "Products";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLocations
            // 
            this.btnLocations.Location = new System.Drawing.Point(125, 162);
            this.btnLocations.Name = "btnLocations";
            this.btnLocations.Size = new System.Drawing.Size(107, 48);
            this.btnLocations.TabIndex = 4;
            this.btnLocations.Text = "Locations";
            this.btnLocations.UseVisualStyleBackColor = true;
            this.btnLocations.Click += new System.EventHandler(this.btnLocations_Click);
            // 
            // dtpDate01
            // 
            this.dtpDate01.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate01.Location = new System.Drawing.Point(12, 26);
            this.dtpDate01.Name = "dtpDate01";
            this.dtpDate01.Size = new System.Drawing.Size(100, 23);
            this.dtpDate01.TabIndex = 5;
            // 
            // dtpDate02
            // 
            this.dtpDate02.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate02.Location = new System.Drawing.Point(111, 26);
            this.dtpDate02.Name = "dtpDate02";
            this.dtpDate02.Size = new System.Drawing.Size(100, 23);
            this.dtpDate02.TabIndex = 6;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Location = new System.Drawing.Point(238, 108);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(107, 48);
            this.btnSuppliers.TabIndex = 7;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = true;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnOpenOrders
            // 
            this.btnOpenOrders.Location = new System.Drawing.Point(240, 162);
            this.btnOpenOrders.Name = "btnOpenOrders";
            this.btnOpenOrders.Size = new System.Drawing.Size(107, 48);
            this.btnOpenOrders.TabIndex = 8;
            this.btnOpenOrders.Text = "Open Orders";
            this.btnOpenOrders.UseVisualStyleBackColor = true;
            this.btnOpenOrders.Click += new System.EventHandler(this.btnOpenOrders_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 217);
            this.Controls.Add(this.btnOpenOrders);
            this.Controls.Add(this.btnSuppliers);
            this.Controls.Add(this.dtpDate02);
            this.Controls.Add(this.dtpDate01);
            this.Controls.Add(this.btnLocations);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnLocations;
        private System.Windows.Forms.DateTimePicker dtpDate01;
        private System.Windows.Forms.DateTimePicker dtpDate02;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnOpenOrders;
    }
}

