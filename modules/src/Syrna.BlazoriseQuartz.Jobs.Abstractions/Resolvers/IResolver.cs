using System;
namespace Syrna.BlazoriseQuartz.Jobs.Abstractions.Resolvers
{
    public interface IResolver
    {
        string Resolve(string varBlock);
    }
}

