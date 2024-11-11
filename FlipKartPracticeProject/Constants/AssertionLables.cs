using System.Collections.Generic;

namespace FlipkartExpectedLables
{
    public static class ExpectedLablesConstant
    {
        public static Dictionary<string, string> getExpectedLables()
        {
            Dictionary<string, string> Expectedresult = new Dictionary<string, string>
            {
                { "LandingPage_label1", "Grocery" },
                { "LandingPage_label2", "Mobiles" },
                { "LoginPage_label1", "Login" },
                { "LoginPage_label2", "Get access to your Orders, Wishlist and Recommendations" },
            };

            return Expectedresult;
        }
    }
}

