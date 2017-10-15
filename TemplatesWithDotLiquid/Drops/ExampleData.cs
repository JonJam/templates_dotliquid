using System;
using DotLiquid;

namespace TemplatesWithDotLiquid.Drops
{
    public class ExampleData : Drop
    {
        public string Reference
        {
            get;
            set;
        }

        public DateTimeOffset CreationDate
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string AddressStreet
        {
            get;
            set;
        }

        public string AddressCity
        {
            get;
            set;
        }

        public string AddressCounty
        {
            get;
            set;
        }

        public string AddressPostcode
        {
            get;
            set;
        }

        public string AddressCountry
        {
            get;
            set;
        }

        public bool IsTrue
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }
    }
}
