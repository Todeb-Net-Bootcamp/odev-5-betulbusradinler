using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Extension
{
    public static class ValidatorExtension
    {
        // this classtaki metodun pointer adresini taşır

        // Parametrede bir tane ValidationResultın adresine konumlanıyorum


        //  Debug yaptığımızda extension metoda geldiğini görürüz.
        // Bu extension metoda geleceğini nerden bildi ? -> metod içindeki parametre sayesinde
        public static void ThrowErrorIfException(this FluentValidation.Results.ValidationResult validationResult) 
        {
            if (validationResult.IsValid)
                return;
            var message = string.Join(',', validationResult.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(message);
        }
    }
}
