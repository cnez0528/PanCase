using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pancase.Models
{
    public class CreateCustomerViewModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Ssn { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [EnumDataType(typeof(EmploymentType))]
        [Required]
        public EmploymentType EmploymentType { get; set; }
        public string EmploymentTypeNotes { get; set; }
        public IEnumerable<SelectListItem> EmploymentTypeList { get; set; }
        public CreateCustomerViewModel()
        {
            EmploymentTypeList = Enum.GetValues(typeof(EmploymentType)).Cast<EmploymentType>().Select(r => new SelectListItem
            {
                Value = r.ToString(),
                Text = r.ToString(),
            });
        }
    }
}
