using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Övning_29
{
    public class Adress
    {

        string streetAdress;
        string zipCode;
        string city;

        public string StreetAdress
        {
            get
            { return streetAdress; }

            set
            { streetAdress = value; }
        }

        public string ZipCode
        {
            get
            { return zipCode; }

            set
            { zipCode = value; }
        }

        public string City
        {
            get
            { return city; }

            set
            { city = value; }
        }

        public Adress(string street, string zipCode, string city, int CID)
        {
            this.streetAdress = street;
            this.zipCode = zipCode;
            this.city = city;
        }

    }
}