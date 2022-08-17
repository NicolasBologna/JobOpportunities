namespace JobOpportunities.Core.Exceptions
{
    public class FKNotFoundException : Exception
    {
        public FKNotFoundException()
            : base()
        {
        }

        public FKNotFoundException(string message)
            : base(message)
        {
        }

        public FKNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public FKNotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
