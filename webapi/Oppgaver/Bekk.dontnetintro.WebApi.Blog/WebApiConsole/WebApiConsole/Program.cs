namespace Bekk.dotnetintro.WebApi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var blogEntries = new WebApiAdapter(args[0]).Get();

            foreach (var blogEntry in blogEntries)
            {
                System.Console.WriteLine(blogEntry.Title);
            }

            System.Console.ReadLine();
        }
    }
}
