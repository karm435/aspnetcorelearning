Software Testing, very broad term to talk about. What we are going to discuss here

- Basics
- Automated testing using Unit tests and Integration tests specific to Web app using Aspnetcore3
- Adding conventional test using  Best.Conventional library
- Using Bogus Library to create data for dev environment
- How to manage in Memory database/Real database data for integration tests

All of the above using
- aspnetcore
- sql server
- xUnit
- Moq

Basics
Naming
I usually follow the guidelines given on MSDN while writing tests. It has nice examples of explaining the naming conventions.

I like the important note in the docs.

> It's important to get this terminology correct. If you call your stubs "mocks", other developers are going to make false assumptions about your intent.

I would encourage give [this article](https://martinfowler.com/articles/mocksArentStubs.html) a read to get better understanding of Mocks and Stubs.

Dependency Injection

DI is one of the basic building blocks to enable components ready for testing.

Structure of each Test
- Arrange
- Act
- Assert

These names are self explanatory, for each test we Arrange the data that need for the test then we act on the the SUT (System under test) and then we do assertions on the results.

Mocks

What do we need to mock?
- WebClient
- External Service integration
- Database
- Configuration
- Logger

Mocking configuration
```
var mockConfiguration = new Mock<IConfiguration>();
mockConfiguration.Setup(m => m[It.Is<string>(s => s == "ConfigurationKey")]).Returns(<ConfigurationValue>);
```
Setup
We can follow the instructions given on [MSDN](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) to start setting up the integration tests for aspnetcore.

Above link will explain setup of the WebClient as well. So that we can make api calls similar to how we would do it from the client side.

Database

We have configured the database as a service and we have the ability to use whatever database we like. I have setup 3 base classes to use 3 different databases. I can choose whichever database I like depending on the test.

1. In Memory
2. Sqlite
3. SqlExpress

References
https://martinfowler.com/articles/mocksArentStubs.html

https://martinfowler.com/articles/practical-test-pyramid.html

https://blog.ploeh.dk/2013/10/23/mocks-for-commands-stubs-for-queries/

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1

https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1

https://github.com/dotnet/EntityFramework.Docs/tree/master/samples/core/Miscellaneous/Testing/TestProject
