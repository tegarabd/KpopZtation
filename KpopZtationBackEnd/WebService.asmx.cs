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
        private readonly AlbumHandler albumHandler = new AlbumHandler();
        private readonly CartHandler cartHandler = new CartHandler();
        private readonly TransactionHandler transactionHandler = new TransactionHandler();

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

        [WebMethod]
        public string GetArtistById(int id)
        {
            return ProcessRequest<Artist>(new Func<int, Artist>(artistHandler.GetArtistById), id);
        }

        [WebMethod]
        public string InsertArtist(string name, string image)
        {
            return ProcessRequest<Artist>(new Func<string, string, Artist>(artistHandler.InsertArtist), name, image);
        }

        [WebMethod]
        public string UpdateArtist(int id, string name, string image)
        {
            return ProcessRequest<Artist>(new Func<int, string, string, Artist>(artistHandler.UpdateArtist), id, name, image);
        }

        [WebMethod]
        public string DeleteArtist(int id)
        {
            return ProcessRequest<Artist>(new Func<int, Artist>(artistHandler.DeleteArtist), id);
        }

        [WebMethod]
        public string InsertAlbum(int artistId, string name, string image, string description, int price, int stock)
        {
            return ProcessRequest<Album>(new Func<int, string, string, string, int, int, Album>(albumHandler.InsertAlbum), artistId, name, image, description, price, stock);
        }

        [WebMethod]
        public string GetAlbumById(int id)
        {
            return ProcessRequest<Album>(new Func<int, Album>(albumHandler.GetAlbumById), id);
        }

        [WebMethod]
        public string UpdateAlbum(int id, string name, string image, string description, int price, int stock)
        {
            return ProcessRequest<Album>(new Func<int, string, string, string, int, int, Album>(albumHandler.UpdateAlbum), id, name, image, description, price, stock);
        }

        [WebMethod]
        public string DeleteAlbum(int id)
        {
            return ProcessRequest<Album>(new Func<int, Album>(albumHandler.DeleteAlbum), id);
        }

        [WebMethod]
        public string GetCartsByCustomerId(int customerId)
        {
            return ProcessRequest<List<Cart>>(new Func<int, List<Cart>>(cartHandler.GetCartsByCustomerId), customerId);
        }

        [WebMethod]
        public string InsertAlbumToCustomerCart(int customerdId, int albumId, int quantity)
        {
            return ProcessRequest<Cart>(new Func<int, int, int, Cart>(cartHandler.InsertAlbumToCustomerCart), customerdId, albumId, quantity);
        }

        [WebMethod]
        public string DeleteCart(int customerId, int albumId)
        {
            return ProcessRequest<Cart>(new Func<int, int, Cart>(cartHandler.DeleteCart), customerId, albumId);
        }

        [WebMethod]
        public string InsertTransaction(int customerId)
        {
            return ProcessRequest<TransactionHeader>(new Func<int, TransactionHeader>(transactionHandler.InsertTransaction), customerId);
        }

        [WebMethod]
        public string GetTransactions()
        {
            return ProcessRequest<List<TransactionHeader>>(new Func<List<TransactionHeader>>(transactionHandler.GetTransactions));
        }

        [WebMethod]
        public string GetTransactionsByCustomerId(int customerId)
        {
            return ProcessRequest<List<TransactionHeader>>(new Func<int, List<TransactionHeader>>(transactionHandler.GetTransactionsByCustomerId), customerId);
        }

        [WebMethod]
        public string UpdateCustomer(int id, string name, string email, string gender, string address, string password)
        {
            return ProcessRequest<Customer>(new Func<int, string, string, string, string, string, Customer>(customerHandler.UpdateCustomer), id, name, email, gender, address, password);
        }

        [WebMethod]
        public string GetCustomers()
        {
            return ProcessRequest<List<Customer>>(new Func<List<Customer>>(customerHandler.GetCustomers));
        }

        [WebMethod]
        public string DeleteCustomer(int id)
        {
            return ProcessRequest<Customer>(new Func<int, Customer>(customerHandler.DeleteCustomer), id);
        }
    }
}
