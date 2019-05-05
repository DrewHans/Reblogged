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
    │  ├─ Blog.MVC.Test/         # Blog.MVC testing logic lives here
    │  │  ├─ IntegrationTests/   # Integration Tests live here (no unit tests)
    │  │  │
    │  │  └─ Blog.MVC.Test.csproj
    │  │
    │  └─ Blog.Secrets/          # UserSecrets for demoing MVC app with FileDataAccess
    │
    ├─ LICENSE
    └─ README.md

### Getting Setup
1. Clone the Reblogged repository.
2. Open Visual Studio Code & press the 'Open Folder' button. Select the Reblogged folder.
3. Some popups will appear in Visual Studio Code. Select 'Yes' or 'Restore' for all popups to setup your local environment. This should only take a minute.

### Setting Up UserSecrets
1. Using Visual Studio Code's explorer, expand src/Blog.Secrets.
2. Right click on the UserSecrets folder and click 'Reveal in Explorer'.
3. Copy the folder contents of UserSecrets to the appropriate directory below:
* On Windows: 'C:\Users\<your_username>\AppData\Roaming\Microsoft\UserSecrets\'
* On Linux: '~/.microsoft/usersecrets/'
4. Go inside the folder you just copied and open the secrets.json file.
5. Update the paths in secrets.json. These paths can look different depending on your operating system & file structure.
* On Linux it may look like:
* * '~/Desktop/Reblogged/src/Blog.Database/FileDB/blogposts.json'
* * '~/Desktop/Reblogged/src/Blog.Database/FileDB/blogusers.json'
* On Windows it may look like:
* * 'C:\\Users\\<your_username>\\Desktop\\Reblogged\\src\\Blog.Database\\FileDB\\blogposts.json'
* * 'C:\\Users\\<your_username>\\Desktop\\Reblogged\\src\\Blog.Database\\FileDB\\blogusers.json'

Note: Adding UserSecrets to public version control is a very bad idea. It is only done here to simplify setting up this project for demos. Never do this in a real production system!

### Running the MVC Web App
1. Make sure you have followed the steps listed above in 'Getting Setup' & 'Setting Up UserSecrets'.
2. Open the terminal in Visual Studio Code & type 'cd ./src/Blog.MVC/' and press enter.
3. Now, still in the terminal, type 'dotnet run' & press enter.
4. Open your web browser & go to 'http://localhost:5000/'
