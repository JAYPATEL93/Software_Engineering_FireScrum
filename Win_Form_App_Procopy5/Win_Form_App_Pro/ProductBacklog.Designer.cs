namespace Win_Form_App_Pro
{
    partial class ProductBacklog
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
            this.label1 = new System.Windows.Forms.Label();
            this.incompleteStoryListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.completeStoryListBox = new System.Windows.Forms.ListBox();
            this.completeStoryButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(468, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Backlog";
            // 
            // incompleteStoryListBox
            // 
            this.incompleteStoryListBox.FormattingEnabled = true;
            this.incompleteStoryListBox.Location = new System.Drawing.Point(12, 67);
            this.incompleteStoryListBox.Name = "incompleteStoryListBox";
            this.incompleteStoryListBox.Size = new System.Drawing.Size(1018, 134);
            this.incompleteStoryListBox.TabIndex = 2;
            this.incompleteStoryListBox.SelectedIndexChanged += new System.EventHandler(this.incompleteStoryListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "INCOMPLETE STORIES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "COMPLETE STORIES";
            // 
            // completeStoryListBox
            // 
            this.completeStoryListBox.FormattingEnabled = true;
            this.completeStoryListBox.Location = new System.Drawing.Point(12, 290);
            this.completeStoryListBox.Name = "completeStoryListBox";
            this.completeStoryListBox.Size = new System.Drawing.Size(1018, 134);
            this.completeStoryListBox.TabIndex = 4;
            this.completeStoryListBox.SelectedIndexChanged += new System.EventHandler(this.completeStoryListBox_SelectedIndexChanged);
            // 
            // completeStoryButton
            // 
            this.completeStoryButton.Location = new System.Drawing.Point(416, 207);
            this.completeStoryButton.Name = "completeStoryButton";
            this.completeStoryButton.Size = new System.Drawing.Size(82, 61);
            this.completeStoryButton.TabIndex = 6;
            this.completeStoryButton.Text = "Complete Story";
            this.completeStoryButton.UseVisualStyleBackColor = true;
            this.completeStoryButton.Click += new System.EventHandler(this.completeStoryButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(580, 207);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(82, 61);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete Story";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // ProductBacklog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 437);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.completeStoryButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.completeStoryListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.incompleteStoryListBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1058, 476);
            this.MinimumSize = new System.Drawing.Size(1058, 476);
            this.Name = "ProductBacklog";
            this.Text = "Product Backlog";
            this.Load += new System.EventHandler(this.ProductBacklog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox incompleteStoryListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox completeStoryListBox;
        private System.Windows.Forms.Button completeStoryButton;
        private System.Windows.Forms.Button deleteButton;
    }
}