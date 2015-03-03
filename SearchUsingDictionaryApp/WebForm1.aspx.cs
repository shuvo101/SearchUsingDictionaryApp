using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SearchUsingDictionaryApp.Models;

namespace SearchUsingDictionaryApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CountriesData"] == null)
            {

                Country country1 = new Country() {Code = "ASU", Name = "AUSTRAILA", Capital = "Canberra"};
                Country country2 = new Country() {Code = "BAN", Name = "BANGLADESH", Capital = "Dhaka"};
                Country country3 = new Country() {Code = "USA", Name = "USA", Capital = "Washington D.C."};
                Country country4 = new Country() {Code = "GBR", Name = "UNITED STATES", Capital = "London"};
                Country country5 = new Country() {Code = "CAN", Name = "CANADA", Capital = "Ottawa"};

                Dictionary<string, Country> dictionaryCountries = new Dictionary<string, Country>();
                dictionaryCountries.Add(country1.Code, country1);
                dictionaryCountries.Add(country2.Code, country2);
                dictionaryCountries.Add(country3.Code, country3);
                dictionaryCountries.Add(country4.Code, country4);
                dictionaryCountries.Add(country5.Code, country5);

                Session["CountriesData"] = dictionaryCountries;
            }
        }

        protected void txtCountryCode_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string, Country> dictionaryCountries = (Dictionary<string, Country>)Session["CountriesData"];

            Country resultCountry = dictionaryCountries.ContainsKey(txtCountryCode.Text.ToUpper())
                    ? dictionaryCountries[txtCountryCode.Text.ToUpper()] : null;

            if (resultCountry == null)
            {
                txtName.Text = "";
                txtCapital.Text = "";
                lblMessage.Text = "Country Code Not Valid !";
            }
            else
            {
                txtName.Text = resultCountry.Name;
                txtCapital.Text = resultCountry.Capital;
                lblMessage.Text = "";

            }
        }
    }
}