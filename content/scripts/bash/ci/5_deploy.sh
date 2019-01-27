COMMANDS_TO_RUN+=('echo 5_deploy.sh ...')

COMMANDS_TO_RUN+=('npx semantic-release --branch $BRANCH')

COMMANDS_TO_RUN+=('git remote add github https://github.com/$GITHUB_REPO_OWNER/$GITHUB_REPO_NAME.git')
COMMANDS_TO_RUN+=('git pull github $BRANCH')

COMMANDS_TO_RUN+=('bash scripts/bash/bash_runner.sh scripts/bash/gitlab_sync.sh')
COMMANDS_TO_RUN+=('bash scripts/bash/bash_runner.sh scripts/bash/docker/deploy.sh')
