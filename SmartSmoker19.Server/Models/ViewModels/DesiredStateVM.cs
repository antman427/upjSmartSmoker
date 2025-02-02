using SmartSmoker19.Server.Models.AltDbContext;
using System.Linq.Expressions;

namespace SmartSmoker19.Server.Models.ViewModels;

public class DesiredStateVM
{
    public int id { get; set; }
    public int? smokingtemp { get; set; }
    public int? targettemp { get; set; }
    public DateTime? modified { get; set; }
}

public static class DesiredStateVmExts
{
    // POCO to VM
    public static readonly Expression<Func<desiredstate, DesiredStateVM>> ToVmSql = (e) => new DesiredStateVM
    {
        id = e.id,
        smokingtemp = e.smokingtemp,
        targettemp = e.targettemp,
        modified = e.modified
    };
    public static readonly Func<desiredstate, DesiredStateVM> ToVM = ToVmSql.Compile();
    public static DesiredStateVM AsVM(this desiredstate e) => ToVM(e);
    
    // VM to POCO
    public static readonly Func<DesiredStateVM, desiredstate> ToPoco = (e) =>
    {
        return new desiredstate
        {
            id = e.id,
            smokingtemp = e.smokingtemp,
            targettemp = e.targettemp,
            modified = e.modified
        };
    };
    public static desiredstate AsPoco(this DesiredStateVM e) => ToPoco(e);

    // Update POCO from VM
    public static bool GraphVM(this DesiredStateVM vm, ref desiredstate e)
    {
        // Updates (ID == ID, Modified == Modified, Deleted == false
        if (e.id == vm.id /*&& e.Modified == vm.Modified &&
          (vm.Deleted == null || vm.Deleted == false)*/)
        {
            if (e.smokingtemp != vm.smokingtemp) e.smokingtemp = vm.smokingtemp;
            if (e.targettemp != vm.targettemp) e.targettemp = vm.targettemp;
            if (e.modified != vm.modified) e.modified = vm.modified;
            return true;
        }
        return false;
    }
}
