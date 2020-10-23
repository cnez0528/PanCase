using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pancase.Models
{
    public class UpdateCustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public string PhoneNumber { get; set; }
        [EnumDataType(typeof(EmploymentType))]
        public EmploymentType EmploymentType { get; set; }
        public string EmploymentTypeNotes { get; set; }
        public IEnumerable<SelectListItem> EmploymentTypeList { get; set; }
        public UpdateCustomerViewModel()
        {
            EmploymentTypeList = Enum.GetValues(typeof(EmploymentType)).Cast<EmploymentType>().Select(r => new SelectListItem
            {
                Value = r.ToString(),
                Text = r.ToString(),
            });
        }
    }
}
