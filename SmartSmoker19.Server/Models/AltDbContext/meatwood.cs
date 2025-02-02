using System;
using System.Collections.Generic;

namespace SmartSmoker19.Server.Models.AltDbContext;

public partial class meatwood
{
    public int? id { get; set; }

    public string? meattype { get; set; }

    public string? meatcut { get; set; }

    public int? smokingtemp { get; set; }

    public string? approxtime { get; set; }

    public string? approxtime2 { get; set; }

    public int? internaltemp { get; set; }

    public string? wood0 { get; set; }

    public string? wood1 { get; set; }

    public string? wood2 { get; set; }

    public string? wood3 { get; set; }

    public string? wood4 { get; set; }
}
