~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=
1. Change the SQL User Id, Password,Data Source and Database
2. Change the -OutputDir based on the local directory of Core project
3. Run the command via Package Manager Console
~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=~+=
Scaffold-DbContext "Data Source=localhost;Database=Test;Integrated Security=false;User ID=demo;Password=demo;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir "C:\GinoFiles\Source-Code\ArchitectureDemo\ArchitectureDemo\Core\Domains"
