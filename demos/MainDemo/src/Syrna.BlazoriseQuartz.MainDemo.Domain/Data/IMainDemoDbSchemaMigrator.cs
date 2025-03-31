using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.MainDemo.Data;

public interface IMainDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
