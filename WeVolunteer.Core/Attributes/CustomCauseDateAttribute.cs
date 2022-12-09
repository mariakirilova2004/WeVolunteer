using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeVolunteer.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CustomCauseDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = InTheRange((DateTime) value);
            return result;
        }

        private bool InTheRange(DateTime value)
        {
            if (DateTime.Now.AddDays(1).CompareTo(value) <= 0)
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
            return "Enter a valid date.";
        }

    }
}
