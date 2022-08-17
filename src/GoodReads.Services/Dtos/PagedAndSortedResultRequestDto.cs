namespace GoodReads.Services.Dtos
{
    public class PagedAndSortedResultRequestDto : PagedResultRequestDto
    {
        public virtual string Sorting { get; set; }
    }
}
