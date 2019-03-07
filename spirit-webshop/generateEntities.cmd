dotnet ef dbcontext scaffold ^
Name=DefaultConnection ^
Microsoft.EntityFrameworkCore.SqlServer ^
--context-dir Entities --output-dir Entities ^
--force ^
--context SpiritDbContext ^
--data-annotations