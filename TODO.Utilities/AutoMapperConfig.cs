using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TODO.Domains;
using TODO.Utilities.DTOs;

namespace TODO.Utilities
{
   public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            this.CreateMap<Category, CategoryDto>().ReverseMap();
            this.CreateMap<Task, TaskDto>().ReverseMap();
        }
    }
}
