using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FreightWaysAPITest
{
    [TestFixture]
    public class Test
    {
        Service service;

        [OneTimeSetUp]
        public void Setup()
        {
            service = new Service();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            if (service != null)
            {
                service.Dispose();
                service = null;
            }
        }

        [Test]
        public void TEST_001_GET_JSON_HOLDER()
        {
            var response = service.CallIDontExistEndpoint();

            response.Expect(HttpStatusCode.NotFound);       
        }

    }
}
