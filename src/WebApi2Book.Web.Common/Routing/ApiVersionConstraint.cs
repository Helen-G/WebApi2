using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace WebApi2Book.Web.Common.Routing
{
    //This class implements the IHttpRouteConstraint.Match method. Match will return true if the specified
    //parameter name equals the AllowedVersion property, which is initialized in the constructor.But where does the
    //constructor get this value? It gets it from a RoutePrefixAttribute.

    public class ApiVersionConstraint: IHttpRouteConstraint
    {
        public ApiVersionConstraint(string allowedVersion)
        {
            AllowedVersion = allowedVersion.ToLowerInvariant();
        }

        public string AllowedVersion { get; private set; }

        public bool Match(
                            HttpRequestMessage request, 
                            IHttpRoute route, 
                            string parameterName, 
                            IDictionary<string, object> values,
                            HttpRouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return AllowedVersion.Equals(value.ToString().ToLowerInvariant());
            }
            return false;
        }
    }
}
