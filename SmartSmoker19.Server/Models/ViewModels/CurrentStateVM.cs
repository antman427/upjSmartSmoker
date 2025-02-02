using SmartSmoker19.Server.Models.AltDbContext;
using System.Linq.Expressions;

namespace SmartSmoker19.Server.Models.ViewModels;
public class CurrentStateVM
{
    public int id { get; set; }
    public decimal? probe1 { get; set; }
    public decimal? probe2 { get; set; }
    public decimal? ambient { get; set; }
    public DateTime? modified { get; set; }
}

public static class CurrentStateVmExts
{
    // POCO to VM
    public static readonly Expression<Func<currentstate, CurrentStateVM>> ToVmSql = (e) => new CurrentStateVM
    {
        id = e.id,
        probe1 = e.probe1,
        probe2 = e.probe2,
        ambient = e.ambient,
        modified = e.modified
    };
    public static readonly Func<currentstate, CurrentStateVM> ToVM = ToVmSql.Compile();
    public static CurrentStateVM AsVM(this currentstate e) => ToVM(e);
    
    // VM to POCO
    public static readonly Func<CurrentStateVM, currentstate> ToPoco = (e) =>
    {
        return new currentstate
        {
            id = e.id,
            probe1 = e.probe1,
            probe2 = e.probe2,
            ambient = e.ambient,
            modified = e.modified
        };
    };
    public static currentstate AsPoco(this CurrentStateVM e) => ToPoco(e);
    
    // Update POCO from VM
    public static bool GraphVM(this CurrentStateVM vm, ref currentstate e)
    {
        // Updates (ID == ID, Modified == Modified, Deleted == false
        if (e.id == vm.id /*&& e.Modified == vm.Modified &&
          (vm.Deleted == null || vm.Deleted == false)*/)
        {
            if (e.probe1 != vm.probe1) e.probe1 = vm.probe1;
            if (e.probe2 != vm.probe2) e.probe2 = vm.probe2;
            if (e.ambient != vm.ambient) e.ambient = vm.ambient;
            if (e.modified != vm.modified) e.modified = vm.modified;
            return true;
        }
        return false;
    }
}
