# Bicep Infra

Top-level `main.bicep` orchestrates per-environment deployments by consuming modules in `modules/`.

Parameters to pass via workflow or CLI:
- `environment` (dev|staging|prod)
- `location` (e.g., eastus2)
- naming base (hr)
