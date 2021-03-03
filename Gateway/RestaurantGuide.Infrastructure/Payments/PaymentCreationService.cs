using Newtonsoft.Json;
using RestaurantGuide.Application.Payments;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.Infrastructure.Payments
{
  public  class PaymentCreationService : IPaymentCreationService
    {
        private readonly System.Net.Http.HttpClient httpClient;

        public PaymentCreationService(HttpClient httpClient)
        {
            this.httpClient = httpClient.GetInstance();
        }

        public async Task CreatePaymentAsync(int orderId, string paymentType)
        {
          
           var paymentRequest = new { OrderId = orderId, PaymentType = paymentType };

            var serializedPaymentRequest = JsonConvert.SerializeObject(paymentRequest);

            StringContent stringContent = new StringContent(serializedPaymentRequest, Encoding.UTF8,"application/json");

            var response = await httpClient.PostAsync("Payment/Create", stringContent);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(response.ReasonPhrase);       
        }
    }
}
