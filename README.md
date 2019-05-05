# Reblogged
Reblogged is a C# / ASP.NET Core 2.1 MVC blogging application that I made in my free time to improve both my full-stack web development skills and my unit testing skills.

## License
This project is licensed under the GPL-3.0 License - see the [LICENSE](LICENSE) file for details

### Project Prerequisites
* ASP.NET Core 2.1 SDK
* Visual Studio Code (highly recommended)

### Project Structure
    ./
    ├─ docs/                     # Documentation files
    ├─ src/                      # Source code files
    │  │
    │  ├─ .vscode                # VSCode settings, task config, & debug config
    │  │
    │  ├─ Blog.Core/             # The core blog application logic lives here
    │  │  ├─ Adapters/           # DataAccess wrappers
    │  │  ├─ Attributes/         # Custom class & property Attributes
    │  │  ├─ Builders/           # Objects that build other objects
    │  │  ├─ Configuration/      # Magic strings are declared here
    │  │  ├─ DataAccess/         # DataAccess implementations (file, sql, web, etc.)
    │  │  ├─ Exceptions/         # Custom Blog.Core exceptions
    │  │  ├─ Models/             # DTOs - Data Transfer Objects
    │  │  ├─ Repositories/       # Follow the Repository Pattern
    │  │  ├─ UseCaseInteractors/ # Interactors (follow request/response protocol)
    │  │  ├─ Validators/         # Validate Models that get passed to Repos
    │  │  │
    │  │  ├─ Blog.Core.csproj
    │  │  └─ Program.cs
    │  │
    │  ├─ Blog.Core.Test/        # Blog.Core testing logic lives here
    │  │  ├─ Factories/          # Objects responsible for creating other objects used in tests
    │  │  ├─ Fakes/              # Abstact (fake) objects that implement Blog.Core interfaces
    │  │  │  ├─ Mocks/           # Objects with mocking functionality (inherit from Stubs)
    │  │  │  └─ Stubs/           # Objects with stubbing functionality (inherit from Fakes)
    │  │  ├─ UnitTests/          # Unit Tests live here (not integration tests)
    │  │  │
    │  │  ├─ Blog.Core.Test.csproj
    │  │  ├─ genreport.bash      # Runs ReportGenerator on opencover.xml report
    │  │  ├─ openreport.bash     # Opens ReportGenerator output in web browser
    │  │  ├─ runallscripts.bash  # Runs the other three bash scripts in this dir
    │  │  └─ testcoverage.bash   # Runs dotnet test with Coverlet flags
    │  │
    │  ├─ Blog.Database/         # Database related files live here
    │  │  ├─ FileDB/             # Contains json files used for file-backed data access
    │  │  ├─ SQLServer/          # Contains SQLServer management scripts
    │  │  │
    │  │  └─ README.md
    │  │
    │  ├─ Blog.MVC/              # .Net MVC Web UI lives here
    │  │  ├─ Controllers/        # MVC controllers
    │  │  ├─ Models/             # MVC models
    │  │  ├─ Presenters/         # Used to simplify passing data from controllers to views
    │  │  ├─ Views/              # MVC views
    │  │  ├─ wwwroot/            # Web assests (css, js, images, libs) live here
    │  │  │
    │  │  ├─ Blog.MVC.csproj
    │  │  ├─ BlogCoreSetup.cs    # Simple class to handle initializing Blog.Core classes
    │  │  ├─ Program.cs
    │  │  └─ startup.cs
    │  │
    │  └─ Blog.MVC.Test/         # Blog.MVC testing logic lives here
    │     ├─ IntegrationTests/   # Integration Tests live here (no unit tests)
    │     │
    │     └─ Blog.MVC.Test.csproj
    │
    ├─ LICENSE
    └─ README.md

### Getting Setup
1. Clone the Reblogged repository.
2. Open Visual Studio Code & press the 'Open Folder' button. Select the Reblogged folder.
3. Some popups will appear in Visual Studio Code. Select 'Yes' or 'Restore' for all popups to setup your local environment. This should only take a minute.

### Running the MVC Web App
1. Make sure you have followed the steps listed above in 'Getting Setup'.
2. Open the terminal in Visual Studio Code & type 'cd ./src/Blog.MVC/' and press enter.
3. Now, still in the terminal, type 'dotnet run' & press enter.
4. Open your web browser & go to 'http://localhost:5000/'
