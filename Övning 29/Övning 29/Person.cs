using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Övning_29
{
    public class Person
    {

        string name;
        string lastName;
        string personalNumber;
        private List<Adress> adressLista;
        int ID;

        public Person(string name, string lastName, string personalNumber, int ID)
        {
            Name = name;
            LastName = lastName;
            PersonalNumber = personalNumber;
            this.ID = ID;
            adressLista = new List<Adress>();
        
        }
        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }

        public string LastName
        {
            get
            { return lastName; }

            set
            { lastName = value; }
        }

        public string PersonalNumber
        {
            get
            { return personalNumber; }

            set
            { personalNumber = value; }
        }

        public List<Adress> AdressLista
        {
            get
            { return adressLista; }

            set
            { adressLista = value; }
        }


        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public void AddAdressToList(string streetAdress, string zipCode, string city, int CID)
        {
            this.adressLista.Add(new Adress(streetAdress, zipCode, city, CID));
        }


        public static void RemovePersonFromList(List<Person> ContactList, Person personToRemove)
        {
            ContactList.Remove(personToRemove);
        }

    }
}