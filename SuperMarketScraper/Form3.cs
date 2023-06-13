using SuperMarketScraper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketScraper
{
    public partial class Form3 : Form
    {
        public Order order;
        public Form3(Order order)
        {
            InitializeComponent();
            this.order = order;
            this.Text = order.Name;
            ListViewItem listItem = new ListViewItem();
            listItem.Tag = order;
            string text;
            if (order.Sklavenitis != null)
            {
                text = order.Sklavenitis.ToString();
            }
            else
            {
                text = "(Κενό)";
            }
            listItem.Text = "Σκλαβενίτης: " + text;
            selection_list.Items.Add(listItem);
            listItem = new ListViewItem();
            listItem.Tag = order;
            if (order.Ab != null)
            {
                text = order.Ab.ToString();
            }
            else
            {
                text = "(Κενό)";
            }
            listItem.Text = "ΑΒ: " + text;
            selection_list.Items.Add(listItem);
            listItem = new ListViewItem();
            listItem.Tag = order;
            if (order.Mymarket != null)
            {
                text = order.Mymarket.ToString();
            }
            else
            {
                text = "(Κενό)";
            }
            listItem.Text = "My Market: " + text;
            selection_list.Items.Add(listItem);
            listItem = new ListViewItem();
            listItem.Tag = order;
            if (order.Masoutis != null)
            {
                text = order.Masoutis.ToString();
            }
            else
            {
                text = "(Κενό)";
            }
            listItem.Text = "Μασούτης: " + text;
            selection_list.Items.Add(listItem);
            selection_list.Columns[0].Width = -1;
        }

        private void removesel_btn_Click(object sender, EventArgs e)
        {
            if (selection_list.SelectedItems.Count == 0) return;
            var item = selection_list.SelectedItems[0].Tag as Order;
            if (selection_list.SelectedIndices[0] == 0)
            {
                item.Sklavenitis = null;
                selection_list.SelectedItems[0].Text = "Σκλαβενίτης: (Κενό)";
            }
            if (selection_list.SelectedIndices[0] == 1)
            {
                item.Ab = null;
                selection_list.SelectedItems[0].Text = "AB: (Κενό)";
            }
            if (selection_list.SelectedIndices[0] == 2)
            {
                item.Mymarket = null;
                selection_list.SelectedItems[0].Text = "My Market: (Κενό)";
            }
            if (selection_list.SelectedIndices[0] == 3)
            {
                item.Masoutis = null;
                selection_list.SelectedItems[0].Text = "Μασούτης: (Κενό)";
            }
        }
    }
}
