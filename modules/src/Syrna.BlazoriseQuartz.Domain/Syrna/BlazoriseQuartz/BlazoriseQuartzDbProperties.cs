namespace Syrna.BlazoriseQuartz
{
    public static class BlazoriseQuartzDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Pm";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "SyrnaBlazoriseQuartz";
    }
}
