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
    public partial class EditForm : Form
    {
        private int id;
        private Form1 mainForm;

        public EditForm(int id, Form1 mainForm)
        {
            InitializeComponent();

            this.id = id;
            this.mainForm = mainForm;

            using (var ctx = new Model1Container()) 
            {
                /*
                var selectedAd = from ad in ctx.BargainAdsSet
                                 where ad.Id == id
                                 select new { ad.Id, ad.Brand, ad.Model, ad.Engine,
                                        ad.Year, ad.Price, ad.City, ad.FromDate, ad.ToDate };
                */

                var selectedAd = ctx.BargainAdsSet.First(i => i.Id == id);

                idLabel.Text    = id.ToString();
                brandTxt.Text   = selectedAd.Brand;
                modelTxt.Text   = selectedAd.Model;
                engineTxt.Text  = selectedAd.Engine;
                yearTxt.Text    = selectedAd.Year;
                priceTxt.Text   = selectedAd.Price;
                cityTxt.Text    = selectedAd.City;
                dateFrom.Text   = selectedAd.FromDate;
                dateTo.Text     = selectedAd.ToDate;

            }

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (var ctx = new Model1Container())
            {
                try
                {
                    var editedAd = ctx.BargainAdsSet.First(i => i.Id == id);

                    editedAd.Brand = brandTxt.Text;
                    editedAd.Model = modelTxt.Text;
                    editedAd.Engine = engineTxt.Text;
                    editedAd.Year = yearTxt.Text;
                    editedAd.Price = priceTxt.Text;
                    editedAd.City = cityTxt.Text;
                    editedAd.FromDate = dateFrom.Value.ToShortDateString();
                    editedAd.ToDate = dateTo.Value.ToShortDateString();

                    ctx.SaveChanges();

                    try
                    {
                        var ads = from carAds in ctx.BargainAdsSet
                                  select new { carAds.Id, carAds.Brand, carAds.Model, carAds.Engine,
                                carAds.Year, carAds.Price, carAds.City, carAds.FromDate, carAds.ToDate };

                        mainForm.source.ResetBindings(true);

                        mainForm.source.DataSource = ads.ToList();
                        mainForm.dataGridView1.DataSource = mainForm.source;

                        this.Close();

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
    }
}
