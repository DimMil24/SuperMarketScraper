using SuperMarketScraper.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using NPOI.SS.UserModel;
using WebDriverManager.Helpers;
using System.Security.Policy;
using System.Net;

namespace SuperMarketScraper.Services
{
    internal class Parser
    {
        public static HttpClient client = new HttpClient();
        public Parser() 
        {
            client.DefaultRequestHeaders.Add("Cookie", "Zone={\"ShippingType\":1,\"HubID\":9}");
        }

        public async Task SklavenitisData(Order query,int order_index,ListView list,Form frame,CancellationToken token, ListView.ListViewItemCollection original_order)
        {
            string search;
            if (query.Sklavenitis!=null)
            {
                search = query.Sklavenitis;
            } else
            {
                search = query.Name;
            }
            HtmlNodeCollection title;
            HtmlNodeCollection price;
            HtmlNodeCollection prices;

            while (true)
            {
                string uri = "https://www.sklavenitis.gr/apotelesmata-anazitisis/?Query=" + search.Trim().Replace(" ", "+");
                var cookieContainer = new CookieContainer();

                var response = await client.GetStringAsync(uri).ConfigureAwait(false);
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(response);
                title = document.DocumentNode.SelectNodes("//h4[@class='product__title']");
                price = document.DocumentNode.SelectNodes("//div[@class='price']");
                prices = document.DocumentNode.SelectNodes("//div[@class='main-price']");

                if (title == null)
                {
                    DialogResult result = DialogResult.Cancel;
                    string s = "Δεν βρέθηκε το προιόν " + search + " στον Σκλαβενίτη.\nΔώσε άλλη αναζήτηση (κενό για παράλειψη)";
                    Form4 form = new Form4(s, "Δεν βρέθηκε το προιόν");
                    frame.Invoke((MethodInvoker)delegate ()
                    {
                        result = form.ShowDialog();
                    });

                    if (result == DialogResult.Cancel )
                    {
                        return;
                    }
                    else if (result == DialogResult.OK)
                    {
                        search = form.New_search;
                        continue;
                    }
                }
                else break;
            }
            if (title.Count>1)
            {
                int num = title.Count();
                if (num > 15)
                {
                    num = 15;
                }
                List<Product> products = new List<Product>();
                string name;
                string price_entry;
                string price_sale;
                for (int i = 0; i < num; i++)
                {
                    if (prices[i].ChildNodes.Count > 3)
                    {
                        price_sale = prices[i].ChildNodes[1].InnerText.Split("/")[0].Replace(',', '.').Trim();
                    }
                    else
                    {
                        price_sale = "0";
                    }
                    name = title[i].InnerText.Trim();
                    price_entry = (price[i].InnerText.Split("€")[0].Replace(',', '.').Trim());
                    if (query.Sklavenitis != null)
                    {
                        if (query.Sklavenitis == (name))
                        {
                            ListViewItem listItem = new ListViewItem();
                            var pr = new Product(name, double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 1);
                            listItem.Tag = pr;
                            listItem.Text = pr.ToString();
                            list.Invoke((Action)delegate
                            {
                                list.Items.Add(listItem);
                                list.Columns[0].Width = -1;
                            });
                            return;
                        }
                    }
                    products.Add(new Product(name, double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 1));
                }
                token.ThrowIfCancellationRequested();
                Form2 form2 = new Form2(products,"Σκλαβενίτη");
                frame.Invoke((MethodInvoker)delegate ()
                {
                    form2.ShowDialog();
                });

                if (form2.Index != -1 )
                {
                    ListViewItem listItem = new ListViewItem();
                    listItem.Tag = products[form2.Index];
                    listItem.Text = products[form2.Index].ToString();
                    list.Invoke((Action)delegate
                    {
                        list.Items.Add(listItem);
                        list.Columns[0].Width = -1;
                        var a = original_order[order_index].Tag as Order;
                        a.Sklavenitis = products[form2.Index].Name;
                        original_order[order_index].Text = a.ToString();
                    });
                } else
                {
                    return;
                }

            } else
            {
                var name = title[0].InnerText.Trim();
                var price_entry = (price[0].InnerText.Split("€")[0].Replace(',', '.').Trim());
                string price_sale;
                if (prices[0].ChildNodes.Count > 3)
                {
                    price_sale = prices[0].ChildNodes[1].InnerText.Split("/")[0].Replace(',', '.').Trim();
                }
                else
                {
                    price_sale = "0";
                }
                ListViewItem listItem = new ListViewItem();
                var pr = new Product(name, double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 1);
                listItem.Tag = pr;
                listItem.Text = pr.ToString();
                list.Invoke((Action)delegate
                {
                    list.Items.Add(listItem);
                    list.Columns[0].Width = -1;
                });
            }
        }

