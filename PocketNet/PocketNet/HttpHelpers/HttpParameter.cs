using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.HttpHelpers
{
    public class HttpParameter
    {
        public HttpParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public object Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0}={1}", Name, Value);
        }
    }
}
