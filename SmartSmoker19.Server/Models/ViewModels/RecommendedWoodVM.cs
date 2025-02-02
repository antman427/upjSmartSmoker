using SmartSmoker19.Server.Models.AltDbContext;
using System.Linq.Expressions;

namespace SmartSmoker19.Server.Models.ViewModels;

public class RecommendedWoodVM
{
    public int id { get; set; }
    public string meattype { get; set; } = null!;
    public string wood0 { get; set; } = null!;
    public string? wood1 { get; set; }
    public string? wood2 { get; set; }
    public string? wood3 { get; set; }
    public string? wood4 { get; set; }
}

public static class RecommendedWoodVmExts
{
    // POCO to VM
    public static readonly Expression<Func<recommendedwood, RecommendedWoodVM>> ToVmSql = (e) => new RecommendedWoodVM
    {
        id = e.id,
        meattype = e.meattype,
        wood0 = e.wood0,
        wood1 = e.wood1,
        wood2 = e.wood2,
        wood3 = e.wood3,
        wood4 = e.wood4
    };
    public static readonly Func<recommendedwood, RecommendedWoodVM> ToVM = ToVmSql.Compile();
    public static RecommendedWoodVM AsVM(this recommendedwood e) => ToVM(e);
    
    // VM to POCO
    public static readonly Func<RecommendedWoodVM, recommendedwood> ToPoco = (e) =>
    {
        return new recommendedwood
        {
            id = e.id,
            meattype = e.meattype,
            wood0 = e.wood0,
            wood1 = e.wood1,
            wood2 = e.wood2,
            wood3 = e.wood3,
            wood4 = e.wood4
        };
    };
    public static recommendedwood AsPoco(this RecommendedWoodVM e) => ToPoco(e);

    // Update POCO from VM
    public static bool GraphVM(this RecommendedWoodVM vm, ref recommendedwood e)
    {
        // Updates (ID == ID, Modified == Modified, Deleted == false
        if (e.id == vm.id /*&& e.Modified == vm.Modified &&
          (vm.Deleted == null || vm.Deleted == false)*/)
        {
            if (e.meattype != vm.meattype) e.meattype = vm.meattype;
            if (e.wood0 != vm.wood0) e.wood0 = vm.wood0;
            if (e.wood1 != vm.wood1) e.wood1 = vm.wood1;
            if (e.wood2 != vm.wood2) e.wood2 = vm.wood2;
            if (e.wood3 != vm.wood3) e.wood3 = vm.wood3;
            if (e.wood4 != vm.wood4) e.wood4 = vm.wood4;
            return true;
        }
        return false;
    }
}
