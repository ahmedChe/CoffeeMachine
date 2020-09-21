using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        private static readonly MapperConfiguration config= new MapperConfiguration(cfg => { 

                cfg.AddProfile<ChoiceProfile>();
                cfg.AddProfile<UserProfile>();
            });       
        public static IMapper GetMapper()
        {
            return new Mapper(config);
        }
    }
}

