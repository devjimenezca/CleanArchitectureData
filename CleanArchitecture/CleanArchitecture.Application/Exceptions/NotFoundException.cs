namespace CleanArchitecture.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"Entidad \"{name}\" ({key})  no fue encontrado")
        {
        }
    }
}
