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
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        public const string CON_STR = "Data Source=ACADEMY030-VM;Initial Catalog=Contacts;Integrated Security=SSPI";
        public static List<Person> contactList = new List<Person>();
        public static int index;

        public List<Person> ContactList
        {
            
            get
            {
                return contactList;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            index = listBoxContacts.SelectedIndex;

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

                    //Sets first and lastname of all contacts from SQL as items in listboxcontacts
                   
                    myCommand.CommandText = "SELECT * FROM Midgard FULL JOIN Contact ON Contact.ID = PersonID FULL JOIN Adress ON Adress.ID = AdressID where Contact.ID is not null order by lastname";
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    //foreach (var persons in myReader)
                    {
                        //Skapa alla personer och alla adresser som finns i listan
                        Person tempPerson = new Person(myReader["Firstname"].ToString(), myReader["Lastname"].ToString(), myReader["SSN"].ToString(), (int)myReader["PersonID"]);
                        if (myReader["AdressID"].ToString().Length > 1)
                        {
                            Adress tempAdress = new Adress(myReader["Street"].ToString(), myReader["Zip"].ToString(), myReader["City"].ToString(), (int)myReader["AdressID"]);
                            if (tempPerson.ID1 == (int)myReader["personID"])
                                tempPerson.AdressLista.Add(tempAdress);

                            if (!IsPostBack)
                            {
                                foreach (var item in contactList)
                                {
                                    if (item.ID1 == (int)myReader["personID"])
                                        item.AdressLista.Add(tempAdress);
                                }
                            }

                        }
                        //Check if person already exist in contactlist. If not add to list.
                        if ((from p in contactList where p.PersonalNumber.Equals(tempPerson.PersonalNumber) select p).Count() == 0)
                        {
                            contactList.Add(tempPerson);
                        }

                    }
                    myReader.Close();

                    if (!IsPostBack)
                    {
                      
                        listBoxContacts.Items.Clear();

                        foreach (var tmpContact in contactList)
                        {
                            ListItem tmpItem = new ListItem($"{tmpContact.Name + " "} {" " + tmpContact.LastName}", tmpContact.ID1.ToString());
                            listBoxContacts.Items.Add(tmpItem);
                        }
                    }
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

        protected void listBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblContactnameModal.Text = contactList[index].Name + " " + contactList[index].LastName;

            WebUserControl1.FillUserControl(contactList[index]);
        }

        protected void btnAddContact_Click(object sender, EventArgs e)
        {
            listBoxContacts.Items.Clear();

            Person tempPerson = new Person(TextBoxFirstnameADD.Text, TextBoxLastnameADD.Text, TextBoxSSNADD.Text, GetLastID());
            contactList.Add(tempPerson);



            foreach (var tmpContact in contactList)
            {
                ListItem tmpItem = new ListItem($"{tmpContact.Name + " "} {" " + tmpContact.LastName}", tmpContact.ID1.ToString());
                listBoxContacts.Items.Add(tmpItem);
            }

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = CON_STR;

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "spAddContact";

                SqlParameter firstNameParam = new SqlParameter("@firstName", SqlDbType.VarChar);
                firstNameParam.Value = TextBoxFirstnameADD.Text;
                myCommand.Parameters.Add(firstNameParam);

                SqlParameter lastnameParam = new SqlParameter("@lastName", SqlDbType.VarChar);
                lastnameParam.Value = TextBoxLastnameADD.Text;
                myCommand.Parameters.Add(lastnameParam);

                SqlParameter ssnparam = new SqlParameter("@ssn", SqlDbType.VarChar);
                ssnparam.Value = TextBoxSSNADD.Text;
                myCommand.Parameters.Add(ssnparam);

                SqlParameter paramID = new SqlParameter("@new_id", SqlDbType.Int);
                paramID.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(paramID);

                int numberOfRows = myCommand.ExecuteNonQuery();

                AddContactAdressToNewPerson(GetLastID());

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

        protected void AddContactAdressToNewPerson(int contactID)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = CON_STR;

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "spAddAdress";

                SqlParameter streetParam = new SqlParameter("@streetAdress", SqlDbType.VarChar);
                streetParam.Value = TextBoxStreetADD.Text;
                myCommand.Parameters.Add(streetParam);

                SqlParameter zipParam = new SqlParameter("@zipAdress", SqlDbType.VarChar);
                zipParam.Value = TextBoxZipADD.Text;
                myCommand.Parameters.Add(zipParam);

                SqlParameter cityParam = new SqlParameter("@cityAdress", SqlDbType.VarChar);
                cityParam.Value = TextBoxCityADD.Text;
                myCommand.Parameters.Add(cityParam);

                SqlParameter CIDParam = new SqlParameter("@CID", SqlDbType.Int);
                CIDParam.Value = contactID;
                myCommand.Parameters.Add(CIDParam);

                SqlParameter AIDParam = new SqlParameter("@AID", SqlDbType.Int);
                AIDParam.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(AIDParam);

                myCommand.ExecuteNonQuery();

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


        protected void CreateNewFullPerson()
        {

            listBoxContacts.Items.Clear();


            Person tempPerson = new Person(TextBoxFirstnameADD.Text, TextBoxLastnameADD.Text, TextBoxSSNADD.Text, GetLastID());
            contactList.Add(tempPerson);

            ListItem tmpItem = new ListItem($"{tempPerson.Name + " "} {" " + tempPerson.LastName}", tempPerson.ID1.ToString());
            listBoxContacts.Items.Add(tmpItem);

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = CON_STR;

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "spAddContact";

                SqlParameter firstNameParam = new SqlParameter("@firstName", SqlDbType.VarChar);
                firstNameParam.Value = TextBoxFirstnameADD.Text;
                myCommand.Parameters.Add(firstNameParam);

                SqlParameter lastnameParam = new SqlParameter("@lastName", SqlDbType.VarChar);
                lastnameParam.Value = TextBoxLastnameADD.Text;
                myCommand.Parameters.Add(lastnameParam);

                SqlParameter ssnparam = new SqlParameter("@ssn", SqlDbType.VarChar);
                ssnparam.Value = TextBoxSSNADD.Text;
                myCommand.Parameters.Add(ssnparam);

                SqlParameter paramID = new SqlParameter("@new_id", SqlDbType.Int);
                paramID.Direction = ParameterDirection.Output;
                myCommand.Parameters.Add(paramID);

                int numberOfRows = myCommand.ExecuteNonQuery();
                
                if((TextBoxCityADD.Text.Length>0)&(TextBoxZipADD.Text.Length>0&TextBoxStreetADD.Text.Length>1))
                AddContactAdressToNewPerson(GetLastID());

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

        public static int GetLastID()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = CON_STR;

            //Settings for SQL server to work
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            myCommand.CommandText = "SELECT TOP 1 ID FROM Contact ORDER BY ID DESC";
            SqlDataReader myReader = myCommand.ExecuteReader();

            myReader.Read();
            int id = Convert.ToInt32(myReader["ID"]);
            myReader.Close();

            return id;
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = CON_STR;

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "spDeleteContact";

                SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
                idParam.Value = listBoxContacts.SelectedValue;
                myCommand.Parameters.Add(idParam);

                myCommand.ExecuteNonQuery();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = CON_STR;

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.CommandText = "update contact set Firstname='" + TextBoxFirstnameADD.Text + "', Lastname='" + TextBoxLastnameADD.Text + "', SSN='" + TextBoxSSNADD.Text + "' where ID='" + listBoxContacts.SelectedValue + "'";
                myCommand.ExecuteNonQuery();



                myCommand.ExecuteNonQuery();
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

//    listBoxContacts.Items.Clear();


//            Person tempPerson = new Person(TextBoxFirstnameADD.Text, TextBoxLastnameADD.Text, TextBoxSSNADD.Text, GetLastID());
//    contactList.Add(tempPerson);
//            foreach (var item in contactList)
//            {
//                listBoxContacts.Items.Add(item.Name + " " + " " + item.LastName);
//            }

//SqlConnection myConnection = new SqlConnection();
//myConnection.ConnectionString = CON_STR;

//            try
//            {
//                myConnection.Open();
//                SqlCommand myCommand = new SqlCommand();
//myCommand.Connection = myConnection;

//                myCommand.CommandType = CommandType.StoredProcedure;
//                myCommand.CommandText = "spAddContact";

//                SqlParameter firstNameParam = new SqlParameter("@firstName", SqlDbType.VarChar);
//firstNameParam.Value = TextBoxFirstnameADD.Text;
//                myCommand.Parameters.Add(firstNameParam);

//                SqlParameter lastnameParam = new SqlParameter("@lastName", SqlDbType.VarChar);
//lastnameParam.Value = TextBoxLastnameADD.Text;
//                myCommand.Parameters.Add(lastnameParam);

//                SqlParameter ssnparam = new SqlParameter("@ssn", SqlDbType.VarChar);
//ssnparam.Value = TextBoxSSNADD.Text;
//                myCommand.Parameters.Add(ssnparam);

//                SqlParameter paramID = new SqlParameter("@new_id", SqlDbType.Int);
//paramID.Direction = ParameterDirection.Output;
//                myCommand.Parameters.Add(paramID);

//                int numberOfRows = myCommand.ExecuteNonQuery();

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                myConnection.Close();
//            }

}