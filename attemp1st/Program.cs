using System;

namespace attemp1st
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {

            using (var game = new Game1())
            {
                game.Run();
            }

        }
    }
}
