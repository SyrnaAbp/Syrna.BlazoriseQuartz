using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Syrna.BlazoriseQuartz;

namespace Syrna.BlazoriseQuartz.MainDemo.EntityFrameworkCore
{
    [ConnectionStringName(BlazoriseQuartzDbProperties.ConnectionStringName)]
    public interface IMainDemoDbContext : IEfCoreDbContext
    {
    }
}
