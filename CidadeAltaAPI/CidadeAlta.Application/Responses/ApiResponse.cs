namespace CidadeAlta.Application.Responses;

public class ApiResponse<T> where T : class
{
    public T? Dto { get; set; } = null!;
    public IEnumerable<string>? Errors { get; set; }

    public bool IsValid => Errors == null || !Errors.Any();
}