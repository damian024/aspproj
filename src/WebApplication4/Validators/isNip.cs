using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication4.Validators
{
    public class isNip : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage;
            
            int[] checkingTable;
            int sum = 0;
            
            if (value != null && value is string && value.ToString().Length > 0)
            {
                string nip = value.ToString();
                var regex = new Regex(@"^\d{3}-\d{3}-\d{2}-\d{2}$");
                var match = regex.Match(nip);
                if (match.Success)
                {
                    nip = nip.Replace("-", "");
                    if (nip.Length == 10)
                        checkingTable = new int[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
                    else
                    {
                        errorMessage = "Wrong NIP code, valid one have 10 chars in code!";
                        return new ValidationResult(errorMessage);
                    }

                    for (int i = 0; i < checkingTable.Length - 1; i++)
                        sum += (nip[i] - '0') * checkingTable[i];
                    nip = sum.ToString();
                    if (sum % 11 == nip[nip.Length - 1]-'0' || (sum % 11 == 10 && nip[nip.Length - 1]-'0' == 0))
                        return ValidationResult.Success;

                }
                errorMessage = nip + "Wrong nip code, check if you wrote correct one!";
                return new ValidationResult(errorMessage);
            }
            else
                return ValidationResult.Success;


        }
    }
}
