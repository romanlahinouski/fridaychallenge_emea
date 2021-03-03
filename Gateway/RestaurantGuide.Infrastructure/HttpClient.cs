using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RestaurantGuide.Infrastructure
{
    public class HttpClient
    {

        public static System.Net.Http.HttpClient Instance { get; private set; }


        public HttpClient(Action<System.Net.Http.HttpClient> configBuilder)
        {
           if(Instance == null)
            {
                Instance = new System.Net.Http.HttpClient(); 
                configBuilder(Instance);
            }                 
        }

        public System.Net.Http.HttpClient GetInstance()
        {        
            return Instance;
        }

    }
}
