# ProjectName

Multiplayer Game Platform

---

## Download .NET Core

[https://www.microsoft.com/net/learn/get-started/linuxubuntu](https://www.microsoft.com/net/learn/get-started/linuxubuntu)

---

## Download PostgreSQL

[https://www.postgresql.org/download/](https://www.postgresql.org/download/)

---

## Edit configuration

```sh
cp ./tools/appsettings.default.json ./tools/appsettings.json
(cd ./src/ProjectName.DataAccess && dotnet restore)
nano ./tools/appsettings.json
```

### Change params:

DefaultConnectionString to "psql"

WebApiUrl to "http://0.0.0.0:5000"

---

## Configure database

Create database "ProjectName" and user "agent4ProjectName" with password "v3ry23C93tp422w0Rd"

Grant all privileges on database "ProjectName" to "agent4ProjectName"

```sh
./scripts/bash/postgres_initializer.sh
```

---

## Logs

```
sudo mkdir -p /var/log/ProjectName
sudo chown -R $USER /var/log/ProjectName
sudo chmod -R 777 /var/log/ProjectName
