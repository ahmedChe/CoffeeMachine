using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using DomainModel;

namespace WcfBaverageService
{
    [ServiceContract]
    public interface IBaverageService
    {
        [WebGet(UriTemplate = "GetDrinks", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<string> GetDrinkChoices();

        [WebInvoke(UriTemplate = "PrepareDrink/{username}", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void PrepareDrink(ChoiceDTO choice,string username);

        [WebGet(UriTemplate = "GetLastSelectedDrink/{username}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ChoiceDTO GetLastChoice(string username);



    }

}
