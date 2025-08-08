#!/usr/bin/env bash
set -euo pipefail

ENVIRONMENT="${1:-dev}"
LOCATION="${2:-eastus2}"

echo "Provisioning (dry-run placeholder). Intended: az deployment group create with Bicep for $ENVIRONMENT in $LOCATION"
echo "Example: az group create -n hr-$ENVIRONMENT-rg -l $LOCATION"
echo "         az deployment group create -g hr-$ENVIRONMENT-rg -f infra/bicep/main.bicep -p environment=$ENVIRONMENT location=$LOCATION"
