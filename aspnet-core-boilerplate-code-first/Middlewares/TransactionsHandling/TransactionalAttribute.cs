namespace aspnet_core_boilerplate_code_first.Middlewares.TransactionsHandling;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class TransactionalAttribute : Attribute
{
}