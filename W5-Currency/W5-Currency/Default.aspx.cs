using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using W5_Currency.CurrencyConverter;

namespace W5_Currency
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //currencyA.Items.Add("GBP");
                //currencyA.Items.Add("USD");
                //currencyA.Items.Add("EUR");
                //currencyB.Items.Add("GBP");
                //currencyB.Items.Add("USD");
                //currencyB.Items.Add("EUR");
                //foreach (Currency ccy in Enum.GetValues(typeof(Currency)))
                //{
                //    currencyA.Items.Add(ccy.ToString());
                //    currencyB.Items.Add(ccy.ToString());
                //}

                BindDropDownListData();
                SetDefaultDropDownListCurrencies();

                Page.Form.DefaultButton = buttonConvert.UniqueID;
                currencyAmount.Focus();
            }
        }

        private void SetDefaultDropDownListCurrencies()
        {
            currencyA.Items.FindByText("GBP").Selected = true;
            currencyB.Items.FindByText("EUR").Selected = true;
        }

        private void BindDropDownListData()
        {
            var items = Enum.GetNames(typeof(Currency));
            Array.Sort(items);

            currencyA.DataSource = items;
            currencyA.DataBind();
            currencyB.DataSource = items;
            currencyB.DataBind();
        }

        protected void buttonConvert_Click(object sender, EventArgs e)
        {
            // Check to make sure no-one has tried to subvert the Javascript
            Page.Validate();
            if (Page.IsValid)
            {
                resultAmount.Text = ConvertCurrency();
            }
        }

        private string ConvertCurrency()
        {
            var cs = new CurrencyService();
            int amount = 0;
            if (int.TryParse(currencyAmount.Text, out amount) == true)
            {
                return String.Format("You will receive: {0:0.00} {1}", 
                    cs.ExchangeCurrency(amount, currencyA.SelectedValue, currencyB.SelectedValue), 
                    currencyB.SelectedValue);
            }
            else
            {
                return "Could not convert amount. Sorry.";
            }
        }
    }
}