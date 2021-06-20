    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    namespace FreightWaysAPITest
    {
       
    public class ListResponse<T> where T : IEntity
    {
        public ListResponse(HttpStatusCode statusCode, string error)
        {
            StatusCode = statusCode;
            Error = error;
        }

        public ListResponse(HttpStatusCode statusCode, List<T> entity)
        {
            StatusCode = statusCode;
            Entity = entity;
        }

        public string Error { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public List<T> Entity { get; set; }

        // MARK - TestCase convenience

        public void Expect(HttpStatusCode statusCode)
        {
            Assert.AreEqual(StatusCode, statusCode);
        }
    }


}
