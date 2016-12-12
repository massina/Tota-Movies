using System;
using System.Collections.Generic;

namespace TotaMoviesRental.DQF
{
    // Indexer is a way to access elements in a class that represent a list of values.
    public class HttpCookie
    {
        // Using dictionary as a data storage to store key/value pairs.
        private readonly Dictionary<string, string> _dictionary;
        // Sets or gets the expiry date time for the HttpCookie object.
        public DateTime Expiry { get; set; }

        // The default constructor
        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        // The indexer that will be used to sets or gets the values.
        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }
    }
}