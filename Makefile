hot-reload:
	dotnet watch run --project ./MoviesApi.csproj --launch-profile hotreloadprofile

start:
	dotnet run --project ./MoviesApi.csproj

db-up:
	docker compose up -d

db-down:
	docker compose down

migration:
	dotnet ef migrations add $(name)

update-migration:
	dotnet ef database update

remove-migration:
	dotnet ef migrations remove