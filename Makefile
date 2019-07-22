
backend:
	dotnet watch -p Server run

frontend:
	npm run start --prefix Client

deploy-frontend:
	docker build --rm -t blenz1/dating-frontend -f Client/build/prod/Dockerfile Client
	docker push blenz1/dating-frontend
	kubectl delete po -l app=dating-frontend

deploy-backend:
	docker build --rm -t blenz1/dating-backend -f Server/build/prod/Dockerfile Server
	docker push blenz1/dating-backend 
	kubectl delete po -l app=dating-backend