namespace SuperMarketScraper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            save_btn = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            sklavenitisList = new ListView();
            columnHeader2 = new ColumnHeader();
            tabPage2 = new TabPage();
            abList = new ListView();
            columnHeader3 = new ColumnHeader();
            tabPage3 = new TabPage();
            myMarketList = new ListView();
            columnHeader4 = new ColumnHeader();
            tabPage4 = new TabPage();
            masoutisList = new ListView();
            columnHeader5 = new ColumnHeader();
            orderListView = new ListView();
            columnHeader1 = new ColumnHeader();
            label1 = new Label();
            textBox1 = new TextBox();
            Add_Btn = new Button();
            label2 = new Label();
            checkBoxSklavenitis = new CheckBox();
            checkBoxAB = new CheckBox();
            checkBoxMarket = new CheckBox();
            checkBoxMasoutis = new CheckBox();
            searchbtn = new Button();
            panel1 = new Panel();
            sum_masout = new Label();
            sum_mymark = new Label();
            sum_ab = new Label();
            sum_skl = new Label();
            masout = new Label();
            mymrk = new Label();
            ab = new Label();
            skl = new Label();
            Cancel = new Button();
            delete_btn = new Button();
            saveCombo_box = new ComboBox();
            loadCombo_box = new ComboBox();
            load_btn = new Button();
            label3 = new Label();
            excel_btn = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // save_btn
            // 
            save_btn.Location = new Point(1198, 145);
            save_btn.Margin = new Padding(4);
            save_btn.Name = "save_btn";
            save_btn.Size = new Size(133, 31);
            save_btn.TabIndex = 0;
            save_btn.Text = "Save";
            save_btn.UseVisualStyleBackColor = true;
            save_btn.Click += savebtn_click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(14, 453);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(896, 386);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(sklavenitisList);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(888, 350);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Σκλαβενίτης";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // sklavenitisList
            // 
            sklavenitisList.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            sklavenitisList.HeaderStyle = ColumnHeaderStyle.None;
            sklavenitisList.Location = new Point(0, 0);
            sklavenitisList.MultiSelect = false;
            sklavenitisList.Name = "sklavenitisList";
            sklavenitisList.Size = new Size(888, 350);
            sklavenitisList.TabIndex = 0;
            sklavenitisList.UseCompatibleStateImageBehavior = false;
            sklavenitisList.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "";
            columnHeader2.Width = 1000;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(abList);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(888, 353);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "ΑΒ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // abList
            // 
            abList.Columns.AddRange(new ColumnHeader[] { columnHeader3 });
            abList.HeaderStyle = ColumnHeaderStyle.None;
            abList.Location = new Point(0, 0);
            abList.MultiSelect = false;
            abList.Name = "abList";
            abList.Size = new Size(888, 350);
            abList.TabIndex = 0;
            abList.UseCompatibleStateImageBehavior = false;
            abList.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "";
            columnHeader3.Width = 1000;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(myMarketList);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(4);
            tabPage3.Size = new Size(888, 353);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "My Market";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // myMarketList
            // 
            myMarketList.Columns.AddRange(new ColumnHeader[] { columnHeader4 });
            myMarketList.HeaderStyle = ColumnHeaderStyle.None;
            myMarketList.Location = new Point(0, 0);
            myMarketList.MultiSelect = false;
            myMarketList.Name = "myMarketList";
            myMarketList.Size = new Size(888, 350);
            myMarketList.TabIndex = 0;
            myMarketList.UseCompatibleStateImageBehavior = false;
            myMarketList.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "";
            columnHeader4.Width = 1000;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(masoutisList);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(888, 353);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Μασούτης";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // masoutisList
            // 
            masoutisList.Columns.AddRange(new ColumnHeader[] { columnHeader5 });
            masoutisList.HeaderStyle = ColumnHeaderStyle.None;
            masoutisList.Location = new Point(0, 0);
            masoutisList.MultiSelect = false;
            masoutisList.Name = "masoutisList";
            masoutisList.Size = new Size(888, 350);
            masoutisList.TabIndex = 0;
            masoutisList.UseCompatibleStateImageBehavior = false;
            masoutisList.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "";
            columnHeader5.Width = 1000;
            // 
            // orderListView
            // 
            orderListView.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            orderListView.HeaderStyle = ColumnHeaderStyle.None;
            orderListView.Location = new Point(14, 100);
            orderListView.Margin = new Padding(4);
            orderListView.Name = "orderListView";
            orderListView.Size = new Size(892, 225);
            orderListView.TabIndex = 3;
            orderListView.UseCompatibleStateImageBehavior = false;
            orderListView.View = View.Details;
            orderListView.DoubleClick += orderListView_Click;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "";
            columnHeader1.Width = 1000;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 40);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 23);
            label1.TabIndex = 4;
            label1.Text = "Πρόσθεσε στη λίστα: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(188, 37);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 30);
            textBox1.TabIndex = 5;
            // 
            // Add_Btn
            // 
            Add_Btn.Location = new Point(449, 37);
            Add_Btn.Margin = new Padding(4);
            Add_Btn.Name = "Add_Btn";
            Add_Btn.Size = new Size(100, 33);
            Add_Btn.TabIndex = 6;
            Add_Btn.Text = "Προσθήκη";
            Add_Btn.UseVisualStyleBackColor = true;
            Add_Btn.Click += addBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 347);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(206, 25);
            label2.TabIndex = 7;
            label2.Text = "Διάλεξε καταστήματα: ";
            // 
            // checkBoxSklavenitis
            // 
            checkBoxSklavenitis.AutoSize = true;
            checkBoxSklavenitis.Location = new Point(247, 348);
            checkBoxSklavenitis.Name = "checkBoxSklavenitis";
            checkBoxSklavenitis.Size = new Size(124, 27);
            checkBoxSklavenitis.TabIndex = 8;
            checkBoxSklavenitis.Text = "Σκλαβενίτης";
            checkBoxSklavenitis.UseVisualStyleBackColor = true;
            // 
            // checkBoxAB
            // 
            checkBoxAB.AutoSize = true;
            checkBoxAB.Location = new Point(377, 348);
            checkBoxAB.Name = "checkBoxAB";
            checkBoxAB.Size = new Size(53, 27);
            checkBoxAB.TabIndex = 9;
            checkBoxAB.Text = "ΑΒ";
            checkBoxAB.UseVisualStyleBackColor = true;
            // 
            // checkBoxMarket
            // 
            checkBoxMarket.AutoSize = true;
            checkBoxMarket.Location = new Point(436, 348);
            checkBoxMarket.Name = "checkBoxMarket";
            checkBoxMarket.Size = new Size(113, 27);
            checkBoxMarket.TabIndex = 10;
            checkBoxMarket.Text = "My Market";
            checkBoxMarket.UseVisualStyleBackColor = true;
            // 
            // checkBoxMasoutis
            // 
            checkBoxMasoutis.AutoSize = true;
            checkBoxMasoutis.Location = new Point(555, 348);
            checkBoxMasoutis.Name = "checkBoxMasoutis";
            checkBoxMasoutis.Size = new Size(112, 27);
            checkBoxMasoutis.TabIndex = 11;
            checkBoxMasoutis.Text = "Μασούτης";
            checkBoxMasoutis.UseVisualStyleBackColor = true;
            // 
            // searchbtn
            // 
            searchbtn.Location = new Point(18, 385);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(145, 50);
            searchbtn.TabIndex = 12;
            searchbtn.Text = "Αναζήτηση";
            searchbtn.UseVisualStyleBackColor = true;
            searchbtn.Click += searchBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(sum_masout);
            panel1.Controls.Add(sum_mymark);
            panel1.Controls.Add(sum_ab);
            panel1.Controls.Add(sum_skl);
            panel1.Controls.Add(masout);
            panel1.Controls.Add(mymrk);
            panel1.Controls.Add(ab);
            panel1.Controls.Add(skl);
            panel1.Location = new Point(951, 485);
            panel1.Name = "panel1";
            panel1.Size = new Size(380, 350);
            panel1.TabIndex = 13;
            // 
            // sum_masout
            // 
            sum_masout.AutoSize = true;
            sum_masout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            sum_masout.Location = new Point(161, 277);
            sum_masout.Name = "sum_masout";
            sum_masout.Size = new Size(0, 28);
            sum_masout.TabIndex = 7;
            // 
            // sum_mymark
            // 
            sum_mymark.AutoSize = true;
            sum_mymark.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            sum_mymark.Location = new Point(160, 198);
            sum_mymark.Name = "sum_mymark";
            sum_mymark.Size = new Size(0, 28);
            sum_mymark.TabIndex = 6;
            // 
            // sum_ab
            // 
            sum_ab.AutoSize = true;
            sum_ab.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            sum_ab.Location = new Point(89, 115);
            sum_ab.Name = "sum_ab";
            sum_ab.Size = new Size(0, 28);
            sum_ab.TabIndex = 5;
            // 
            // sum_skl
            // 
            sum_skl.AutoSize = true;
            sum_skl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            sum_skl.Location = new Point(174, 46);
            sum_skl.Name = "sum_skl";
            sum_skl.Size = new Size(0, 28);
            sum_skl.TabIndex = 4;
            // 
            // masout
            // 
            masout.AutoSize = true;
            masout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            masout.Location = new Point(38, 277);
            masout.Name = "masout";
            masout.Size = new Size(117, 28);
            masout.TabIndex = 3;
            masout.Text = "Μασούτης: ";
            // 
            // mymrk
            // 
            mymrk.AutoSize = true;
            mymrk.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mymrk.Location = new Point(38, 198);
            mymrk.Name = "mymrk";
            mymrk.Size = new Size(116, 28);
            mymrk.TabIndex = 2;
            mymrk.Text = "My Market: ";
            // 
            // ab
            // 
            ab.AutoSize = true;
            ab.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ab.Location = new Point(38, 115);
            ab.Name = "ab";
            ab.Size = new Size(45, 28);
            ab.TabIndex = 1;
            ab.Text = "ΑΒ: ";
            // 
            // skl
            // 
            skl.AutoSize = true;
            skl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            skl.Location = new Point(38, 46);
            skl.Name = "skl";
            skl.Size = new Size(130, 28);
            skl.TabIndex = 0;
            skl.Text = "Σκλαβενίτης: ";
            // 
            // Cancel
            // 
            Cancel.Location = new Point(208, 385);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(145, 50);
            Cancel.TabIndex = 14;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(396, 385);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(145, 50);
            delete_btn.TabIndex = 15;
            delete_btn.Text = "Διαγραφή";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // saveCombo_box
            // 
            saveCombo_box.DropDownStyle = ComboBoxStyle.DropDownList;
            saveCombo_box.FormattingEnabled = true;
            saveCombo_box.Items.AddRange(new object[] { "Καλάθι 1", "Καλάθι 2", "Καλάθι 3", "Καλάθι 4", "Καλάθι 5" });
            saveCombo_box.Location = new Point(990, 145);
            saveCombo_box.Name = "saveCombo_box";
            saveCombo_box.Size = new Size(177, 31);
            saveCombo_box.TabIndex = 16;
            // 
            // loadCombo_box
            // 
            loadCombo_box.DropDownStyle = ComboBoxStyle.DropDownList;
            loadCombo_box.FormattingEnabled = true;
            loadCombo_box.Location = new Point(990, 266);
            loadCombo_box.Name = "loadCombo_box";
            loadCombo_box.Size = new Size(177, 31);
            loadCombo_box.TabIndex = 18;
            // 
            // load_btn
            // 
            load_btn.Location = new Point(1198, 266);
            load_btn.Margin = new Padding(4);
            load_btn.Name = "load_btn";
            load_btn.Size = new Size(133, 31);
            load_btn.TabIndex = 17;
            load_btn.Text = "Load";
            load_btn.UseVisualStyleBackColor = true;
            load_btn.Click += loadbtn_click;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // excel_btn
            // 
            excel_btn.FlatAppearance.BorderSize = 0;
            excel_btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            excel_btn.Image = (Image)resources.GetObject("excel_btn.Image");
            excel_btn.Location = new Point(1162, 348);
            excel_btn.Name = "excel_btn";
            excel_btn.Size = new Size(169, 87);
            excel_btn.TabIndex = 19;
            excel_btn.Text = "Export to";
            excel_btn.TextImageRelation = TextImageRelation.TextBeforeImage;
            excel_btn.Click += excel_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 852);
            Controls.Add(excel_btn);
            Controls.Add(label3);
            Controls.Add(loadCombo_box);
            Controls.Add(load_btn);
            Controls.Add(saveCombo_box);
            Controls.Add(delete_btn);
            Controls.Add(Cancel);
            Controls.Add(panel1);
            Controls.Add(searchbtn);
            Controls.Add(checkBoxMasoutis);
            Controls.Add(checkBoxMarket);
            Controls.Add(checkBoxAB);
            Controls.Add(checkBoxSklavenitis);
            Controls.Add(label2);
            Controls.Add(orderListView);
            Controls.Add(Add_Btn);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Controls.Add(save_btn);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "SuperMarketScraper";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label1;
        private TextBox textBox1;
        private Button Add_Btn;
        public ListView orderListView;
        private ColumnHeader columnHeader1;
        private Label label2;
        private CheckBox checkBoxSklavenitis;
        private CheckBox checkBoxAB;
        private CheckBox checkBoxMarket;
        private CheckBox checkBoxMasoutis;
        private Button searchbtn;
        private TabPage tabPage4;
        private Panel panel1;
        private ListView sklavenitisList;
        private ListView abList;
        private ListView myMarketList;
        private ListView masoutisList;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button Cancel;
        private Button delete_btn;
        private Button save_btn;
        private ComboBox saveCombo_box;
        private ComboBox loadCombo_box;
        private Button load_btn;
        private Label label3;
        private Label sum_masout;
        private Label sum_mymark;
        private Label sum_ab;
        private Label sum_skl;
        private Label masout;
        private Label mymrk;
        private Label ab;
        private Label skl;
        private Button excel_btn;
    }
}