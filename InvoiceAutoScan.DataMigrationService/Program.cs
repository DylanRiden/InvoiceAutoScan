using InvoiceAutoScan.Core.Data;
using InvoiceAutoScan.Source.Data;
using Microsoft.EntityFrameworkCore;


DbContextOptionsBuilder<CoreDataContext> coreOptionsBuilder = new();
coreOptionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ias-db;");
CoreDataContext context = new(coreOptionsBuilder.Options);

Console.WriteLine("MIGRATING CORE CONTEXT");
context.Database.Migrate();

DbContextOptionsBuilder<CommonSourceDataContext> sourcesOptionsBuilder = new();
sourcesOptionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ias-db;");
CommonSourceDataContext sourceContext = new(sourcesOptionsBuilder.Options);

Console.WriteLine("MIGRATING SOURCE CONTEXT");
sourceContext.Database.Migrate();