        public async Task MyMarketData(Order query, int order_index,ListView list,Form frame,CancellationToken token, ListView.ListViewItemCollection original_order)
        {
            string search;
            if (query.Mymarket != null)
            {
                search = query.Mymarket;
            }
            else
            {
                search = query.Name;
            }
            HtmlNodeCollection title;
            HtmlNodeCollection price;
            while (true)
            {
                string uri = "https://www.mymarket.gr/search?query=" + search.Trim().Replace(" ", "+");
                var response = await client.GetStringAsync(uri).ConfigureAwait(false);
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(response);
                title = document.DocumentNode.SelectNodes("//article[@class='product--teaser w-full']/header/h3");
                price = document.DocumentNode.SelectNodes("//span[@class='price']");

                if (title == null)
                {
                    string s = "Δεν βρέθηκε το προιόν " + search + " στο My Market.\nΔώσε άλλη αναζήτηση (κενό για παράλειψη)";
                    DialogResult result = DialogResult.Cancel;
                    Form4 form = new Form4(s, "Δεν βρέθηκε το προιόν");
                    frame.Invoke((MethodInvoker)delegate ()
                    {
                        result = form.ShowDialog();
                    });
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (result == DialogResult.OK)
                    {
                        search = form.New_search;
                        continue;
                        //MyMarketData(query, order_index, list, frame, token, original_order);
                    }
                    //return;
                }
                else break;
            }
            if (title.Count > 1)
            {
                int num = title.Count();
                if (num > 15)
                {
                    num = 15;
                }
                List<Product> products = new List<Product>();
                string name;
                string price_entry;
                string price_sale;
                for (int i = 0; i < num; i++)
                {
                    name = title[i].InnerText.Trim();
                    price_entry = price[i].InnerText.Split("€")[0].Replace(',', '.').Trim();
                    if (price[i].NextSibling.NextSibling != null)
                    {   
                        price_sale = price[i].NextSibling.NextSibling.InnerText.Split("€")[0].Replace(',', '.').Trim();
                    }
                    else
                    {
                        price_sale = "0";
                    }
                    if (query.Mymarket != null)
                    {
                        if (query.Mymarket == (name))
                        {
                            ListViewItem listItem = new ListViewItem();
                            var pr = new Product(name, double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 3);
                            listItem.Tag = pr;
                            listItem.Text = pr.ToString();
                            list.Invoke((Action)delegate
                            {
                                list.Items.Add(listItem);
                                list.Columns[0].Width = -1;
                            });
                            return;
                        }
                    }
                    products.Add(new Product(name, double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 3));
                }
                token.ThrowIfCancellationRequested();
                Form2 form2 = new Form2(products,"My Market");
                frame.Invoke((MethodInvoker)delegate () {
                    form2.ShowDialog();
                });
                if (form2.Index != -1)
                {
                    ListViewItem listItem = new ListViewItem();
                    listItem.Tag = products[form2.Index];
                    listItem.Text = products[form2.Index].ToString();
                    list.Invoke((Action)delegate
                    {
                        list.Items.Add(listItem);
                        list.Columns[0].Width = -1;
                        var a = original_order[order_index].Tag as Order;
                        a.Mymarket = products[form2.Index].Name;
                        original_order[order_index].Text = a.ToString();
                    });
                }
                else
                {
                    return;
                }
            } else
            {
                var name = title[0].InnerText.Trim();
                var price_entry = price[0].InnerText.Split("€")[0].Replace(',', '.').Trim();
                string price_sale;
                if (price[0].NextSibling != null)
                {
                    if (price[0].NextSibling.NextSibling != null)
                    {
                        price_sale = price[0].NextSibling.NextSibling.InnerText.Split("€")[0].Replace(',', '.').Trim();
                    }
                    else
                    {
                        price_sale = "0";
                    }
                }
                else
                {
                    price_sale = "0";
                }
                ListViewItem listItem = new ListViewItem();
                var pr = new Product(name, double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 3);
                listItem.Tag = pr;
                listItem.Text = pr.ToString();
                list.Invoke((Action)delegate
                {
                    list.Items.Add(listItem);
                    list.Columns[0].Width = -1;
                });
            }
        }

