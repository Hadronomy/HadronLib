using System.Runtime.CompilerServices;
using HadronLib.Patterns;
using Xunit;

namespace HadronLib.Tests.Patterns
{
    #region Classes

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
    }

    #endregion

    #region Tests

    public class FunctionalBuilder
    {
        [Fact]
        public void Default_Builds_As_Expected()
        {
            var testSubjectBuilder = new TestSubjectBuilder();

            string name = "Test";
            string surname = "Subject";

            TestSubject testSubject = testSubjectBuilder
                .Named(name)
                .Surnamed(surname)
                .Build();

            Assert.Equal(testSubject.Name, name);
            Assert.Equal(testSubject.Surname, surname);
        }

        [Fact]
        public void Extended_Builds_As_Expected()
        {
            var testSubjectBuilder = new TestSubjectBuilder();

            TestSubject testSubject = testSubjectBuilder
                .Null()
                .Build();
            
            Assert.Equal("null", testSubject.Name);
            Assert.Equal("null", testSubject.Surname);
        }
    }

    #endregion
}
