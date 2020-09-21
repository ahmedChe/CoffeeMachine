using System.ServiceModel.Web;
using System.ServiceModel;
using DomainModel;

namespace WcfBaverageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IConnexionService
    {
        [WebInvoke(UriTemplate = "RegisterClient", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void RegisterUser(ClientDTO c);

        [WebInvoke(UriTemplate = "CheckValidConnection", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool ValidUser(ClientDTO c);

        [WebGet(UriTemplate = "CheckExistingData/{field}={user}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool ExistingUserData(string field, string user);

    }
}
