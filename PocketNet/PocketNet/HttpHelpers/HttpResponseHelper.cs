using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PocketNet.PocketNet.Exceptions;

namespace PocketNet.PocketNet.HttpHelpers
{
    public static class HttpResponseHelper
    {
        public static void RaiseExceptionWhenError(this HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = response.Headers.GetValues("X-Error").FirstOrDefault();
                throw new PocketException((int)response.StatusCode, error);
            }
        }
    }
}
