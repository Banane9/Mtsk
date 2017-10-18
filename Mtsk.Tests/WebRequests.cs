using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mtsk.Tests
{
    [TestClass]
    public class WebRequests
    {
        private static readonly MtskApiClient client = new MtskApiClient("00000000-0000-0000-0000-000000000002");

        [TestMethod]
        public void DetailsApiRequest()
        {
            var response = client.GetStationDetailsAsync("24a381e3-0d72-416d-bfd8-b2f65f6e5802").Result;
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void PriceApiRequest()
        {
            var response = client.GetPricesAsync("4429a7d9-fb2d-4c29-8cfe-2ca90323f9f8", "446bdcf5-9f75-47fc-9cfa-2c3d6fda1c3b", "60c0eefa-d2a8-4f5c-82cc-b5244ecae955", "44444444-4444-4444-4444-444444444444").Result;
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void SurroundingAreaApiRequest()
        {
            var response = client.GetSurroundingAreaAsync(52.521m, 13.438m, 1.5m).Result;
            Assert.IsTrue(response.Success);
        }
    }
}