using System.ComponentModel.DataAnnotations;

namespace GoodReads.Services.Dtos
{
    public class PagedResultRequestDto
    {
        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }

        [Range(1, int.MaxValue)]
        public virtual int MaxResultCount { get; set; } = 10;

    }
}
