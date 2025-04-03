# Syrna.BlazoriseQuartz
Quartz scheduling module for ABP framework.

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FVoloAbpPackageVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FSyrnaAbp%2FSyrna.BlazoriseQuartz%2Fmaster%2FDirectory.Packages.props)](https://abp.io)
![build and test](https://img.shields.io/github/actions/workflow/status/SyrnaAbp/Syrna.BlazoriseQuartz/build-all.yml?branch=dev&style=flat-square)
[![NuGet Download](https://img.shields.io/nuget/dt/Syrna.BlazoriseQuartz.Application.svg?style=flat-square)](https://www.nuget.org/packages/Syrna.BlazoriseQuartz.Application)
[![NuGet (with prereleases)](https://img.shields.io/nuget/vpre/Syrna.BlazoriseQuartz.Application.svg?style=flat-square)](https://www.nuget.org/packages/Syrna.BlazoriseQuartz.Application) 

An abp application module that allows manage quartz scheduling.

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/SyrnaAbp/SyrnaAbpGuide/blob/master/docs/How-To.md#add-nuget-packages))

    * Syrna.BlazoriseQuartz.Application
    * Syrna.BlazoriseQuartz.Application.Contracts
    * Syrna.BlazoriseQuartz.Domain
    * Syrna.BlazoriseQuartz.Domain.Shared
    * Syrna.BlazoriseQuartz.EntityFrameworkCore
    * Syrna.BlazoriseQuartz.HttpApi
    * Syrna.BlazoriseQuartz.HttpApi.Client
    * Syrna.BlazoriseQuartz.Web
    * Syrna.BlazoriseQuartz.Blazor
    * Syrna.BlazoriseQuartz.Blazor.Server
    * Syrna.BlazoriseQuartz.Blazor.WebAssembly

1. Add `DependsOn(typeof(BlazoriseQuartzXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/SyrnaAbp/SyrnaAbpGuide/blob/master/docs/How-To.md#add-module-dependencies))

1. Add `builder.ConfigureBlazoriseQuartz();` to the `OnModelCreating()` method in **MyProjectMigrationsDbContext.cs**.

1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC&DB=EF#add-database-migration).

## Usage


## Reference

### This project based on [BlazoriseQuartz](https://github.com/Dolunay/BlazoriseQuartz)

### Differences

1. Demo project created for OpenIddict
2. Demo project extended modules added
3. Blazor modules added

