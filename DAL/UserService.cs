using System;
using DataModel;
using DomainModel;
using DAL.References;
using AutoMapper;

namespace BL
{
   public class UserService
    {
        private ClientReference clr;
        private  IMapper _mapper;
        public UserService()
        {
            clr = new ClientReference();
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<ClientDTO,Client>();
            });

            _mapper = config.CreateMapper();
        }
        public void RegisterUser(ClientDTO c)
        {
            Client client = _mapper.Map<Client>(c);
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
