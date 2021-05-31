using Raven.TestDriver;
using Xunit;

namespace RavenTests
{
    public class RavenTests : RavenTestDriver
    {
        [Fact]
        public void ExpectNullUser()
        {
            using var store = GetDocumentStore();

            using var session = store.OpenSession();

            session.Store(new User
            {
                FirstName = "John",
                LastName = "Doe",
                CompanyId = ""
            });

            session.SaveChanges();

            string id1 = null;
            var user1 = session.Load<User>(id1);
            Assert.Null(user1);

            string id2 = "";

            var user2 = session.Load<User>(id2);
            Assert.Null(user2);
        }
    }

    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyId { get; set; }
    }

    public class Company
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
