using AutoMapper;
using DataModel;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AutoMapper
{
    public class ChoiceProfile: Profile
    {
        public ChoiceProfile()
        {
            CreateMap<Choice, ChoiceDTO>();
            CreateMap<ChoiceDTO, Choice>();
        }
    }
}
