# VocabularyBuilder Project
Project about an App which is able to save vocabulary for an Idiom Language and then show the information with FlashCards, this FlashCards could be daily, weekly or monthly in order to increase vocabulary to an user.

# Solution
This project was implemented with an structructure of _Clean Architecture, Mediator Pattern, Domain Driven Design, Dependency Injection, and everything related of it._

## Framework, package and tools
- .Net Core 3.1
- EF Core
- MediatR
- Automapper
- FluentValidation
- Fluent API
- XUnit
- FakeItEasy
- Swashbuckle
- Identity
- FuentAssertions
- SqlServer
- Ef Migrations


## Setup

1. Clone this repository
2. At the root directory using PowerShell, type the following:<br/>
  **_dotnet restore_**
3. Build the solution in order to check if everything is ok:<br/>
**_dotnet build_**
4. To update everything in the database you need to type the following in the root directory:<br/>
**_dotnet ef database update --project src\Infrastructure\ --startup-project src\WebAPI_**
5. To run the Backend move to **src/WebAPI/** directory, and then execute the following:<br/>
**_dotnet run_** <br/>
You will see something like this:
![alt text](https://github.com/ever1509/VocabularyBuilder/blob/master/images/APIDemo.png?raw=true)
