```
docker pull ProjectName129/ProjectNameclient
docker run --rm --hostname localhost -p 8080:8080 --name ProjectNameclient ProjectName129/ProjectNameclient:latest
```

```
# param1: dev or prod
./scripts/bash/docker/compose.sh dev
```

```
# param1: ProjectNameweb or ProjectNamedb
./scripts/bash/docker/build.sh ProjectNameweb
```
