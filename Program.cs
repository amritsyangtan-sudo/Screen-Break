using Avalonia;
using ScreenBreak.Models;
using ScreenBreak.Services;
using System;

namespace ScreenBreak
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
#if DEBUG
                .WithDeveloperTools()
#endif
                .WithInterFont()
                .LogToTrace();


      
    }


}


/*
 1. TimerService
2. Work/Break Switching
3. SessionRecord Model
4. HistoryService
5. Statistics Calculation
6. Notifications
7. History Page
8. Eye Exercises Page
9. Refactor Architecture
10. UI Enhancements
*/