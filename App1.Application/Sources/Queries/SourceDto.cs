using App1.Application.Common;
using System.Collections.Generic;

namespace App1.Application.Sources.Queries
{
    public class SourceDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}