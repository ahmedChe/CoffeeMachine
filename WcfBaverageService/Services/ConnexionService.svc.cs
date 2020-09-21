using DomainModel;
using BL;

namespace WcfBaverageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class ConnexionService : IConnexionService
    {
        private UserService userService;
        public ConnexionService()
        {
            userService = new UserService();
        }
        public void RegisterUser(ClientDTO c)
        {
            userService.RegisterUser(c);
        }

        public bool ValidUser(ClientDTO c)
        {
           return userService.ValidSuccessConnexion(c.Username, c.Password);
        }

        public bool ExistingUserData(string field, string user)
        {

            return userService.ExistingUserData(field, user);
        }
    }
}
