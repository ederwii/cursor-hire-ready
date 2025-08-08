#!/usr/bin/env bash
set -euo pipefail

# Usage: ./scripts/setup-github-envs.sh <owner/repo>
REPO="${1:-}"
if [ -z "$REPO" ]; then
  echo "Provide the repo in 'owner/name' form, e.g. ederwii/cursor-hire-ready"
  exit 1
fi

echo "Target repo: $REPO"

envs=(dev staging prod)
for e in "${envs[@]}"; do
  echo "Creating environment: $e"
  gh -R "$REPO" api \
    --method PUT \
    -H "Accept: application/vnd.github+json" \
    "/repos/$REPO/environments/$e" >/dev/null

done

echo "Seeding common vars and secrets (you can edit later in GitHub UI)"
# Common repository variables (non-secret)
common_vars=(
  "AZURE_LOCATION=eastus2"
)
for kv in "${common_vars[@]}"; do
  key="${kv%%=*}"; val="${kv#*=}"
  gh -R "$REPO" variable set "$key" -b"$val"
  echo "Set repo variable: $key"
done

# Per-environment secrets
seed_secret() {
  local env="$1" key="$2" val="$3"
  gh -R "$REPO" secret set "$key" --env "$env" -b"$val"
  echo "[$env] secret set: $key"
}

# Replace placeholders below with real values or export env vars before running
AUTH0_DOMAIN="${AUTH0_DOMAIN:-dev-t1yxjekfcqth4gg7.us.auth0.com}"
AUTH0_CLIENT_ID="${AUTH0_CLIENT_ID:-DFSgu1uqOqx0WESE1jM5L4ucYgoHQhOe}"
AUTH0_AUDIENCE="${AUTH0_AUDIENCE:-https://api.hireready.ai}"
AZURE_SUBSCRIPTION_ID="${AZURE_SUBSCRIPTION_ID:-50213484-f77b-4f96-ba9d-323a3e2eac3f}"

for e in "${envs[@]}"; do
  seed_secret "$e" AUTH0_DOMAIN "$AUTH0_DOMAIN"
  seed_secret "$e" AUTH0_CLIENT_ID "$AUTH0_CLIENT_ID"
  seed_secret "$e" AUTH0_AUDIENCE "$AUTH0_AUDIENCE"
  seed_secret "$e" AZURE_SUBSCRIPTION_ID "$AZURE_SUBSCRIPTION_ID"
  # Future: add storage, service bus, Postgres connection strings after infra is provisioned
 done

echo "Done. Review environments at: https://github.com/$REPO/settings/environments"
