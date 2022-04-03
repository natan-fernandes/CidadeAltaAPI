namespace CidadeAlta.Application.Responses;

public class ApiPageResponse<T> where T : class
{
    public IList<T> Items { get; set; } = null!;
    public long TotalCount { get; set; }
    public long Showing => Items.Count();
}