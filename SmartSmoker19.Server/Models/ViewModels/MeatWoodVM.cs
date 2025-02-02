using SmartSmoker19.Server.Models.AltDbContext;
using System.Linq.Expressions;

namespace SmartSmoker19.Server.Models.ViewModels;

public class MeatWoodVM
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

public static class MeatWoodVmExts
{
    public static readonly Expression<Func<meatwood, MeatWoodVM>> ToVmSql = (e) => new MeatWoodVM
    {
        id = e.id,
        meattype = e.meattype,
        meatcut = e.meatcut,
        smokingtemp = e.smokingtemp,
        approxtime = e.approxtime,
        approxtime2 = e.approxtime2,
        internaltemp = e.internaltemp,
        wood0 = e.wood0,
        wood1 = e.wood1,
        wood2 = e.wood2,
        wood3 = e.wood3,
        wood4 = e.wood4
    };
    public static readonly Func<meatwood, MeatWoodVM> ToVM = ToVmSql.Compile();
    public static MeatWoodVM AsVM(this meatwood e) => ToVM(e);
}
