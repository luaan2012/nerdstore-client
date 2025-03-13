using NS.Core.DomainObjects;

namespace NS.Cliente.API.Models
{
    public class Address : Entity
    {
        public string PublicPlace { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string Cep { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid ClientId { get; private set; }
        public string CompletAddress
        {
            get
            {
                return $"{PublicPlace}, {Number}, {Complement} - {Neighborhood} - {City} - {State}";
            }
        }
        // EF Relation
        public Client Client { get; protected set; }

        public Address(string publicPlace, string number, string complement, string neighboorhood, string cep, string city, string state, Guid clientId)
        {
            PublicPlace = publicPlace;
            Number = number;
            Complement = complement;
            Neighborhood = neighboorhood;
            Cep = cep;
            City = city;
            State = state;
            ClientId = clientId;
        }

        // EF Constructor
        protected Address() { }
    }
}
