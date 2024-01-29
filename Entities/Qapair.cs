using System;
using System.Collections.Generic;

namespace FireFly_Dotnet.Entities;

public partial class Qapair
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public int CategoryId { get; set; }

    public int SortOrder { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public int CreatedBy { get; set; }

    public int ModifiedBy { get; set; }
}
