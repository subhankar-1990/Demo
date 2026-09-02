# dotnet tool install --global dotnet-ef

# dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# dotnet add package Microsoft.EntityFrameworkCore.Design

# dotnet ef dbcontext scaffold "Name=ConnectionStrings:DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entity --context DemoDbContext --context-dir Context --project Demo.Infrastructure --startup-project Demo.API --force