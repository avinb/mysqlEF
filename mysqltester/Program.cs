using mysqltester.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysqltester
{
    class Program
    {
        static void Main(string[] args)
        {
            myDBContext dbc = new myDBContext();
            foreach (var item in dbc.People)
            {
                Console.WriteLine("Name {0}, Age {1}", item.Name, item.Age);
            }
            string ans = "n";
            do
            {
                Person newperson = new Person();
                string temp="";
                int age = 0;
                do
                {
                    Console.WriteLine("Enter Age");
                    temp = Console.ReadLine();

                } while (! (int.TryParse(temp, out age) && age > 0));
                temp = null;
                newperson.Age = age;
                Console.WriteLine("Enter Name ");
                newperson.Name = Console.ReadLine();
                dbc.People.Add(newperson);
                Console.Write("More People ?");
                ans = Console.ReadLine();
            } while (ans.Equals("y", StringComparison.CurrentCultureIgnoreCase));
            dbc.SaveChanges();

        }
    }

    class myDBContext : DbContext {

        public myDBContext() : base("mysqlconn")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Person> People { get; set; }
    }
}
