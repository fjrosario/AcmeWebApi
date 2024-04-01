This is my attempt at a solution for assessment, as defined in requirements.txt.

Please note, this solutions is not complete due to time constraints. I have not implemented the following:

- Authorization/Authentication 
- Docker Compose Up. The Docker Image Build is working, but I have not tested it with Docker Compose Up
- Integration Tests
- No IaC work done, since not appropriate to work on "Extra credit" tasks before completing the main task."



Notes about author:
* 21 years of experience in .Net Framework, but only 1 year of experience in .Net Core


Notes aoout the solution:

* I'm using Asp.Net Core Minimal Api.

* I'm using Entity Framework Core with InMemory database.

* I'm using Swagger for API documentation. This may seem as unnecessary, but I'm using it to document the API and to test it. More specifically, I had planned to use swagger.json to generate the client code for the integration tests via 
  the Dredd NPM package. It also allows me to test the API without having to write client code or setup Postman.

* I'm using MSTest for unit tests. All tests are in the test project and all tests are passing as of this writing


Issues run into while developing the solution:

* The in-memory database was meant to be used for testing purposes only. However, I didn't have time to implement a real database. I would have used a real database or local file (SQLite or LocalDb) for the solution, 
but I didn't have time to implement it.

* Due to time constraints, the code is messy and lacks documentation. I would have liked to refactor the code and add more comments. For example, there's a lot of repeated code in the repository, service, and test service classes that
could be refactored with a base class and probably some generics.

* Program.cs is a bit messy. I would have liked to refactor it and move some code to a separate classes.

* Swagger generated documentation is not perfect. I would have liked to add more information to the documentation, such as examples, and more detailed descriptions. However, I ran into some issues with Swagger configuration with being unable to
geneerate default and example values for the Id property of the models. Because of this, I had difficulty generating the client code for the integration tests via Dredd. This ended up taking a lot of time, and I didn't have time to fix it.

* Because of the above issue, I didn't have time to implement Auth* functionality. I had planned to do this after the integration tests were working, so I can then add the Auth* functionality and test it with the integration tests properly.


Cheers,
Frank Rosario
