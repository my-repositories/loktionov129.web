# ProjectName

## Prerequisites

For local development environment follow these instructions: [INSTALL.md](INSTALL.md)

## Development server

Run `make start_local` for a local server.

Api will available on `http://localhost:5000/api/{controller}/{params?}`


## Run tests

```sh
make tests
```

---

## Project Structure

```
.
|-- .github/
|-- .vscode/
|-- artifacts/
|-- docker/
|-- libs/
|-- scripts/
|-- src/
|-- tests/
|-- tools/
|-- .gitignore
|-- .gitattributes
|-- .ToDo
|-- CHANGELOG.md
|-- INSTALL.md
|-- LICENSE
|-- README.md
```

```
.github/ - Templates for issues and pull requests.
artifacts/ - HTML pages, SQL scripts, other stuff.
docker/ - Docker images and compose files.
libs/ - Any additional libraries.
scripts/ - Any additional scripts.
src/ - Source code.
tests/ - Project tests.
tools/ - Any additional tools like a appsettings.json, nlog.config, etc.
CHANGELOG.md - All notable changes to this project will be documented in this file.
INSTALL.md - How to build, install, compile, how to do database migrations.
LICENSE - BSD 2-Clause "Simplified" License
README.md - Info about the project.
```
