namespace EventModular.Shared.Constants.Response;
public interface IResponse
{
    ResponseStatus Status { get; set; }
    string Message { get; set; }
}
