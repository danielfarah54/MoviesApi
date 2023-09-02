hot-reload:
	dotnet watch run --project ./MoviesApi.csproj --launch-profile hotreloadprofile

start:
	dotnet run --project ./MoviesApi.csproj

db-up:
	docker compose up -d

db-down:
	docker compose down