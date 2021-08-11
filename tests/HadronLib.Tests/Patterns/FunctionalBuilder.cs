using System.Runtime.CompilerServices;
using HadronLib.Patterns;
using NUnit.Framework;

namespace HadronLib.Tests.Patterns
{
    public class TestSubject
    {
        public string Name;
        public string Surname;

        public TestSubject()
        {
        }
    }

    public class TestSubjectBuilder : FunctionalBuilder<TestSubject, TestSubjectBuilder>
    {
        public TestSubjectBuilder Named(string name)
            => this.Do(subject => subject.Name = name);

        public TestSubjectBuilder Surnamed(string surname)
            => this.Do(subject => subject.Surname = surname);
    }

    public static class TestSubjectBuilderExtensions
    {
        public static TestSubjectBuilder Null(this TestSubjectBuilder builder)
            => builder.Do(subject =>
            {
                subject.Name = "null";
                subject.Surname = "null";
            });

        public class FunctionalBuilder
        {
            [Test]
            public void BaseBuild()
            {
                var testSubjectBuilder = new TestSubjectBuilder();

                string name = "Test";
                string surname = "Subject";

                TestSubject testSubject = testSubjectBuilder
                    .Named(name)
                    .Surnamed(surname)
                    .Build();

                Assert.AreEqual(testSubject.Name, name);
                Assert.AreEqual(testSubject.Surname, surname);
            }

            [Test]
            public void ExtendedBuild()
            {
                var testSubjectBuilder = new TestSubjectBuilder();

                TestSubject testSubject = testSubjectBuilder
                    .Null()
                    .Build();
                
                Assert.AreEqual(testSubject.Name, "null");
                Assert.AreEqual(testSubject.Surname, "null");
            }
        }
    }
}