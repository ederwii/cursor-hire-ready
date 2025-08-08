# HireReady.ai

Monorepo scaffold for HireReady.ai — adaptive, fair first‑round interviews.

## Decisions (locked)
- Azure East US 2, RG per env, naming `hr-{env}-{service}`
- Auth0 domain `dev-t1yxjekfcqth4gg7.us.auth0.com`, SPA client `DFSgu1uqOqx0WESE1jM5L4ucYgoHQhOe`, audience `https://api.hireready.ai`
- FE: React + Vite + TS + Tailwind (+ optional shadcn/ui)
- BE: .NET 8 Web API (Clean Architecture), Serilog→App Insights
- Workers: Azure Functions (generation, scoring) via Service Bus
- Data: Postgres; Storage: Azure Blob

## First run (local)
1. Optional: run `scripts/bootstrap-dev.sh` and follow the scaffold instructions for web/api/functions.
2. Configure local environment variables and Auth0 settings.
3. Commit and push. CI is placeholder until apps are scaffolded.

## Workflows
- See `.github/workflows/` for CI, deploy, infra, docs refresh placeholders.

## Docs
- See `ai-docs/` for scope, architecture, QA, security, and infra notes.
