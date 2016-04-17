namespace SteamScreenAdd
{
    partial class Form1
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
            this.labelUserID = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.labelGameID = new System.Windows.Forms.Label();
            this.textBoxGameID = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(13, 13);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(79, 13);
            this.labelUserID.TabIndex = 0;
            this.labelUserID.Text = "Steam User ID:";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(98, 10);
            this.textBoxUserID.MaxLength = 15;
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserID.TabIndex = 1;
            this.textBoxUserID.TextChanged += new System.EventHandler(this.UserID_Change);
            // 
            // labelGameID
            // 
            this.labelGameID.AutoSize = true;
            this.labelGameID.Location = new System.Drawing.Point(204, 13);
            this.labelGameID.Name = "labelGameID";
            this.labelGameID.Size = new System.Drawing.Size(86, 13);
            this.labelGameID.TabIndex = 2;
            this.labelGameID.Text = "Target Game ID:";
            // 
            // textBoxGameID
            // 
            this.textBoxGameID.Location = new System.Drawing.Point(296, 10);
            this.textBoxGameID.MaxLength = 15;
            this.textBoxGameID.Name = "textBoxGameID";
            this.textBoxGameID.Size = new System.Drawing.Size(100, 20);
            this.textBoxGameID.TabIndex = 3;
            this.textBoxGameID.TextChanged += new System.EventHandler(this.GameID_Change);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(13, 37);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(84, 13);
            this.labelSource.TabIndex = 4;
            this.labelSource.Text = "Image Directory:";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(98, 34);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(298, 20);
            this.textBoxSource.TabIndex = 5;
            this.textBoxSource.TextChanged += new System.EventHandler(this.SourceDir_Change);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(13, 65);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(383, 35);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add Images";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 112);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.textBoxGameID);
            this.Controls.Add(this.labelGameID);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.labelUserID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SteamScreenAdd";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // TODO: Maybe add numeric filters for UserID and GameID boxes
        // TODO: Maybe add more specific length limit to UserID and GameID boxes
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label labelGameID;
        private System.Windows.Forms.TextBox textBoxGameID;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Button buttonAdd;
    }
}

