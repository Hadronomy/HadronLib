using System;
using System.Linq;
using System.Reflection;
using HadronLib.Patterns;
using NUnit.Framework;

namespace HadronLib.Tests.Patterns
{
    #region Classes

    internal class Person
    {
        public static PersonBuilder New => new PersonBuilder();

        public string Name, Surname;
        public string Direction;
        public int Age;

        public override string ToString()
        {
            return $@"
Name = {Name}
Surname = {Surname}
Direction = {Direction}
Age = {Age}
";
        }
    }

    internal class Worker : Person
    {
        public new static WorkerBuilder New => new WorkerBuilder();

        public string Workplace, Salary;

        public override string ToString()
        {
            return $@"
Name = {Name}
Surname = {Surname}
Direction = {Direction}
Age = {Age}
Workplace = {Workplace}
Salary = {Salary}
";
        }
    }

    internal class PersonBuilder : PersonBuilder<Person, PersonBuilder> { }

    internal class PersonBuilder<TSubject, TSelf> : FluentBuilder<TSubject, TSelf>
        where TSelf : PersonBuilder<TSubject, TSelf>
        where TSubject : Person
    {
        public TSelf Named(string name)
        {
            Subject.Name = name;
            return (TSelf) this;
        }

        public TSelf Surnamed(string surname)
        {
            Subject.Surname = surname;
            return (TSelf) this;
        }

        public TSelf LivingAt(string direction)
        {
            Subject.Direction = direction;
            return (TSelf) this;
        }

        public TSelf Aged(int age)
        {
            Subject.Age = age;
            return (TSelf) this;
        }
    }

    internal class WorkerBuilder : WorkerBuilder<Worker, WorkerBuilder> { }

    internal class WorkerBuilder<TSubject, TSelf> : PersonBuilder<TSubject, TSelf>
        where TSelf : WorkerBuilder<TSubject, TSelf>
        where TSubject : Worker
    {
        public TSelf WorksAt(string workplace)
        {
            Subject.Workplace = workplace;
            return (TSelf) this;
        }

        public TSelf Paid(string salary)
        {
            Subject.Salary = salary;
            return (TSelf) this;
        }
    }

    #endregion

    #region Tests

    public class FluentBuilder
    {
        [Test]
        public void SimpleBuild()
        {
            Person personSchema = new Person()
            {
                Age = 18,
                Name = "Pablo",
                Surname = "Hernandez",
                Direction = "LaLaguna"
            };
            
            Person newPerson = Person.New
                .Aged(18)
                .Named("Pablo")
                .Surnamed("Hernandez")
                .LivingAt("LaLaguna");

            foreach(var field in typeof(Person).GetFields())
            {
                var schemaValue = field.GetValue(personSchema);
                var actualValue = field.GetValue(newPerson);

                Assert.AreEqual(schemaValue, actualValue);
                
            }
        }

        [Test]
        public void InheritedBuild()
        {
            Worker workerSchema = new Worker()
            {
                Age = 18,
                Direction = "Direction",
                Name = "Name",
                Surname = "Surname",
                Salary = "Salary",
                Workplace = "Workplace"
            };

            var newWorker = Worker.New
                .Aged(18)
                .LivingAt("Direction")
                .Named("Name")
                .Surnamed("Surname")
                .Paid("Salary")
                .WorksAt("Workplace")
                .Build()
                .First();
            
            foreach(var field in typeof(Person).GetFields())
            {
                var schemaValue = field.GetValue(workerSchema);
                var actualValue = field.GetValue(newWorker);

                Assert.AreEqual(schemaValue, actualValue);
                
            }
        }
    }

    #endregion
}