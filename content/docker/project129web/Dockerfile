# FROM microsoft/dotnet:2.1-sdk AS ProjectNamebuild
FROM microsoft/dotnet:2.1-sdk-alpine AS ProjectNamebuild
WORKDIR /app
COPY /libs/. ./libs/
COPY /tools/. ./tools/
RUN cp -rf ./tools/appsettings.default.json ./tools/appsettings.json
COPY /ProjectName.sln ./ProjectName.sln
COPY /src/ProjectName.Abstract/ProjectName.Abstract.csproj ./src/ProjectName.Abstract/ProjectName.Abstract.csproj
COPY /src/ProjectName.DataAccess/ProjectName.DataAccess.csproj ./src/ProjectName.DataAccess/ProjectName.DataAccess.csproj
COPY /src/ProjectName.Infrastructure/ProjectName.Infrastructure.csproj ./src/ProjectName.Infrastructure/ProjectName.Infrastructure.csproj
COPY /src/ProjectName.Shared/ProjectName.Shared.csproj ./src/ProjectName.Shared/ProjectName.Shared.csproj
COPY /src/ProjectName.Domain/ProjectName.Domain.csproj ./src/ProjectName.Domain/ProjectName.Domain.csproj
COPY /src/ProjectName.Web/ProjectName.Web.csproj ./src/ProjectName.Web/ProjectName.Web.csproj
WORKDIR /app/src/ProjectName.Web
RUN dotnet restore
COPY /src/. /app/src/
RUN dotnet publish -c release -o out

# FIXME: Use alpine instead:
# FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS project129web
# RUN apk add --no-cache gettext
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS project129web
RUN apt-get update && apt-get install -y gettext-base
WORKDIR /app
COPY --from=ProjectNamebuild /app/src/ProjectName.Web/out ./
