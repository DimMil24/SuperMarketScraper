namespace SuperMarketScraper
{
    partial class Form2
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
            modalList = new ListView();
            columnHeader1 = new ColumnHeader();
            button1 = new Button();
            SuspendLayout();
            // 
            // modalList
            // 
            modalList.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            modalList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            modalList.HeaderStyle = ColumnHeaderStyle.None;
            modalList.Location = new Point(43, 12);
            modalList.MultiSelect = false;
            modalList.Name = "modalList";
            modalList.Size = new Size(730, 312);
            modalList.TabIndex = 0;
            modalList.UseCompatibleStateImageBehavior = false;
            modalList.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 500;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(322, 347);
            button1.Name = "button1";
            button1.Size = new Size(169, 64);
            button1.TabIndex = 1;
            button1.Text = "Επιλογή";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(816, 448);
            Controls.Add(button1);
            Controls.Add(modalList);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private ListView modalList;
        private ColumnHeader columnHeader1;
        private Button button1;
    }
}