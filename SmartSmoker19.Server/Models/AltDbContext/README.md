AltDbContext is a temporary database first scaffolding generated with dotnet-ef 
to create code first models, both repositories (tables in EF) and unit of work (database context in EF.)
Later, a DbContext can manually be created, both dbcontext and entities (POCOs) using the AltDbContext seeds.
After that, dotnet-ef can be used to migrate the database (create SQL code to create the tables, relations, etc.)
