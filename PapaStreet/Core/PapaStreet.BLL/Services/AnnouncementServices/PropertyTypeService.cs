﻿using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Validators;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Services
{
    public class PropertyTypeService : IBaseService<PropertyTypeDto>
    {
        private readonly IPropertyTypeRepository _propertyTypeRepository;

        public PropertyTypeService(IPropertyTypeRepository propertyTypeRepository)
        {
            _propertyTypeRepository = propertyTypeRepository;
        }
        public ActionResponse<IQueryable<PropertyTypeDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _propertyTypeRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<PropertyTypeDto> GetById(Guid id)
        {
            var response = _propertyTypeRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _propertyTypeRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(PropertyTypeDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new PropertyTypeValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _propertyTypeRepository.Save(obj);
                    return response;
                }
                else
                {
                    var valErrors = valResult.Errors.Select(e => e.ErrorMessage).ToArray();
                    return ActionResponse.Failure(valErrors);
                }

            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}
