using System;
using System.Collections.Generic;

namespace FireFly_Dotnet.Entities;

public partial class StoryMarc
{
    public int Id { get; set; }

    public string? StoryName { get; set; }

    public string? Title { get; set; }

    public string? SeriesTitle { get; set; }

    public string? Authors { get; set; }

    public string? Illustrator { get; set; }

    public DateTime? PublicationDate { get; set; }

    public string? Publisher { get; set; }

    public string? Isbn { get; set; }

    public string? SummaryDescription { get; set; }

    public string? Genre { get; set; }

    public string? Audience { get; set; }

    public string? Language { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int? ModifiedById { get; set; }
}
