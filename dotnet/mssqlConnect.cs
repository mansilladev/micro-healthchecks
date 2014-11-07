using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace MicroHealthChecks
{
    // API controller that processes a HTTP GET by checking if it
    // can connect and login to a Microsoft SQL Server database
    public class MSSQLConnectController : ApiController
    {

        public IHttpActionResult Get()
        {
            using (var connection = new SqlConnection("Data Source=<server>;Initial Catalog=<database>;User Id=<username>;Password=<password>"))
            {
                try
                {
                    connection.Open();
                    if (connection.State != ConnectionState.Open)
                    {
                        return new FailResult();
                    }
                    connection.Close();
                }
                catch
                {
                    return new FailResult();
                }
            }

            return new SuccessResult();
        }
    }

    // Reusable class that generates a HTTP response to indiciate success of micro-health check
    public class SuccessResult : IHttpActionResult
    {
        public static JObject SuccessJson = new JObject(new JProperty("status", "Connection successful"));

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new ObjectContent(typeof(JObject), SuccessJson, new JsonMediaTypeFormatter()) });
        }
    }

    // Reusable class that generates a HTTP response to indiciate failure of micro-health check
    public class FailResult : IHttpActionResult
    {
        public static JObject FailJson = new JObject(new JProperty("status", "Unable to connect"));

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable) { Content = new ObjectContent(typeof(JObject), FailJson, new JsonMediaTypeFormatter()) });
        }
    }
}
