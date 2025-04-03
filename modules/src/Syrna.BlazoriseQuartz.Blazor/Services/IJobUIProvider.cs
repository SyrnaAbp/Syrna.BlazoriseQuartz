using System;

namespace Syrna.BlazoriseQuartz.Blazor.Services
{
    public interface IJobUIProvider
    {
        Type GetJobUIType(string jobTypeFullName);
    }
}