        public async Task ABData(List<Order> query, int order_index,ListView list, Form frame, CancellationToken token, ListView.ListViewItemCollection original_order)
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var options = new ChromeOptions();
            options.AddArguments("headless");
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var driver = new ChromeDriver(service, options);

            try
            {
                for (int j = 0; j < query.Count; j++)
                {
                    string search;
                    if (query[j].Ab != null)
                    {
                        search = query[j].Ab;
                    }
                    else
                    {
                        search = query[j].Name;
                    }
                    bool should_skip = false;
                    while (true)
                    {
                        string uri = "https://www.ab.gr/eshop/search?q=" + search;
                        driver.Navigate().GoToUrl(uri);
                        try
                        {
                            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3.5));
                            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[class='sc-6ohwvl-2 bmUsbA']")));
                        }
                        catch (OpenQA.Selenium.WebDriverTimeoutException ex)
                        {
                            DialogResult result = DialogResult.Cancel;
                            string s = "Δεν βρέθηκε το προιόν " + search + " στον AB.\nΔώσε άλλη αναζήτηση (κενό για παράλειψη)";
                            Form4 form = new Form4(s, "Δεν βρέθηκε το προιόν");
                            frame.Invoke((MethodInvoker)delegate () {
                                result = form.ShowDialog();
                            });
                            if (result == DialogResult.Cancel)
                            {
                                should_skip = true;
                                break;
                            }
                            else if (result == DialogResult.OK)
                            {
                                search = form.New_search;
                                continue;
                            }
                        }
                        break;
                    }
                    if (should_skip) continue;
                    var Item = driver.FindElement(By.CssSelector("div[class='sc-6ohwvl-2 bmUsbA']"));
                    var children = Item.FindElements(By.XPath("./*"));
                    if (children.Count > 1)
                    {
                        int num = children.Count();
                        if (num > 15)
                        {
                            num = 15;
                        }
                        List<Product> products = new List<Product>();
                        string name;
                        string price_entry;
                        string price_sale;
                        bool found = false;
                        for (int i = 0; i < num; i++)
                        {
                            name = children[i].FindElement(By.CssSelector("a[data-testid='product-block-name-link']")).GetAttribute("innerText").Trim();
                            try
                            {
                                string brand = children[i].FindElement(By.CssSelector("div[data-testid='product-block-brand-name']")).FindElement(By.XPath("./child::*")).GetAttribute("innerText").Trim();
                                if (!(brand == "-")) name = brand + " " + name;
                            }
                            catch (NoSuchElementException e)
                            {

                            }
                            try
                            {
                                price_entry = children[i].FindElement(By.CssSelector("div[data-testid='product-block-price']")).GetAttribute("innerText").Split("€")[1].Replace(',', '.').Trim();
                                try
                                {
                                    price_sale = children[i].FindElement(By.CssSelector("span[data-testid='product-block-old-price']")).GetAttribute("innerText").Split("€")[1].Replace(',', '.').Trim();
                                }
                                catch (NoSuchElementException e)
                                {
                                    price_sale = "0";
                                }
                                if (query[j].Ab != null)
                                {

                                    if (query[j].Ab == name)
                                    {
                                        ListViewItem listItem = new ListViewItem();
                                        Product pr = new Product(name,
                                    double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 2);
                                        listItem.Tag = pr;
                                        listItem.Text = pr.ToString();
                                        list.Invoke((Action)delegate
                                        {
                                            list.Items.Add(listItem);
                                            list.Columns[0].Width = -1;
                                        });
                                        found = true;
                                        break;
                                    }
                                }
                            }
                            catch (NoSuchElementException e)
                            {
                                price_entry = "0";
                                price_sale = "0";
                            }

                            products.Add(new Product(name,
                                    double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 2));
                        }
                        if (found) continue;
                        token.ThrowIfCancellationRequested();
                        Form2 form2 = new Form2(products, "AB");
                        frame.Invoke((MethodInvoker)delegate () {
                            form2.ShowDialog();
                        });
                        if (form2.Index != -1)
                        {
                            ListViewItem listItem = new ListViewItem();
                            listItem.Tag = products[form2.Index];
                            listItem.Text = products[form2.Index].ToString();
                            list.Invoke((Action)delegate
                            {
                                list.Items.Add(listItem);
                                list.Columns[0].Width = -1;
                                var a = original_order[j].Tag as Order;
                                a.Ab = products[form2.Index].Name;
                                original_order[j].Text = a.ToString();
                            });
                        }
                        else
                        {
                            continue;
                        }
                    } else
                    {
                        var name = children[0].FindElement(By.CssSelector("a[data-testid='product-block-name-link']")).GetAttribute("innerText").Trim();
                        var price_entry = children[0].FindElement(By.CssSelector("div[data-testid='product-block-price']")).GetAttribute("innerText").Split("€")[1].Replace(',', '.').Trim();
                        string price_sale;
                        try
                        {
                            price_sale = children[0].FindElement(By.CssSelector("span[data-testid='product-block-old-price']")).GetAttribute("innerText").Split("€")[1].Replace(',', '.').Trim();
                        }
                        catch (NoSuchElementException e)
                        {
                            price_sale = "0";
                        }
                        ListViewItem listItem = new ListViewItem();
                        var pr = new Product(name,
                                    double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 2);
                        listItem.Tag = pr;
                        listItem.Text = pr.ToString();
                        list.Invoke((Action)delegate
                        {
                            list.Items.Add(listItem);
                            list.Columns[0].Width = -1;
                            var a = original_order[j].Tag as Order;
                            a.Ab = pr.Name;
                            original_order[j].Text = a.ToString();
                        });
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("AB ERROR" + ex.Message);
            } finally {
                driver.Quit();
            }
        }

