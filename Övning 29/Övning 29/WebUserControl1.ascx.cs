using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Övning_29
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public const string CON_STR = "Data Source=ACADEMY030-VM;Initial Catalog=Contacts;Integrated Security=SSPI";

        public Person thePerson;

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        public void FillUserControl(Person thePerson)
        {

            txtBoxStreetUserControl.Text = string.Empty;
            txtBoxZipUserControl.Text = string.Empty;
            txtBoxCityUserControl.Text = string.Empty;


            txtBoxFirstnameUserControl.Text = thePerson.Name ;
            txtBoxLastUserControl.Text = thePerson.LastName;
            txtBoxSSNUserControl.Text = thePerson.PersonalNumber;
         

            if ((thePerson.AdressLista.Count) >= 1)
            {
                ListBoxAdresseUserControl.Items.Clear();

                txtBoxStreetUserControl.Text = thePerson.AdressLista[0].StreetAdress;
                txtBoxZipUserControl.Text = thePerson.AdressLista[0].ZipCode;
                txtBoxCityUserControl.Text = thePerson.AdressLista[0].City;
                    
                
                    foreach (var item in thePerson.AdressLista)
                { 
                        ListBoxAdresseUserControl.Items.Add(item.StreetAdress);
                    }
                
            }
        

        }

    }


}