using System;
using System.Collections.Generic;
using System.Linq;

namespace Bekk.dotnetintro.Data.LinqToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PeopleDataContext())
            {
                //SELECT FirstName, LastName, Email FROM Person
                IEnumerable<Person> people = from person in context.Persons select person;
                foreach (var person in people)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", person.FirstName, person.LastName, person.Email));
                }
                
                Console.WriteLine();

                //SELECT FirstName, LastName, Email FROM Person WHERE Id = @Id
                people = from person in context.Persons where person.Id == 1 select person;
                foreach (var person in people)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", person.FirstName, person.LastName, person.Email));
                }


                //UPDATE Person SET Email=@email WHERE Id=@Id
                var personToUpdate = (from person in context.Persons where person.Id == 1 select person).FirstOrDefault();

                if (personToUpdate != null)
                {
                    personToUpdate.Email = "the.new@ema.il";
                }
                context.SubmitChanges();

                //verify the update
                people = from person in context.Persons where person.Id == 1 select person;
                foreach (var person in people)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", person.FirstName, person.LastName, person.Email));
                }

                Console.ReadLine();
            }
        }
    }
}
