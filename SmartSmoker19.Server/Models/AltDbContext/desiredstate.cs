using System;
using System.Collections.Generic;

namespace SmartSmoker19.Server.Models.AltDbContext;

public partial class desiredstate
{
    public int id { get; set; }

    public int? smokingtemp { get; set; }

    public int? targettemp { get; set; }

    public DateTime? modified { get; set; }
}
