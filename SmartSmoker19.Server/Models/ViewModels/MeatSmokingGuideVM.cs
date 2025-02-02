using SmartSmoker19.Server.Models.AltDbContext;
using System.Linq.Expressions;

namespace SmartSmoker19.Server.Models.ViewModels;

public class MeatSmokingGuideVM
{
    public int id { get; set; }
    public string meattype { get; set; } = null!;
    public string? meatcut { get; set; }
    public int? smokingtemp { get; set; }
    public string? approxtime { get; set; }
    public string? approxtime2 { get; set; }
    public int? internaltemp { get; set; }
}

public static class meatsmokingguideVmExts
{
    // POCO to VM
    public static readonly Expression<Func<meatsmokingguide, MeatSmokingGuideVM>> ToVmSql = (e) => new MeatSmokingGuideVM
    {
        id = e.id,
        meattype = e.meattype,
        meatcut = e.meatcut,
        smokingtemp = e.smokingtemp,
        approxtime = e.approxtime,
        approxtime2 = e.approxtime2,
        internaltemp = e.internaltemp
    };
    public static readonly Func<meatsmokingguide, MeatSmokingGuideVM> ToVM = ToVmSql.Compile();
    public static MeatSmokingGuideVM AsVM(this meatsmokingguide e) => ToVM(e);
    
    // VM to POCO
    public static readonly Func<MeatSmokingGuideVM, meatsmokingguide> ToPoco = (e) =>
    {
        return new meatsmokingguide
        {
            id = e.id,
            meattype = e.meattype,
            meatcut = e.meatcut,
            smokingtemp = e.smokingtemp,
            approxtime = e.approxtime,
            approxtime2 = e.approxtime2,
            internaltemp = e.internaltemp
        };
    };
    public static meatsmokingguide AsPoco(this MeatSmokingGuideVM e) => ToPoco(e);

    // Update POCO from VM
    public static bool GraphVM(this MeatSmokingGuideVM vm, ref meatsmokingguide e)
    {
        // Updates (ID == ID, Modified == Modified, Deleted == false
        if (e.id == vm.id /*&& e.Modified == vm.Modified &&
          (vm.Deleted == null || vm.Deleted == false)*/)
        {
            if (e.meattype != vm.meattype) e.meattype = vm.meattype;
            if (e.meatcut != vm.meatcut) e.meatcut = vm.meatcut;
            if (e.smokingtemp != vm.smokingtemp) e.smokingtemp = vm.smokingtemp;
            if (e.approxtime != vm.approxtime) e.approxtime = vm.approxtime;
            return true;
        }
        return false;
    }
}
