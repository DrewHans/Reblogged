# Reblogged
Reblogged is a C# / ASP.NET Core 2.1 blogging application that I made in my free time to improve my full-stack web development skills.

## License
This project is licensed under the GPL-3.0 License - see the [LICENSE](LICENSE) file for details

### Project Prerequisites
* ASP.NET Core 2.1 SDK
* Visual Studio Code (highly recommended)

### Project Structure
    ./
    ├─ docs/                    # Documentation files
    ├─ src/                     # Source code files
    │  │
    │  ├─ .vscode               # VSCode settings, task config, & debug config
    │  │
    │  ├─ Blog.Core/            # The core blog application logic lives here
    │  │  ├─ Adapters/          # DataAccess wrappers
    │  │  ├─ Attributes/        # Custom class & property Attributes
    │  │  ├─ Builders/          # Objects that build other objects
    │  │  ├─ Configuration/     # Magic strings are declared here
    │  │  ├─ DataAccess/        # DataAccess implementations (file, sql, web, etc.)
    │  │  ├─ Exceptions/        # Custom Blog.Core exceptions
    │  │  ├─ Models/            # DTOs - Data Transfer Objects
    │  │  ├─ Repositories/      # Follow the Repository Pattern
    │  │  ├─ Validators/        # Validate Models that get passed to Repos
    │  │  │
    │  │  ├─ Blog.Core.csproj
    │  │  └─ Program.cs
    │  │
    │  ├─ Blog.Core.Test/       # Blog.Core testing logic lives here
    │  │  ├─ Factories/         # Objects responsible for creating other objects used in tests
    │  │  │
    │  │  ├─ Fakes/             # Abstact (fake) objects that implement Blog.Core interfaces
    │  │  │  ├─ Mocks/          # Objects with mocking functionality (inherit from Stubs)
    │  │  │  └─ Stubs/          # Objects with stubbing functionality (inherit from Fakes)
    │  │  │
    │  │  ├─ UnitTests/         # Unit Tests live here (not integration tests)
    │  │  │
    │  │  ├─ Blog.Core.Test.csproj
    │  │  ├─ genreport.bash     # Runs ReportGenerator on opencover.xml report
    │  │  ├─ openreport.bash    # Opens ReportGenerator output in web browser
    │  │  ├─ runallscripts.bash # Runs the other three bash scripts in this dir
    │  │  └─ testcoverage.bash  # Runs dotnet test with Coverlet flags
    │  │
    │  ├─ Blog.MVC/             # Coming soon - ASP.Net MVC Web UI
    │  │  └─ ...
    │  └─ Blog.MVC.Test/        # Coming soon - Blog.MVC testing logic
    │     └─ ...
    │
    ├─ LICENSE
    └─ README.md
