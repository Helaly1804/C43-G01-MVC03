using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.Employee;
using Demo.DataAccess.Models.EmployeeModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType.ToString()))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => string.IsNullOrEmpty(src.Department.Name) ? null : src.Department.Name));
            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(e => e.Gender,options => options.MapFrom(src => src.Gender))
                .ForMember(e => e.EmployeeType , options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.HireDate, options => options.MapFrom(src => src.HireDate.ToDateTime(new TimeOnly())));
            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(e => e.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(e => e.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(e => e.HireDate, options => options.MapFrom(src => src.HireDate.ToDateTime(new TimeOnly())));
            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType.ToString()))
                .ForMember(dest => dest.HireDate, options => options.MapFrom(dest => DateOnly.FromDateTime(dest.HireDate)))
                .ForMember(dest => dest.CreatedOn, options => options.MapFrom(src => DateOnly.FromDateTime(src.CreatedOn)))
                .ForMember(dest => dest.LastModifiedOn, options => options.MapFrom(src => DateOnly.FromDateTime(src.LastModifiedOn)))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => string.IsNullOrEmpty(src.Department.Name) ? null : src.Department.Name)); ;
        }
    }
}
