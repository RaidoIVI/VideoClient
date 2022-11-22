using System;

namespace VideoClient.Models
{
    public class VideoDescription
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string FilePath { get; set; }
    }
}
