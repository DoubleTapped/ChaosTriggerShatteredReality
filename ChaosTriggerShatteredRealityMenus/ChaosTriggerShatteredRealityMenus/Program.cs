using System;
using System.Windows.Forms;

namespace ChaosTriggerShatteredRealityMenus
{
#if WINDOWS || XBOX
    static class Program
    {

        static void Main(string[] args)
        {
            using (ScreenManager game = new ScreenManager())
            {
                try
                {
                    game.Run();
                }
                catch (Exception ex)
                {
                    using (CrashHandler crashHandler = new CrashHandler(ex.Message, ex.StackTrace))
                    {                
                        if(crashHandler.ShowDialog() == DialogResult.OK)
                        {
                            Console.WriteLine("Exception thrown: " + ex);
                        }
                    }
                }
            }
        }
    }
#endif
}

