using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace DWP.Tests.Helper
{
    public static class Utility
    {
        public static object GetJsonObject()
        {
            try
            {
               // TO DO

              return new object();
            }
            catch (System.Exception)
            {

                throw new System.Exception("An error occurred during the deserialization!");
            }
        }
    }
}
