using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace FluentHtml
{
    public class HyperLinkProvider:IProvideHyperLink
    {
        private HttpRequestMessage request;
        private IUrlDispatcher dispatcher;
        public HyperLinkProvider(HttpRequestMessage request)
        {
            this.request = request;
            this.dispatcher = new UrlDispatcher();
        }

        /// <summary>
        /// Gets the request that this instance uses to create URIs.
        /// </summary>
        /// <seealso cref="RouteLinker(HttpRequestMessage)" />
        /// <seealso cref="RouteLinker(HttpRequestMessage, IRouteDispatcher)" />
        public HttpRequestMessage Request
        {
            get { return this.request; }
        }

        public Uri GetUri<TController>(Expression<Action<TController>> methodName)
        {
            var expression = methodName.Body as MethodCallExpression;
            if (expression == null)
                throw new ArgumentException("The expression should be a Method .The Code blocked supplied Should invoke a method for example x=>x.MethodName()", "methodName");
            var Routes = dispatcher.Dispatch(methodName);
            return GetRelativeUri(Routes) ;
        }

        private Uri GetRelativeUri(Tuple<string,IDictionary<string,object>> routes)
        {
            var urlHelper = this.CreateUrlHelper();
            var relativeUri = urlHelper.Route(routes.Item1, routes.Item2);
            return new Uri(relativeUri, UriKind.Relative);
        }

        private UrlHelper CreateUrlHelper()
        {
            return this.CopyRequestWithoutRouteValues().GetUrlHelper();
        }

        private HttpRequestMessage CopyRequestWithoutRouteValues()
        {
            var r = new HttpRequestMessage(
                this.request.Method,
                this.request.RequestUri);

            try
            {

                foreach (var kvp in this.request.Properties)
                    if (kvp.Key != HttpPropertyKeys.HttpRouteDataKey)
                        r.Properties.Add(kvp.Key, kvp.Value);

                var routeData = this.request.GetRouteData();
                r.Properties.Add(
                    HttpPropertyKeys.HttpRouteDataKey,
                    new HttpRouteData(routeData.Route));

                return r;
            }
            catch
            {
                r.Dispose();
                throw;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                this.request.Dispose();
        }


    }
}
