namespace Win_Form_App_Pro
{
    partial class SprintPlan
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
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.numberSprintsComboBox = new System.Windows.Forms.ComboBox();
            this.releasePlanButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.releasePlanListBox = new System.Windows.Forms.ListBox();
            this.sprintsListBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.inProgressListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toDoListBox = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.doneListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sprintPanel = new System.Windows.Forms.Panel();
            this.endDateTextBox = new System.Windows.Forms.TextBox();
            this.startDateTextBox = new System.Windows.Forms.TextBox();
            this.deleteSprintButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sprintNameTextBox = new System.Windows.Forms.TextBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.assignStoryButton = new System.Windows.Forms.Button();
            this.completeStoryButton = new System.Windows.Forms.Button();
            this.deleteReleasePlanButton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.sprintPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(16, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Release Plans";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(423, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.numberSprintsComboBox);
            this.panel2.Controls.Add(this.releasePlanButton);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 44);
            this.panel2.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label13.Location = new System.Drawing.Point(3, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(235, 31);
            this.label13.TabIndex = 43;
            this.label13.Text = "RELEASE PLANS";
            // 
            // numberSprintsComboBox
            // 
            this.numberSprintsComboBox.FormattingEnabled = true;
            this.numberSprintsComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.numberSprintsComboBox.Location = new System.Drawing.Point(355, 10);
            this.numberSprintsComboBox.Name = "numberSprintsComboBox";
            this.numberSprintsComboBox.Size = new System.Drawing.Size(65, 21);
            this.numberSprintsComboBox.TabIndex = 42;
            this.numberSprintsComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // releasePlanButton
            // 
            this.releasePlanButton.Location = new System.Drawing.Point(423, -1);
            this.releasePlanButton.Name = "releasePlanButton";
            this.releasePlanButton.Size = new System.Drawing.Size(161, 44);
            this.releasePlanButton.TabIndex = 41;
            this.releasePlanButton.Text = "Create New Release Plan";
            this.releasePlanButton.UseVisualStyleBackColor = true;
            this.releasePlanButton.Click += new System.EventHandler(this.releasePlanTextBox_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(258, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Number of Sprints";
            // 
            // releasePlanListBox
            // 
            this.releasePlanListBox.FormattingEnabled = true;
            this.releasePlanListBox.Location = new System.Drawing.Point(12, 131);
            this.releasePlanListBox.Name = "releasePlanListBox";
            this.releasePlanListBox.Size = new System.Drawing.Size(103, 108);
            this.releasePlanListBox.TabIndex = 49;
            this.releasePlanListBox.SelectedIndexChanged += new System.EventHandler(this.releasePlanListBox_SelectedIndexChanged);
            // 
            // sprintsListBox
            // 
            this.sprintsListBox.FormattingEnabled = true;
            this.sprintsListBox.Location = new System.Drawing.Point(133, 131);
            this.sprintsListBox.Name = "sprintsListBox";
            this.sprintsListBox.Size = new System.Drawing.Size(103, 108);
            this.sprintsListBox.TabIndex = 51;
            this.sprintsListBox.SelectedIndexChanged += new System.EventHandler(this.sprintsListBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(159, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "Sprints";
            // 
            // inProgressListBox
            // 
            this.inProgressListBox.FormattingEnabled = true;
            this.inProgressListBox.Location = new System.Drawing.Point(646, 130);
            this.inProgressListBox.Name = "inProgressListBox";
            this.inProgressListBox.Size = new System.Drawing.Size(207, 316);
            this.inProgressListBox.TabIndex = 55;
            this.inProgressListBox.SelectedIndexChanged += new System.EventHandler(this.inProgressListBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(702, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 54;
            this.label9.Text = "IN PROGRESS";
            // 
            // toDoListBox
            // 
            this.toDoListBox.FormattingEnabled = true;
            this.toDoListBox.Location = new System.Drawing.Point(339, 130);
            this.toDoListBox.Name = "toDoListBox";
            this.toDoListBox.Size = new System.Drawing.Size(214, 316);
            this.toDoListBox.TabIndex = 53;
            this.toDoListBox.SelectedIndexChanged += new System.EventHandler(this.toDoListBox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(416, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 52;
            this.label12.Text = "TO DO";
            // 
            // doneListBox
            // 
            this.doneListBox.FormattingEnabled = true;
            this.doneListBox.Location = new System.Drawing.Point(946, 130);
            this.doneListBox.Name = "doneListBox";
            this.doneListBox.Size = new System.Drawing.Size(214, 316);
            this.doneListBox.TabIndex = 57;
            this.doneListBox.SelectedIndexChanged += new System.EventHandler(this.doneListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(1031, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "DONE";
            // 
            // sprintPanel
            // 
            this.sprintPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sprintPanel.Controls.Add(this.endDateTextBox);
            this.sprintPanel.Controls.Add(this.startDateTextBox);
            this.sprintPanel.Controls.Add(this.deleteSprintButton);
            this.sprintPanel.Controls.Add(this.label7);
            this.sprintPanel.Controls.Add(this.descriptionTextBox);
            this.sprintPanel.Controls.Add(this.label6);
            this.sprintPanel.Controls.Add(this.label4);
            this.sprintPanel.Controls.Add(this.label3);
            this.sprintPanel.Controls.Add(this.sprintNameTextBox);
            this.sprintPanel.Location = new System.Drawing.Point(2, 51);
            this.sprintPanel.Name = "sprintPanel";
            this.sprintPanel.Size = new System.Drawing.Size(1158, 53);
            this.sprintPanel.TabIndex = 45;
            this.sprintPanel.Visible = false;
            // 
            // endDateTextBox
            // 
            this.endDateTextBox.Location = new System.Drawing.Point(721, 27);
            this.endDateTextBox.Name = "endDateTextBox";
            this.endDateTextBox.ReadOnly = true;
            this.endDateTextBox.Size = new System.Drawing.Size(227, 20);
            this.endDateTextBox.TabIndex = 13;
            // 
            // startDateTextBox
            // 
            this.startDateTextBox.Location = new System.Drawing.Point(721, 3);
            this.startDateTextBox.Name = "startDateTextBox";
            this.startDateTextBox.ReadOnly = true;
            this.startDateTextBox.Size = new System.Drawing.Size(227, 20);
            this.startDateTextBox.TabIndex = 12;
            // 
            // deleteSprintButton
            // 
            this.deleteSprintButton.Location = new System.Drawing.Point(975, -1);
            this.deleteSprintButton.Name = "deleteSprintButton";
            this.deleteSprintButton.Size = new System.Drawing.Size(182, 53);
            this.deleteSprintButton.TabIndex = 10;
            this.deleteSprintButton.Text = "DELETE SPRINT";
            this.deleteSprintButton.UseVisualStyleBackColor = true;
            this.deleteSprintButton.Click += new System.EventHandler(this.deleteSprintButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(261, -1);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(367, 53);
            this.descriptionTextBox.TabIndex = 8;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.descriptionTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Sprint Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(659, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "End Date:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start Date:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // sprintNameTextBox
            // 
            this.sprintNameTextBox.Location = new System.Drawing.Point(80, 16);
            this.sprintNameTextBox.Name = "sprintNameTextBox";
            this.sprintNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.sprintNameTextBox.TabIndex = 1;
            this.sprintNameTextBox.TextChanged += new System.EventHandler(this.sprintNameTextBox_TextChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(12, 290);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 59;
            this.monthCalendar.Visible = false;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // assignStoryButton
            // 
            this.assignStoryButton.Location = new System.Drawing.Point(559, 261);
            this.assignStoryButton.Name = "assignStoryButton";
            this.assignStoryButton.Size = new System.Drawing.Size(81, 66);
            this.assignStoryButton.TabIndex = 60;
            this.assignStoryButton.Text = "Assign Story to Sprint";
            this.assignStoryButton.UseVisualStyleBackColor = true;
            this.assignStoryButton.Visible = false;
            this.assignStoryButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // completeStoryButton
            // 
            this.completeStoryButton.Location = new System.Drawing.Point(859, 272);
            this.completeStoryButton.Name = "completeStoryButton";
            this.completeStoryButton.Size = new System.Drawing.Size(81, 44);
            this.completeStoryButton.TabIndex = 62;
            this.completeStoryButton.Text = "Complete Story";
            this.completeStoryButton.UseVisualStyleBackColor = true;
            this.completeStoryButton.Visible = false;
            this.completeStoryButton.Click += new System.EventHandler(this.completeStoryButton_Click);
            // 
            // deleteReleasePlanButton
            // 
            this.deleteReleasePlanButton.Location = new System.Drawing.Point(12, 245);
            this.deleteReleasePlanButton.Name = "deleteReleasePlanButton";
            this.deleteReleasePlanButton.Size = new System.Drawing.Size(224, 41);
            this.deleteReleasePlanButton.TabIndex = 63;
            this.deleteReleasePlanButton.Text = "Delete Release Plan";
            this.deleteReleasePlanButton.UseVisualStyleBackColor = true;
            this.deleteReleasePlanButton.Visible = false;
            this.deleteReleasePlanButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SprintPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 461);
            this.Controls.Add(this.deleteReleasePlanButton);
            this.Controls.Add(this.completeStoryButton);
            this.Controls.Add(this.assignStoryButton);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.sprintPanel);
            this.Controls.Add(this.doneListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inProgressListBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.toDoListBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.sprintsListBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.releasePlanListBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.MaximumSize = new System.Drawing.Size(1188, 500);
            this.MinimumSize = new System.Drawing.Size(1188, 500);
            this.Name = "SprintPlan";
            this.Text = "Sprint Plan";
            this.Load += new System.EventHandler(this.SprintPlan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.sprintPanel.ResumeLayout(false);
            this.sprintPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox numberSprintsComboBox;
        private System.Windows.Forms.Button releasePlanButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox releasePlanListBox;
        private System.Windows.Forms.ListBox sprintsListBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox inProgressListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox toDoListBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox doneListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel sprintPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sprintNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button deleteSprintButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox endDateTextBox;
        private System.Windows.Forms.TextBox startDateTextBox;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button assignStoryButton;
        private System.Windows.Forms.Button completeStoryButton;
        private System.Windows.Forms.Button deleteReleasePlanButton;
    }
}