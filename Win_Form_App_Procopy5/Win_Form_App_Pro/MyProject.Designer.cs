namespace Win_Form_App_Pro
{
    partial class MyProject
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProjectNameTextBox = new System.Windows.Forms.TextBox();
            this.ProjectDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.QuickMessageSubmitTextBox = new System.Windows.Forms.TextBox();
            this.QuickMessageButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sandboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productBacklogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.QuickMessageListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.projectVersionComboBox = new System.Windows.Forms.ComboBox();
            this.membersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Project Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Project Version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Project Name";
            // 
            // ProjectNameTextBox
            // 
            this.ProjectNameTextBox.Location = new System.Drawing.Point(152, 91);
            this.ProjectNameTextBox.Name = "ProjectNameTextBox";
            this.ProjectNameTextBox.ReadOnly = true;
            this.ProjectNameTextBox.Size = new System.Drawing.Size(250, 20);
            this.ProjectNameTextBox.TabIndex = 18;
            // 
            // ProjectDescriptionTextBox
            // 
            this.ProjectDescriptionTextBox.Location = new System.Drawing.Point(152, 175);
            this.ProjectDescriptionTextBox.Multiline = true;
            this.ProjectDescriptionTextBox.Name = "ProjectDescriptionTextBox";
            this.ProjectDescriptionTextBox.ReadOnly = true;
            this.ProjectDescriptionTextBox.Size = new System.Drawing.Size(250, 150);
            this.ProjectDescriptionTextBox.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(859, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 25);
            this.label10.TabIndex = 45;
            this.label10.Text = "Note Bar";
            // 
            // QuickMessageSubmitTextBox
            // 
            this.QuickMessageSubmitTextBox.Location = new System.Drawing.Point(794, 420);
            this.QuickMessageSubmitTextBox.Multiline = true;
            this.QuickMessageSubmitTextBox.Name = "QuickMessageSubmitTextBox";
            this.QuickMessageSubmitTextBox.Size = new System.Drawing.Size(241, 51);
            this.QuickMessageSubmitTextBox.TabIndex = 46;
            // 
            // QuickMessageButton
            // 
            this.QuickMessageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.QuickMessageButton.Location = new System.Drawing.Point(877, 478);
            this.QuickMessageButton.Name = "QuickMessageButton";
            this.QuickMessageButton.Size = new System.Drawing.Size(86, 29);
            this.QuickMessageButton.TabIndex = 47;
            this.QuickMessageButton.Text = "Add";
            this.QuickMessageButton.UseVisualStyleBackColor = true;
            this.QuickMessageButton.Click += new System.EventHandler(this.NotificationButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sandboxToolStripMenuItem,
            this.productBacklogToolStripMenuItem,
            this.toolStripMenuItem1,
            this.membersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1154, 36);
            this.menuStrip1.TabIndex = 48;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sandboxToolStripMenuItem
            // 
            this.sandboxToolStripMenuItem.Name = "sandboxToolStripMenuItem";
            this.sandboxToolStripMenuItem.Size = new System.Drawing.Size(101, 32);
            this.sandboxToolStripMenuItem.Text = "Sandbox";
            this.sandboxToolStripMenuItem.Click += new System.EventHandler(this.sandboxToolStripMenuItem_Click);
            // 
            // productBacklogToolStripMenuItem
            // 
            this.productBacklogToolStripMenuItem.Name = "productBacklogToolStripMenuItem";
            this.productBacklogToolStripMenuItem.Size = new System.Drawing.Size(167, 32);
            this.productBacklogToolStripMenuItem.Text = "Product Backlog";
            this.productBacklogToolStripMenuItem.Click += new System.EventHandler(this.productBacklogToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 32);
            this.toolStripMenuItem1.Text = "Sprint Plan";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // QuickMessageListBox
            // 
            this.QuickMessageListBox.FormattingEnabled = true;
            this.QuickMessageListBox.Location = new System.Drawing.Point(794, 102);
            this.QuickMessageListBox.Name = "QuickMessageListBox";
            this.QuickMessageListBox.Size = new System.Drawing.Size(241, 303);
            this.QuickMessageListBox.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(509, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "Drag & Drop Files";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(498, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 223);
            this.panel1.TabIndex = 52;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(191, 212);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // projectVersionComboBox
            // 
            this.projectVersionComboBox.FormattingEnabled = true;
            this.projectVersionComboBox.Location = new System.Drawing.Point(152, 125);
            this.projectVersionComboBox.Name = "projectVersionComboBox";
            this.projectVersionComboBox.Size = new System.Drawing.Size(250, 21);
            this.projectVersionComboBox.TabIndex = 53;
            this.projectVersionComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // membersToolStripMenuItem
            // 
            this.membersToolStripMenuItem.Name = "membersToolStripMenuItem";
            this.membersToolStripMenuItem.Size = new System.Drawing.Size(106, 32);
            this.membersToolStripMenuItem.Text = "Members";
            this.membersToolStripMenuItem.Click += new System.EventHandler(this.membersToolStripMenuItem_Click);
            // 
            // MyProject
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 520);
            this.Controls.Add(this.projectVersionComboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QuickMessageListBox);
            this.Controls.Add(this.QuickMessageButton);
            this.Controls.Add(this.QuickMessageSubmitTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProjectNameTextBox);
            this.Controls.Add(this.ProjectDescriptionTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1170, 559);
            this.MinimumSize = new System.Drawing.Size(1170, 559);
            this.Name = "MyProject";
            this.Text = "My Project";
            this.Load += new System.EventHandler(this.MyProject_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyProject_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyProject_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox QuickMessageSubmitTextBox;
        private System.Windows.Forms.Button QuickMessageButton;
        public System.Windows.Forms.TextBox ProjectNameTextBox;
        public System.Windows.Forms.TextBox ProjectDescriptionTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sandboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productBacklogToolStripMenuItem;
        private System.Windows.Forms.ListBox QuickMessageListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ComboBox projectVersionComboBox;
        private System.Windows.Forms.ToolStripMenuItem membersToolStripMenuItem;
    }
}