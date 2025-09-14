using Movies.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Responses.Movies
{
    public class MoviePostResponse
    {
        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public byte[]? CoverImage { get; set; }

        public string? Category { get; set; }
    }
}
