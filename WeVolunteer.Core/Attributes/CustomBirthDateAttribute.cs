using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeVolunteer.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CustomBirthDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = InTheRange((DateTime)value);
            return result;
        }
    
        private bool InTheRange(DateTime value)
        {
            if (DateTime.Now.AddYears(-100).CompareTo(value) <= 0 && DateTime.Now.AddYears(-14).CompareTo(value) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public override string FormatErrorMessage(string name)
        {
            return "You must be at least 14 years old.";
        }
    
    }
}
