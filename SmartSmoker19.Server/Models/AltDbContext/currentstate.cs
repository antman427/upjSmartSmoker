using System;
using System.Collections.Generic;

namespace SmartSmoker19.Server.Models.AltDbContext;

public partial class currentstate
{
    public int id { get; set; }

    public decimal? probe1 { get; set; }

    public decimal? probe2 { get; set; }

    public decimal? ambient { get; set; }

    public DateTime? modified { get; set; }
}
