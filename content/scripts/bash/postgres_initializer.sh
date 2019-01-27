#!/usr/bin/env bash

set -e
set -u

echo "[postgres_initializer]: begin..."

psql -v ON_ERROR_STOP=1 --username "postgres" <<-EOSQL
    CREATE USER agent4ProjectName;
    CREATE DATABASE ProjectName;
    GRANT ALL PRIVILEGES ON DATABASE ProjectName TO agent4ProjectName;
    ALTER USER agent4ProjectName WITH PASSWORD 'v3ry23C93tp422w0Rd';
EOSQL

echo "[postgres_initializer]: end..."
