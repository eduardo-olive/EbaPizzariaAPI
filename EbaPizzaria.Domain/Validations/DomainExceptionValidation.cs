using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaPizzaria.Domain.Validations
{
	public class DomainExceptionValidation : Exception
	{
        public DomainExceptionValidation(string erroMessage) : base(erroMessage) { }

		public static void When(bool hasError, string erro)
		{
			if (hasError)
			{
				throw new DomainExceptionValidation(erro);
			}
		}
    }
}
