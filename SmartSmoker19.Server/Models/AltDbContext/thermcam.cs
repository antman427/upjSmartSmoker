using System;
using System.Collections.Generic;

namespace SmartSmoker19.Server.Models.AltDbContext;

public partial class thermcam
{
    public int id { get; set; }

    public int? run { get; set; }

    public List<decimal>? data { get; set; }

    public DateTime? modified { get; set; }
}
