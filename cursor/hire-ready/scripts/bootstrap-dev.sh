#!/usr/bin/env bash
set -euo pipefail

echo "Bootstrap dev — prerequisites: Node 20+, pnpm or npm, .NET 8 SDK, Azure Functions Core Tools (optional)."
echo "Scaffold apps when ready:"
echo "- Web: npx create-vite@latest apps/web -- --template react-ts"
echo "- API: dotnet new webapi -o apps/api -n HireReady.Api"
echo "- Functions: func init apps/functions --worker-runtime dotnet-isolated --target-framework net8.0 && cd apps/functions && func new --name GenerateInterview --template HttpTrigger && cd -"

echo "After scaffolding, update CI to build/test real apps."
