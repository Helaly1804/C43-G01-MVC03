using Demo.BusinessLogic.DataTransferObjects;
using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department));
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn)
            };
        }
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department));
            return new DepartmentDetailsDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
                CreatedBy = department.CreatedBy,
                LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn),
                LastModifiedBy = department.LastModifiedBy,
                IsDeleted = department.IsDeleted
            };
        }
        public static Department ToEntity(this CreatedDepartmentDto createdDepartmentDto)
        {
            if (createdDepartmentDto == null)
                throw new ArgumentNullException(nameof(createdDepartmentDto));
            else
            {
                return new Department
                {
                    Name = createdDepartmentDto.Name,
                    Code = createdDepartmentDto.Code,
                    Description = createdDepartmentDto.Description,
                    CreatedOn = createdDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly()) // This should be replaced with the actual user who created the department
                };
            }
        }
        public static Department ToEntity(this UpdatedDepartmentDto updatedDepartmentDto)
        {
            if (updatedDepartmentDto is null)
                throw new ArgumentNullException(nameof(updatedDepartmentDto));
            else
                return new Department
                {
                    Id = updatedDepartmentDto.Id,
                    Name = updatedDepartmentDto.Name,
                    Code = updatedDepartmentDto.Code,
                    Description = updatedDepartmentDto.Description,
                    CreatedOn = updatedDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly()) // This should be replaced with the actual user who created the department
                };

        }
    }
}
