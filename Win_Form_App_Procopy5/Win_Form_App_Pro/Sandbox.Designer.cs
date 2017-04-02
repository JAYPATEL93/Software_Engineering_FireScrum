namespace Win_Form_App_Pro
{
    partial class Sandbox
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
            this.sandboxEntryTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.sandboxListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sandboxEntryTextBox
            // 
            this.sandboxEntryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sandboxEntryTextBox.Location = new System.Drawing.Point(341, 12);
            this.sandboxEntryTextBox.Multiline = true;
            this.sandboxEntryTextBox.Name = "sandboxEntryTextBox";
            this.sandboxEntryTextBox.Size = new System.Drawing.Size(305, 133);
            this.sandboxEntryTextBox.TabIndex = 0;
            this.sandboxEntryTextBox.Text = "As a: \r\n I want to: \r\n Purpose of: ";
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addButton.Location = new System.Drawing.Point(447, 151);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(101, 44);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add to Sandbox";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // sandboxListBox
            // 
            this.sandboxListBox.FormattingEnabled = true;
            this.sandboxListBox.Location = new System.Drawing.Point(13, 204);
            this.sandboxListBox.Name = "sandboxListBox";
            this.sandboxListBox.Size = new System.Drawing.Size(998, 264);
            this.sandboxListBox.TabIndex = 5;
            this.sandboxListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Sandbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 489);
            this.Controls.Add(this.sandboxListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.sandboxEntryTextBox);
            this.Name = "Sandbox";
            this.Text = "Sandbox";
            this.Load += new System.EventHandler(this.Sandbox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sandboxEntryTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox sandboxListBox;
    }
}