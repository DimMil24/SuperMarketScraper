using SuperMarketScraper.Model;


namespace SuperMarketScraper
{
    public partial class Form2 : Form
    {
        public int Index { get; set; }
        public Form2(List<Product> products, string m)
        {
            InitializeComponent();
            this.Text = "Διάλεξε προιόν απο " + m;
            Index = -1;
            foreach (Product product in products)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Tag = product;
                listItem.Text = product.ToString();
                modalList.Items.Add(listItem);
            }
            modalList.Columns[0].Width = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ind = modalList.SelectedIndices;
            if (ind.Count > 0)
            {
                Index = ind[0];
                this.DialogResult = DialogResult.Yes;
            }

        }
    }
}
