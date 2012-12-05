using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCarBargainApp
{
    public partial class Form1 : Form
    {

        public BindingSource source;

        public Form1()
        {
            InitializeComponent();

            source = new BindingSource();

            using (var ctx = new Model1Container())
            {
                var ads = from carAds in ctx.BargainAdsSet
                          select new { carAds.Id, carAds.Brand, carAds.Model, carAds.Engine,
                                carAds.Year, carAds.Price, carAds.City, carAds.FromDate, carAds.ToDate };

                source.ResetBindings(true);
                source.DataSource = ads.ToList();

                try
                {
                    dataGridView1.DataSource = source;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (var ctx = new Model1Container())
            {
                try
                {
                    BargainAds newCarAd = new BargainAds
                    {
                        Brand = brandTxt.Text,
                        Model = modelTxt.Text,
                        Engine = engineTxt.Text,
                        Year = yearTxt.Text,
                        Price = priceTxt.Text,
                        City = cityTxt.Text,
                        FromDate = dateFrom.Value.ToShortDateString(),
                        ToDate = dateTo.Value.ToShortDateString()
                    };

                    ctx.BargainAdsSet.Add(newCarAd);
                    ctx.SaveChanges();

                   
                    try
                    {
                        var ads = from carAds in ctx.BargainAdsSet
                                  select new { carAds.Id, carAds.Brand, carAds.Model, carAds.Engine,
                                carAds.Year, carAds.Price, carAds.City, carAds.FromDate, carAds.ToDate };

                        source.ResetBindings(true);

                        source.DataSource = ads.ToList();
                        dataGridView1.DataSource = source;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    } 

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int id = (int)dataGridView1["Id", row].Value;

            using (var ctx = new Model1Container())
            {
                try
                {
                    var selectedAd = ctx.BargainAdsSet.First(i => i.Id == id);
                    ctx.BargainAdsSet.Remove(selectedAd);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

                try
                    {
                        var ads = from carAds in ctx.BargainAdsSet
                                  select new { carAds.Id, carAds.Brand, carAds.Model, carAds.Engine,
                                carAds.Year, carAds.Price, carAds.City, carAds.FromDate, carAds.ToDate };

                        source.ResetBindings(true);

                        source.DataSource = ads.ToList();
                        dataGridView1.DataSource = source;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    } 
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int id = (int)dataGridView1["Id", row].Value;

            EditForm editForm = new EditForm(id, this);
            editForm.Show();
        }

    }
}
