//namespace TaskAppCoreCourseBasma.Models
//{
//    public class TaskEntityApp
//    {
//    }
//}

using System;

namespace AspNetCoreWebApp.Models
{
    public class TaskEntityApp
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public DateTime Dateadded { get; set; }
    }
}
