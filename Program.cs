using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace AplikasiArsipppp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new login());

            LiveCharts.Configure(config =>
               config
                   // registers SkiaSharp as the library backend
                   // REQUIRED unless you build your own
                   .AddSkiaSharp()

                   // adds the default supported types
                   // OPTIONAL but highly recommend
                   .AddDefaultMappers()

                   // select a theme, default is Light
                   // OPTIONAL
                   //.AddDarkTheme()
                   .AddLightTheme()

                   // finally register your own mappers
                   // you can learn more about mappers at:
                   // ToDo add website link...
                   
               // .HasMap<Foo>( .... )
               // .HasMap<Bar>( .... )
               );
        }
    }
}