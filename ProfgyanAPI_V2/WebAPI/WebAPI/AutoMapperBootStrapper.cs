using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using DataModelDTO;
using DataModel;

namespace WebAPI.Controllers
{
    public static class AutoMapperBootStrapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(
                (config) => {
                    config.CreateMap<DataModelDTO.Appointment, DataModel.Appointment>().ReverseMap();
                    config.CreateMap<DataModelDTO.ContactUs, DataModel.ContactUs>().ReverseMap();
                    }
                );
        }

    }
}
