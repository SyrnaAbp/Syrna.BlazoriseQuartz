using AutoMapper;
using Syrna.BlazoriseQuartz.ExecutionLog;
using Syrna.BlazoriseQuartz.ExecutionLog.Dtos;
using static Syrna.BlazoriseQuartz.Authorization.BlazoriseQuartzPermissions;

namespace Syrna.BlazoriseQuartz
{
    public class BlazoriseQuartzApplicationAutoMapperProfile : Profile
    {
        public BlazoriseQuartzApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<ExecutionLog.ExecutionLog, ExecutionLogDto>();
            CreateMap<ExecutionLog.ExecutionLogDetail, ExecutionLogDetailDto>();

        }
    }
}
