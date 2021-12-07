using System;
using FallingWoman.Sound;

namespace FallingWoman
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new FallingWoman())
                game.Run();
        }
    }
}
