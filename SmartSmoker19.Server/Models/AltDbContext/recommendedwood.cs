using System;
using System.Collections.Generic;

namespace SmartSmoker19.Server.Models.AltDbContext;

public partial class recommendedwood
{
    public int id { get; set; }

    public string meattype { get; set; } = null!;

    public string wood0 { get; set; } = null!;

    public string? wood1 { get; set; }

    public string? wood2 { get; set; }

    public string? wood3 { get; set; }

    public string? wood4 { get; set; }
}
