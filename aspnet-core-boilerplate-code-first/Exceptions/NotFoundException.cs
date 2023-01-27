
namespace aspnet_core_boilerplate_code_first.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}