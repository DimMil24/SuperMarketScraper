namespace SuperMarketScraper
{
    partial class Form3
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
            selection_list = new ListView();
            columnHeader1 = new ColumnHeader();
            removesel_btn = new Button();
            SuspendLayout();
            // 
            // selection_list
            // 
            selection_list.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            selection_list.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            selection_list.HeaderStyle = ColumnHeaderStyle.None;
            selection_list.LabelWrap = false;
            selection_list.Location = new Point(109, 52);
            selection_list.MultiSelect = false;
            selection_list.Name = "selection_list";
            selection_list.Size = new Size(659, 293);
            selection_list.TabIndex = 0;
            selection_list.UseCompatibleStateImageBehavior = false;
            selection_list.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "";
            columnHeader1.Width = 31;
            // 
            // removesel_btn
            // 
            removesel_btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            removesel_btn.Location = new Point(361, 385);
            removesel_btn.Name = "removesel_btn";
            removesel_btn.Size = new Size(152, 60);
            removesel_btn.TabIndex = 1;
            removesel_btn.Text = "Εκκαθάριση";
            removesel_btn.UseVisualStyleBackColor = true;
            removesel_btn.Click += removesel_btn_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 472);
            Controls.Add(removesel_btn);
            Controls.Add(selection_list);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
        }

        #endregion

        private ListView selection_list;
        private ColumnHeader columnHeader1;
        private Button removesel_btn;
    }
}