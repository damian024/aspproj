using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplication4.Validators
{
    public class isRegon : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage;
            string regon;
            int[] checkingTable;
            int sum = 0;

            if (validationContext.DisplayName == null)
                errorMessage = "Insert regon!";
            else
                errorMessage = FormatErrorMessage(validationContext.DisplayName);

            if (value == null)
                return new ValidationResult("Insert regon!");

            if (value is string)
                regon = value.ToString();
            else
                return new ValidationResult("Insert regon!");

            int dl = regon.Length;
            Regex regex = new Regex(@"^[0-9]*$");
            if (!regex.IsMatch(regon)) {
                errorMessage = "Invalid characters in regon code!";
                return new ValidationResult(errorMessage);
            }
            if (dl == 14)
                checkingTable = new int[] { 2, 4, 8 ,5, 0 ,9, 7, 3, 6 ,1, 2, 4 ,8 };
            else if(dl == 9)
                checkingTable = new int[] { 8, 9, 2, 3, 4, 5, 6, 7 };
            else
            {
                errorMessage = "Wrong regon code, valid one have 9 or 14 chars in code!";
                return new ValidationResult(errorMessage);
            }
            
            for(int i = 0; i< checkingTable.Length -1; i++)
                sum += (regon[i] - '0') * checkingTable[i];

            if(sum % 11 != regon[regon.Length-1]-'0' && (sum % 11 == 10 && regon[regon.Length-1]-'0' != 0))
            {
                errorMessage = "Wrong regon code, check if you wrote correct one!";
                return new ValidationResult(errorMessage);
            }

           return ValidationResult.Success;
        }

    }
}
