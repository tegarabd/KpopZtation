using KpopZtationBackEnd.Handler;
using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Services;

namespace KpopZtationBackEnd
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private readonly JsonHandler jsonHandler = new JsonHandler();
        private readonly AuthenticationHandler authenticationHandler = new AuthenticationHandler();
        private readonly CustomerHandler customerHandler = new CustomerHandler();
        private readonly ArtistHandler artistHandler = new ArtistHandler();

        private const string SUCCESS_MESSAGE = "Success";

        public string ProcessRequest<T>(Delegate method, params object[] args)
        {
            T content = default;
            try
            {
                content = (T)method.Method.Invoke(method.Target, args);
            }
            catch (TargetInvocationException ex)
            {
                try
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                }
                catch (Exception e)
                {
                    return jsonHandler.Encode(new WebServiceResponse<T>()
                    {
                        Ok = false,
                        Message = e.Message,
                        Content = default
                    });
                }
            }

            return jsonHandler.Encode(new WebServiceResponse<T>()
            {
                Ok = true,
                Message = SUCCESS_MESSAGE,
                Content = content
            });

        }

        [WebMethod]
        public string Login(string username, string password)
        {
            //Customer customer;
            //try
            //{
            //    customer = authenticationHandler.Login(username, password);
            //}
            //catch (Exception e)
            //{
            //    return jsonHandler.Encode(new WebServiceResponse<Customer>()
            //    {
            //        Ok = false,
            //        Message = e.Message,
            //        Content = default
            //    });
            //}

            //return jsonHandler.Encode(new WebServiceResponse<Customer>()
            //{
            //    Ok = true,
            //    Message = SUCCESS_MESSAGE,
            //    Content = customer
            //});

            return ProcessRequest<Customer>(new Func<string, string, Customer>(authenticationHandler.Login), username, password);
        }

        [WebMethod]
        public string Register(string name, string email, string gender, string address, string password)
        {
            return ProcessRequest<Customer>(new Func<string, string, string, string, string, Customer>(authenticationHandler.Register), name, email, gender, address, password);
        }

        [WebMethod]
        public string GetCustomerById(int id)
        {
            return ProcessRequest<Customer>(new Func<int, Customer>(customerHandler.GetCustomerById), id);
        }

        [WebMethod]
        public string GetArtists()
        {
            return ProcessRequest<List<Artist>>(new Func<List<Artist>>(artistHandler.GetArtists));
        }


    }
}
