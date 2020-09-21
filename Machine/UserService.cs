using System;
using DataModel;
using DomainModel;
using DAL.References;
using AutoMapper;
using BL.AutoMapper;

namespace BL
{
   public class UserService
    {
        private ClientReference clr;
        private  IMapper mapper;
        public UserService()
        {
            clr = new ClientReference();
            mapper = AutoMapperConfiguration.GetMapper();
        }
        public void RegisterUser(ClientDTO c)
        {
            Client client = mapper.Map<Client>(c);
            clr.InsertUSer(client);
        }

        public bool ValidSuccessConnexion(string user, string password)
        {
            return clr.CheckValidUser(user, password);
        }

        public bool ExistingUserData(string field, string user)
        {
            return clr.CheckExistingUser(field, user);
        }
    }
}
