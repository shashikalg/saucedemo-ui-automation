using saucedemo_ui_automation.Models;

namespace saucedemo_ui_automation.Helpers
{
    public static class ProductHelper
    {
        public static bool AreProductsEqual(List<Product> expectedProducts, List<Product> actualProducts)
        {
            if (expectedProducts.Count != actualProducts.Count)
                return false;

            expectedProducts = expectedProducts.OrderBy(p => p.Name).ToList();
            actualProducts = actualProducts.OrderBy(p => p.Name).ToList();

            for (int i = 0; i < expectedProducts.Count; i++)
            {
                if (expectedProducts[i].Name != actualProducts[i].Name ||
                    //expectedProducts[i].Description != actualProducts[i].Description ||
                    expectedProducts[i].Price != actualProducts[i].Price)
                {
                    return false;
                }
            }

            return true;
        }
    }
}