using System;
using System.Collections.Generic;

namespace SmartSmoker19.Server.Models.AltDbContext;

public partial class meatsmokingguide
{
    public int id { get; set; }

    public string meattype { get; set; } = null!;

    public string? meatcut { get; set; }

    public int? smokingtemp { get; set; }

    public string? approxtime { get; set; }

    public string? approxtime2 { get; set; }

    public int? internaltemp { get; set; }
}
