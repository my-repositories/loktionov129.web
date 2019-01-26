#!/usr/bin/env bash

set -e
set -u

ENV=${1:-local}
(cd ./docker/ && docker-compose -f docker-compose.$ENV.yml up -d)

#  TODO: create docker-compose.yml and push to them all basic configurations
#  (cd ./docker/ && docker-compose -f docker-compose.yml -f docker-compose.$ENV.yml up -d)
