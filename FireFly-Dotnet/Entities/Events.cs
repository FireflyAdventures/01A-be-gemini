using System.Linq;

namespace Calendar_Dotnet.Entities
{
    public class Events
    {

        public int Id { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public string? title { get; set; }

        public string? location { get; set; }

        public string? description { get; set; }
        public DateTime? createDate { get; set;}

        public int? createId { get; set; }
        public DateTime? modifyDate { get; set; }
        
        public int? modifyId { get; set;}
    }
}
