using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;
using Stripe.Checkout;

namespace CreditCare.Service
{
    public class StripeService
    {
        private readonly string _apiKey = "sk_test_51QZfK4BqTobyS16Xk7JuclLLvbcnV9ibZvMmNSFqF7ltOs9PJZSbwmE5J4PCgK6yNOBKgvLSiwx6HHgb5GoCKnJW004ynHtkWD";

        public StripeService()
        {
            StripeConfiguration.ApiKey = _apiKey;
        }

        public string CreateCheckoutSession(string email, string successUrl, string cancelUrl)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                CustomerEmail = email,
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = "price_1QZflKBqTobyS16XofDuHyJg", // Replace with the plan ID from Stripe
                    Quantity = 1
                }
            },
                Mode = "subscription",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session.Url;
        }
    }
}

