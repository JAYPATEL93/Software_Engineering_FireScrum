﻿namespace Win_Form_App_Pro
{
    partial class Members
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
            this.usersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.membersListBox = new System.Windows.Forms.ListBox();
            this.removeMemberButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usersComboBox
            // 
            this.usersComboBox.FormattingEnabled = true;
            this.usersComboBox.Location = new System.Drawing.Point(12, 34);
            this.usersComboBox.Name = "usersComboBox";
            this.usersComboBox.Size = new System.Drawing.Size(185, 21);
            this.usersComboBox.TabIndex = 0;
            this.usersComboBox.SelectedIndexChanged += new System.EventHandler(this.usersComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Position";
            // 
            // positionComboBox
            // 
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Items.AddRange(new object[] {
            "Regular Member",
            "Product Owner",
            "Scrum Master"});
            this.positionComboBox.Location = new System.Drawing.Point(12, 101);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(185, 21);
            this.positionComboBox.TabIndex = 2;
            this.positionComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 58);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add to Group";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // membersListBox
            // 
            this.membersListBox.FormattingEnabled = true;
            this.membersListBox.Location = new System.Drawing.Point(222, 15);
            this.membersListBox.Name = "membersListBox";
            this.membersListBox.Size = new System.Drawing.Size(228, 108);
            this.membersListBox.TabIndex = 5;
            this.membersListBox.SelectedIndexChanged += new System.EventHandler(this.membersListBox_SelectedIndexChanged);
            // 
            // removeMemberButton
            // 
            this.removeMemberButton.Location = new System.Drawing.Point(222, 154);
            this.removeMemberButton.Name = "removeMemberButton";
            this.removeMemberButton.Size = new System.Drawing.Size(228, 58);
            this.removeMemberButton.TabIndex = 6;
            this.removeMemberButton.Text = "Remove from Group";
            this.removeMemberButton.UseVisualStyleBackColor = true;
            this.removeMemberButton.Click += new System.EventHandler(this.removeMemberButton_Click);
            // 
            // Members
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 239);
            this.Controls.Add(this.removeMemberButton);
            this.Controls.Add(this.membersListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.positionComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersComboBox);
            this.Name = "Members";
            this.Text = "Members";
            this.Load += new System.EventHandler(this.Members_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox usersComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox positionComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox membersListBox;
        private System.Windows.Forms.Button removeMemberButton;
    }
}