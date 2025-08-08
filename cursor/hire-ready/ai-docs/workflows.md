# Workflows

## Git strategy
- Trunk‑based with short‑lived feature branches; required checks on PR.

## GitHub Actions
- `ci.yml`: on PR and main — install, build, lint, typecheck, unit tests, headless e2e (smoke); upload artifacts on failure.
- `deploy.yml`: manual dispatch with `env` input — build and deploy web, api, and functions to Azure targets.
- `infra.yml`: manual dispatch with `env` input — provision/update infra via Bicep; output connection strings/URLs as masked.
- `docs-refresh.yml`: on infra or config changes — regenerate parts of `ai-docs/`, open PR.

## Releases
- Tags on main for production releases; staging auto on merge to main.

## How to keep this updated
- Adjust workflows as code structure evolves; keep PR checks aligned with QA gates.
