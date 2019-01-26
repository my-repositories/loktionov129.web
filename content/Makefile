export ROOT_DIR=${PWD}

build_db:
	bash ./scripts/bash/docker/build.sh project129db

build_web:
	bash ./scripts/bash/docker/build.sh project129web

start_local:
	bash ./scripts/bash/docker/compose.sh local

start_pgadmin_local:
	docker run -p 80:80 \
			-e "PGADMIN_DEFAULT_EMAIL=user@domain.com" \
			-e "PGADMIN_DEFAULT_PASSWORD=SuperSecret" \
			--name pgadmin4 \
			-d dpage/pgadmin4

test:
	bash ./scripts/bash/test_runner.sh