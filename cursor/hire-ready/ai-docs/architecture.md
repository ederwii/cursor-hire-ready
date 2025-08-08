# Architecture

## Monorepo layout
```
/apps
  /web            # React + Vite + TS
  /api            # .NET 8 Web API (Clean Architecture)
  /functions      # Azure Functions (generation, scoring)
/packages
  /ui             # shared UI (optional)
  /config         # eslint, prettier, tsconfig shared configs
  /sdk            # shared client SDK (optional)
/infra
  /bicep          # IaC modules
/.github/workflows
/ai-docs
```

## Auth
- Auth0 domain: dev-t1yxjekfcqth4gg7.us.auth0.com
- SPA client ID: DFSgu1uqOqx0WESE1jM5L4ucYgoHQhOe
- API Audience: https://api.hireready.ai
- RS256 JWTs, SPA PKCE, Organizations enabled for multi‑tenant (MVP+).

## Data model sketch
- Tenancy: shared app and DB with `tenantId` on all rows, enforced at API; option to move to per‑tenant DB later.
- Core entities: Tenant, User, JobDefinition, Rubric, Candidate, ResumeProfile, Interview, Question, Answer, ScoreReport, Comment, Event (telemetry).

## Observability
- Serilog with sink to Azure Application Insights; dashboards and basic alerts (availability, error rate, latency).

## How to keep this updated
- Update when adding new apps/packages or when auth/data/observability plans change.
