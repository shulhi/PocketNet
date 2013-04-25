using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.HttpHelpers
{
    public class HttpParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public HttpParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return String.Format("{0}={1}", Name, Value);
        }
    }
}
