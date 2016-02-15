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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public const string CON_STR = "Data Source=ACADEMY030-VM;Initial Catalog=Contacts;Integrated Security=SSPI";
        Person thisPerson;
        protected void Page_Load(object sender, EventArgs e)
        {
            string v = Request.QueryString["id"];

            //SQL initialize
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = CON_STR;

            {
                try
                {
                    //Settings for SQL server to work
                    myConnection.Open();
                    SqlCommand myCommand = new SqlCommand();
                    myCommand.Connection = myConnection;

                    myCommand.CommandText = "select * from  Midgard Full outer join Contact on Contact.ID = PersonID  Full outer join Adress on Adress.ID = AdressID where PersonID = '" + v + "' and street is not null";
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    myReader.Read();
                    thisPerson = new Person(myReader["Firstname"].ToString(), myReader["Lastname"].ToString(), myReader["SSN"].ToString(), (int)myReader["PersonID"]);
                    myReader.Close();

                    SqlDataReader myReader1 = myCommand.ExecuteReader();

                    while (myReader1.Read())
                    {
                        Adress tempAdress = new Adress(myReader1["Street"].ToString(), myReader1["Zip"].ToString(), myReader1["City"].ToString(), (int)myReader1["AdressID"]);
                        thisPerson.AdressLista.Add(tempAdress);
                    }
                    foreach (var item in thisPerson.AdressLista)
                    {
                        ListBoxAdressPerson.Items.Add(item.StreetAdress + item.ZipCode + item.City + Environment.NewLine);
                    }

                    myReader1.Close();


                    TableRow tRow = new TableRow();
                    TableCell firstCell = new TableCell();
                    firstCell.Text = thisPerson.Name;
                    TableCell secondCell = new TableCell();
                    secondCell.Text = thisPerson.LastName;
                    TableCell thirdCell = new TableCell();
                    thirdCell.Text = thisPerson.PersonalNumber;
                    TableCell fourthCell = new TableCell();
                    fourthCell.Controls.Add(ListBoxAdressPerson);
                    tRow.Cells.Add(firstCell);
                    tRow.Cells.Add(secondCell);
                    tRow.Cells.Add(thirdCell);
                    tRow.Cells.Add(fourthCell);
                    TableCell fifthCell = new TableCell();
                    TableCell sixthCell = new TableCell();
                    TableCell seventhCell = new TableCell();
                    tRow.Cells.Add(fifthCell);
                    tRow.Cells.Add(sixthCell);
                    tRow.Cells.Add(seventhCell);
                    
                    personTable.Rows.Add(tRow);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    myConnection.Close();
                }

            }
        }

        protected void ListBoxAdressPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                TableCell fifthCell = new TableCell();
                TableCell sixthCell = new TableCell();
                TableCell seventhCell = new TableCell();
                fifthCell.Text = thisPerson.AdressLista[ListBoxAdressPerson.SelectedIndex].StreetAdress;
                sixthCell.Text = thisPerson.AdressLista[ListBoxAdressPerson.SelectedIndex].ZipCode;
                seventhCell.Text = thisPerson.AdressLista[ListBoxAdressPerson.SelectedIndex].City;
                TableRow tRow = personTable.Rows[0];
                tRow.Cells.Add(fifthCell);
                tRow.Cells.Add(sixthCell);
                tRow.Cells.Add(seventhCell);
            }
        }
    }
}