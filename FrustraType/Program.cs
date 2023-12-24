namespace FrustraType
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if (args.Length == 0)
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }else
            {
                foreach(string s in args) {
                    ApplicationConfiguration.Initialize();
                    Application.Run(new Form1(s));
                }
            }
        }
    }
}