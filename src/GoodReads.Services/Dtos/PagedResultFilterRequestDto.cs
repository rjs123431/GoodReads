namespace GoodReads.Services.Dtos
{
    public class PagedResultFilterRequestDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
