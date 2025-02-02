using SmartSmoker19.Server.Models.AltDbContext;
using SmartSmoker19.Server.Models.ViewModels;
using System.Linq.Expressions;

namespace SmartSmoker19.Server.Models.ViewModels;

public class ThermCamVM
{
    public int id { get; set; }
    public int? run { get; set; }
    public List<decimal>? data { get; set; }
    public DateTime? modified { get; set; }
}

public static class thermcamVmExts
{
    // POCO to VM
    public static readonly Expression<Func<thermcam, ThermCamVM>> ToVmSql = (e) => new ThermCamVM
    {
        id = e.id,
        run = e.run,
        data = e.data,
        modified = e.modified
    };
    public static readonly Func<thermcam, ThermCamVM> ToVM = ToVmSql.Compile();
    public static ThermCamVM AsVM(this thermcam e) => ToVM(e);
    
    // VM to POCO
    public static readonly Func<ThermCamVM, thermcam> ToPoco = (e) =>
    {
        return new thermcam
        {
            id = e.id,
            run = e.run,
            data = e.data,
            modified = e.modified
        };
    };
    public static thermcam AsPoco(this ThermCamVM e) => ToPoco(e);
    
    // Update POCO from VM
    public static bool GraphVM(this ThermCamVM vm, ref thermcam e)
    {
        // Updates (ID == ID, Modified == Modified, Deleted == false
        if (e.id == vm.id /*&& e.Modified == vm.Modified &&
          (vm.Deleted == null || vm.Deleted == false)*/)
        {
            if (e.run != vm.run) e.run = vm.run;
            if (e.data != vm.data) e.data = vm.data;
            if (e.modified != vm.modified) e.modified = vm.modified;
            return true;
        }
        return false;
    }
}
