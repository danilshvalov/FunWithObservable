using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FunWithObservable
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person(){ FirstName = "Peter", LastName = "Murphy", Age = 52},
                new Person(){ FirstName = "Kevin", LastName = "Key", Age = 48},
            };

            people.CollectionChanged += people_CollectionChanged;

            people.Add(new Person() { FirstName = "Fred", LastName = "Jonnat", Age = 40 });

            Console.ReadLine();
        }
        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"Action for this event: {e.Action}");

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are OLD items:");
                foreach(Person item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are NEW items:");
                foreach (Person item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
        }
    }
}
