
backend:
	dotnet watch -p Server run

frontend:
	npm run start --prefix Client

app:
	@docker-compose up --force-recreate

kill:
	@docker-compose stop