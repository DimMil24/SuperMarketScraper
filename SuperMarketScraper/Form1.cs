using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using SuperMarketScraper.Model;
using SuperMarketScraper.Services;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.Design.AxImporter;

namespace SuperMarketScraper
{
    public partial class Form1 : Form
    {
        Parser p;
        List<Order> tempOrders = new List<Order>();
        private CancellationTokenSource _cts;
        string path;

        public Form1(string path)
        {
            InitializeComponent();
            p = new Parser();
            saveCombo_box.SelectedIndex = 0;
            this.path = path;
            DirectoryInfo d = new DirectoryInfo(this.path);
            foreach (var file in d.GetFiles("*.sav"))
            {
                loadCombo_box.Items.Add(file.Name.Split('.')[0]);
            }
            if (loadCombo_box.Items.Count > 0)
            {
                loadCombo_box.SelectedIndex = 0;
            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            if (orderListView.Items.Count <= 0)
            {
                MessageBox.Show("Πρόσθεσε τουλάχιστον ένα προιόν για αναζήτηση πρώτα." +
                    "(Γράψε το προιόν κατω αριστερά και πάτα το κουμπι 'Προσθήκη Προιόν' )"); return;
            }
            if (!checkBoxSklavenitis.Checked && !checkBoxMarket.Checked && !checkBoxAB.Checked && !checkBoxMasoutis.Checked)
            {
                MessageBox.Show("Διάλεξε τουλάχιστον ένα σουπερμάρκετ πρώτα");
                return;
            }
            else
            {
                checkBoxSklavenitis.Enabled = false;
                checkBoxAB.Enabled = false;
                checkBoxMarket.Enabled = false;
                checkBoxMasoutis.Enabled = false;
            }
            if (tempOrders.Count > 0) tempOrders.Clear();
            if (sklavenitisList.Items.Count > 0) sklavenitisList.Items.Clear();
            if (myMarketList.Items.Count > 0) myMarketList.Items.Clear();
            if (abList.Items.Count > 0) abList.Items.Clear();
            if (masoutisList.Items.Count > 0) masoutisList.Items.Clear();

            foreach (var o in orderListView.Items)
            {
                var hm = (ListViewItem)o;
                tempOrders.Add((Order)hm.Tag);
            }
            save_btn.Enabled = false;
            load_btn.Enabled = false;
            searchbtn.Enabled = false;
            delete_btn.Enabled = false;
            Add_Btn.Enabled = false;
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            double sumsk = 0;
            double summy = 0;
            double sumab = 0;
            double summa = 0;
            try
            {
                await Task.Run(async () =>
                {
                    if (checkBoxSklavenitis.Checked)
                    {
                        for (int i = 0; i < tempOrders.Count; i++)
                        {
                            Order? order = tempOrders[i];
                            token.ThrowIfCancellationRequested();
                            await p.SklavenitisData(order, i, sklavenitisList, this, token, orderListView.Items);
                        }
                    }
                    if (checkBoxMarket.Checked)
                    {
                        for (int i = 0; i < tempOrders.Count; i++)
                        {
                            Order? order = tempOrders[i];
                            token.ThrowIfCancellationRequested();
                            await p.MyMarketData(order, i, myMarketList, this, token, orderListView.Items);
                        }
                    }
                    if (checkBoxAB.Checked)
                    {
                        token.ThrowIfCancellationRequested();
                        await p.ABData(tempOrders, -1, abList, this, token, orderListView.Items);
                    }
                    if (checkBoxMasoutis.Checked)
                    {
                        token.ThrowIfCancellationRequested();
                        await p.MasoutisData(tempOrders, -1, masoutisList, this, token, orderListView.Items);
                    }
                    token.ThrowIfCancellationRequested();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            checkBoxSklavenitis.Enabled = true;
            checkBoxAB.Enabled = true;
            checkBoxMarket.Enabled = true;
            checkBoxMasoutis.Enabled = true;
            save_btn.Enabled = true;
            load_btn.Enabled = true;
            searchbtn.Enabled = true;
            delete_btn.Enabled = true;
            Add_Btn.Enabled = true;
            for (int i = 0; i < sklavenitisList.Items.Count; i++)
            {
                sumsk = sumsk + ((Product)sklavenitisList.Items[i].Tag).Price;
            }
            for (int i = 0; i < myMarketList.Items.Count; i++)
            {
                summy = summy + ((Product)myMarketList.Items[i].Tag).Price;
            }
            for (int i = 0; i < abList.Items.Count; i++)
            {
                sumab = sumab + ((Product)abList.Items[i].Tag).Price;
            }
            for (int i = 0; i < masoutisList.Items.Count; i++)
            {
                summa = summa + ((Product)masoutisList.Items[i].Tag).Price;
            }

            sum_skl.Text = Math.Round(sumsk, 2, MidpointRounding.AwayFromZero).ToString("#0.00") + " €";
            sum_mymark.Text = Math.Round(summy, 2, MidpointRounding.AwayFromZero).ToString("#0.00") + " €";
            sum_ab.Text = Math.Round(sumab, 2, MidpointRounding.AwayFromZero).ToString("#0.00") + " €";
            sum_masout.Text = Math.Round(summa, 2, MidpointRounding.AwayFromZero).ToString("#0.00") + " €";
            MessageBox.Show("Σκλαβενίτης: " + Math.Round(sumsk, 2, MidpointRounding.AwayFromZero).ToString("#0.00") + " €\nΑΒ: " + Math.Round(sumab, 2, MidpointRounding.AwayFromZero).ToString("#0.00") + 
                " €\nMy Market: " + Math.Round(summy, 2, MidpointRounding.AwayFromZero).ToString("#0.00")
                + " €\nΜασούτης " + Math.Round(summa, 2, MidpointRounding.AwayFromZero).ToString("#0.00") + " €");
            orderListView.Columns[0].Width = -1;
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            if (_cts != null)
                _cts.Cancel();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("Γράψε πρώτα προιόν.");
                return;
            }
            var order_name = textBox1.Text.TrimStart();
            Order order = new Order(order_name);
            ListViewItem listItem = new ListViewItem();
            listItem.Tag = order;
            listItem.Text = order.ToString();
            orderListView.Items.Add(listItem);
            orderListView.Columns[0].Width = -1;
            textBox1.Clear();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (orderListView.SelectedIndices.Count > 0) orderListView.Items.RemoveAt(orderListView.SelectedIndices[0]);

        }

        private void savebtn_click(object sender, EventArgs e)
        {
            if (orderListView.Items.Count <= 0)
            {
                MessageBox.Show("Πρόσθεσε τουλάχιστον μια παραγγελία.");
                return;
            }
            var list = new Order[orderListView.Items.Count];
            var items = orderListView.Items;
            for (int i = 0; i < items.Count; i++)
            {
                var o = (ListViewItem)items[i];
                list[i] = (Order)o.Tag;
            }
            string json = JsonSerializer.Serialize(list);
            File.WriteAllTextAsync(Path.Combine(path, saveCombo_box.SelectedItem + ".sav"), json);
            if (!loadCombo_box.Items.Contains(saveCombo_box.SelectedItem)) loadCombo_box.Items.Add(saveCombo_box.SelectedItem);
        }

        private async void loadbtn_click(Object sender, EventArgs e)
        {
            try
            {
                string p = Path.Combine(path, loadCombo_box.SelectedItem + ".sav");
                using (var sr = new StreamReader(p))
                {
                    orderListView.Items.Clear();
                    string result = await sr.ReadToEndAsync();
                    var des = JsonSerializer.Deserialize<Order[]>(result);
                    for (int i = 0; i < des.Length; i++)
                    {
                        ListViewItem listItem = new ListViewItem();
                        listItem.Tag = des[i];
                        listItem.Text = des[i].ToString();
                        orderListView.Items.Add(listItem);
                    }
                    orderListView.Columns[0].Width = -1;
                }
            }
            catch (FileNotFoundException ex)
            {
                if (loadCombo_box.Items.Count <= 0)
                {
                    MessageBox.Show("Αποθήκευσε πρώτα καλάθι");
                    return;
                }
                MessageBox.Show("Διάλεξε πρώτα καλάθι");
            }
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            if (sklavenitisList.Items.Count == 0 && abList.Items.Count == 0 && myMarketList.Items.Count == 0 && masoutisList.Items.Count == 0)
            {
                MessageBox.Show("Τρέξε το πρόγραμμα μια φόρα πρώτα");
                return;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel File|*.xlsx";
            saveFileDialog1.Title = "Save to Excel File";
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.ShowDialog();

            using (XSSFWorkbook workbook = new XSSFWorkbook())
            {
                var format = workbook.CreateDataFormat();
                var sheet = workbook.CreateSheet("Supermarket Data");
                var pr = new List<Product>();
                for (int i = 0; i < sklavenitisList.Items.Count; i++)
                {
                    pr.Add((Product)sklavenitisList.Items[i].Tag);
                }
                for (int i = 0; i < abList.Items.Count; i++)
                {
                    pr.Add((Product)abList.Items[i].Tag);

                }
                for (int i = 0; i < myMarketList.Items.Count; i++)
                {
                    pr.Add((Product)myMarketList.Items[i].Tag);
                }
                for (int i = 0; i < masoutisList.Items.Count; i++)
                {
                    pr.Add((Product)masoutisList.Items[i].Tag);

                }
                var rowStart = sheet.CreateRow(0);
                var cellStart = rowStart.CreateCell(0);
                cellStart.SetCellValue("Retailer");
                cellStart = rowStart.CreateCell(1);
                cellStart.SetCellValue("Product");
                cellStart = rowStart.CreateCell(2);
                cellStart.SetCellValue("Initial E-Shop Price");
                cellStart = rowStart.CreateCell(3);
                cellStart.SetCellValue("Promo E-Shop Price");
                cellStart = rowStart.CreateCell(4);
                DateTime dateTime = DateTime.Now;
                var date_now = dateTime.ToString("HH:mm:ss dd/MM/yyyy");
                cellStart.SetCellValue(date_now);
                int rownum = 1;
                foreach (var p in pr)
                {
                    var row = sheet.CreateRow(rownum++);
                    for (int i = 0; i < 4; i++)
                    {
                        var cell = row.CreateCell(i);
                        if (i == 0) cell.SetCellValue(p.getSuperMarketName());
                        if (i == 1) cell.SetCellValue(p.Name);
                        if (i == 2)
                        {
                            if (p.hasSale() == 1)
                            {
                                cell.SetCellValue((p.Sale));
                            }
                            else
                            {
                                cell.SetCellValue((p.Price));
                            }
                        }
                        if (i == 3)
                        {
                            if (p.hasSale() == 1) cell.SetCellValue((p.Price));
                        }
                    }
                }
                if (!saveFileDialog1.FileName.Equals(""))
                {
                    using (var fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(fs);
                        workbook.Close();
                    }
                }

            }
        }

        private void orderListView_Click(object sender, EventArgs e)
        {
            var h = orderListView.SelectedItems[0].Tag as Order;
            Form form = new Form3(h);
            form.ShowDialog();
            orderListView.SelectedItems[0].Text = h.ToString();
        }
    }
}