        public async Task MasoutisData(List<Order> query, int order_index, ListView list, Form frame, CancellationToken token, ListView.ListViewItemCollection original_order)
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var options = new ChromeOptions();
            options.AddArguments("headless");
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var driver = new ChromeDriver(service, options);

            try
            {
                for (int j = 0; j < query.Count; j++)
                {
                    string search;
                    if (query[j].Masoutis != null)
                    {
                        search = query[j].Masoutis;
                    }
                    else
                    {
                        search = query[j].Name;
                    }
                    bool should_skip = false;
                    while (true)
                    {
                        string uri = "https://eshop.masoutis.gr/categories/index/search?text=" + search;
                        driver.Navigate().GoToUrl(uri);
                        try
                        {
                            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3.5));
                            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[class='productTitle ng-binding']")));
                        }
                        catch (OpenQA.Selenium.WebDriverTimeoutException ex)
                        {
                            string s = "Δεν βρέθηκε το προιόν " + search + " στον Μασούτη.\nΔώσε άλλη αναζήτηση (κενό για παράλειψη)";
                            Form4 form = new Form4(s, "Δεν βρέθηκε το προιόν");
                            DialogResult result = DialogResult.Cancel;
                            frame.Invoke((MethodInvoker)delegate () {
                                result = form.ShowDialog();
                            });
                            if (result == DialogResult.Cancel)
                            {
                                should_skip = true;
                                break;
                            }
                            else if (result == DialogResult.OK) { }
                            {
                                search = form.New_search;
                                continue;
                            }
                        }
                        break;
                    }
                    if (should_skip) continue;
                    var Item = driver.FindElements(By.CssSelector("div[class='product ng-scope']"));
                    if (Item.Count/2 > 1)
                    {
                        int num = Item.Count()/2;
                        if (num > 15)
                        {
                            num = 15;
                        }
                        List<Product> products = new List<Product>();
                        string name;
                        string price_entry;
                        string price_sale;
                        bool found = false;
                        for (int i = 0; i < num; i++)
                        {
                            name = Item[i].FindElement(By.CssSelector("div[class='productTitle ng-binding']")).GetAttribute("innerText").Trim();
                            try
                            {
                                price_entry = Item[i].FindElement(By.CssSelector("div[ng-show='p.StartPrice==p.PosPrice']")).GetAttribute("innerText").Split("€")[0].Replace(',', '.').Trim();
                                try
                                {
                                    price_sale = Item[i].FindElement(By.CssSelector("div[ng-show='p.StartPrice!=p.PosPrice']")).FindElement(By.CssSelector("div[class='pStartPrice ng-binding']")).GetAttribute("innerText").Split("€")[0].Replace(',', '.').Trim();
                                    if (price_sale == price_entry)
                                    {
                                        price_sale = "0";
                                    }
                                }
                                catch (NoSuchElementException e)
                                {
                                    price_sale = "0";
                                }
                                if (query[j].Masoutis != null)
                                {

                                    if (query[j].Masoutis == name)
                                    {
                                        ListViewItem listItem = new ListViewItem();
                                        Product pr = new Product(name,
                                        double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 4);
                                        listItem.Tag = pr;
                                        listItem.Text = pr.ToString();
                                        list.Invoke((Action)delegate
                                        {
                                            list.Items.Add(listItem);
                                            list.Columns[0].Width = -1;
                                        });
                                        found = true;
                                        break;
                                    }
                                }
                            }
                            catch (NoSuchElementException e)
                            {
                                price_entry = "0";
                                price_sale = "0";
                            }

                            products.Add(new Product(name,
                                    double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 4));
                        }
                        if (found) continue;
                        token.ThrowIfCancellationRequested();
                        Form2 form2 = new Form2(products, "Μασούτη");
                        frame.Invoke((MethodInvoker)delegate () {
                            form2.ShowDialog();
                        });
                        if (form2.Index != -1)
                        {
                            ListViewItem listItem = new ListViewItem();
                            listItem.Tag = products[form2.Index];
                            listItem.Text = products[form2.Index].ToString();
                            list.Invoke((Action)delegate
                            {
                                list.Items.Add(listItem);
                                list.Columns[0].Width = -1;
                                var a = original_order[j].Tag as Order;
                                a.Masoutis = products[form2.Index].Name;
                                original_order[j].Text = a.ToString();
                            });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        var name = Item[0].FindElement(By.CssSelector("div[class='productTitle ng-binding']")).GetAttribute("innerText").Trim();
                        var price_entry = Item[0].FindElement(By.CssSelector("div[ng-show='p.StartPrice==p.PosPrice']")).GetAttribute("innerText").Split("€")[0].Replace(',', '.').Trim();
                        string price_sale;
                        try
                        {
                            price_sale = Item[0].FindElement(By.CssSelector("div[ng-show='p.StartPrice!=p.PosPrice']")).FindElement(By.CssSelector("div[class='pStartPrice ng-binding']")).GetAttribute("innerText").Split("€")[0].Replace(',', '.').Trim();
                            if (price_sale == price_entry)
                            {
                                price_sale = "0";
                            }
                        }
                        catch (NoSuchElementException e)
                        {
                            price_sale = "0";
                        }
                        ListViewItem listItem = new ListViewItem();
                        var pr = new Product(name,
                                    double.Parse(price_entry, System.Globalization.CultureInfo.InvariantCulture), double.Parse(price_sale, System.Globalization.CultureInfo.InvariantCulture), 4);
                        listItem.Tag = pr;
                        listItem.Text = pr.ToString();
                        list.Invoke((Action)delegate
                        {
                            list.Items.Add(listItem);
                            list.Columns[0].Width = -1;
                            var a = original_order[j].Tag as Order;
                            a.Masoutis = pr.Name;
                            original_order[j].Text = a.ToString();
                        });
                    }
                }
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
