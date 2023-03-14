using KpopZtationBackEnd.Handler;
using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            T content;
            try
            {
                content = (T) method.DynamicInvoke(args);
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
            Customer customer;
            try
            {
                customer = authenticationHandler.Login(username, password);
            }
            catch (Exception e)
            {
                return jsonHandler.Encode(new WebServiceResponse<Customer>()
                {
                    Ok = false,
                    Message = e.Message,
                    Content = null
                });
            }
            
            return jsonHandler.Encode(new WebServiceResponse<Customer>()
            {
                Ok = true,
                Message = SUCCESS_MESSAGE,
                Content = customer
            });
        }

        [WebMethod]
        public string Register(string name, string email, string gender, string address, string password)
        {
            Customer customer;
            try
            {
                customer = authenticationHandler.Register(name, email, gender, address, password);
            }
            catch (Exception e)
            {
                return jsonHandler.Encode(new WebServiceResponse<Customer>()
                {
                    Ok = false,
                    Message = e.Message,
                    Content = null
                });
            }

            return jsonHandler.Encode(new WebServiceResponse<Customer>()
            {
                Ok = true,
                Message = SUCCESS_MESSAGE,
                Content = customer
            });
        }

        [WebMethod]
        public string GetCustomerById(int id)
        {
            Customer customer;
            try
            {
                customer = customerHandler.GetCustomerById(id);
            }
            catch (Exception e)
            {
                return jsonHandler.Encode(new WebServiceResponse<Customer>()
                {
                    Ok = false,
                    Message = e.Message,
                    Content = null
                });
            }

            return jsonHandler.Encode(new WebServiceResponse<Customer>()
            {
                Ok = true,
                Message = SUCCESS_MESSAGE,
                Content = customer
            });
        }

        [WebMethod]
        public string GetArtists()
        {
            return ProcessRequest<List<Artist>>(new Func<List<Artist>>(artistHandler.GetArtists));
        }

        
    }
}
