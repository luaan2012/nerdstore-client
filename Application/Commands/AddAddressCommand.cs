using FluentValidation;
using NS.Core.Messages;

namespace NS.Clientes.API.Application.Commands
{
    public class AddAddressCommand : Command
    {
        public Guid ClientId { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }

		public AddAddressCommand()
        {
        }

        public AddAddressCommand(Guid clientId, string publicPlace, string number, string complement,
            string neighborhood, string cep, string city, string state)
        {
            AggregateId = clientId;
            ClientId = clientId;
            PublicPlace = publicPlace;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            Cep = cep;
            City = city;
            State = state;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddressValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AddressValidation : AbstractValidator<AddAddressCommand>
        {
            public AddressValidation()
            {
                RuleFor(c => c.PublicPlace)
                    .NotEmpty()
                    .WithMessage("Informe o Logradouro");

                RuleFor(c => c.Number)
                    .NotEmpty()
                    .WithMessage("Informe o Número");

                RuleFor(c => c.Cep)
                    .NotEmpty()
                    .WithMessage("Informe o CEP");

                RuleFor(c => c.Neighborhood)
                    .NotEmpty()
                    .WithMessage("Informe o Bairro");

                RuleFor(c => c.City)
                    .NotEmpty()
                    .WithMessage("Informe o Cidade");

                RuleFor(c => c.State)
                    .NotEmpty()
                    .WithMessage("Informe o Estado");
            }
        }
    }
}