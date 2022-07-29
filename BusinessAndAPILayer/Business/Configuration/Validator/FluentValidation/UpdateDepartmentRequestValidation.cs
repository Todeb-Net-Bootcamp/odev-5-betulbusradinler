using DTO.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation
{
    public class UpdateDepartmentRequestValidation : AbstractValidator<UpdateDepartmentRequest>
    {
        public UpdateDepartmentRequestValidation()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
