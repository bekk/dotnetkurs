using System;
using System.Linq;

namespace Bekk.dotnetintro.Data.LinqToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dataContext = new BlogDataContext())
            {
                BlogEntry firstBlogEntry = (from blogEntry in dataContext.BlogEntries 
                                                     where blogEntry.Id == 1 
                                                     select blogEntry).FirstOrDefault();
                
                Console.WriteLine("First blogentry");
                Console.WriteLine(string.Format("Id     : {0}", firstBlogEntry.Id));
                Console.WriteLine(string.Format("Title  : {0}", firstBlogEntry.Title));
                Console.WriteLine(string.Format("Content: {0}", firstBlogEntry.Content));
                Console.ReadLine();
            }
        }
    }
}
