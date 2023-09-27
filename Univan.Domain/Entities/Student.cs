namespace Univan.Domain.Entities
{
    public class Student : User
    {
        //Endereco?
        public virtual Subscription Subscription { get; set; }
    }
}
