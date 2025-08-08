# HireReady.ai — Project Overview

## Vision, Problem, Users, Success Metrics
- **Vision**: Level the playing field in hiring by automating high‑quality, fair, and explainable first‑round interviews.
- **Problem**: Early technical screens are noisy, slow, and inconsistent.
- **Primary Users**: Recruiters/Hiring Managers, Candidates, System Admins (multi‑tenant).
- **Success Metrics**: 50% faster time‑to‑screen, +30% quality of slate, >80% completion, standardized/fairness evidence.

## Phases and Exit Criteria
- **POC**: Single‑tenant, PIN login candidate portal, typed answers only, one happy path in cloud, smoke green, Auth0 works.
- **MVP**: Multi‑tenant via Auth0 Orgs, adaptive interviews v2, baseline anti‑cheat telemetry, staging parity, coverage SLO; green QA suite on main and auto deploy to staging.
- **Prod Ready**: SLOs, alerts, backups, data retention, audit logs, RBAC, rate limits, SOC2 posture; rollback tested, IaC idempotent.

## High‑Level Architecture and Tech Choices
- **Frontend**: React + Vite + TypeScript, Tailwind with optional shadcn/ui.
- **Backend**: .NET 8 Web API, REST, Clean Architecture, Serilog → App Insights.
- **Workers**: Azure Functions for interview generation and scoring, queue‑triggered (Service Bus).
- **Auth**: Auth0 SPA + API, RS256, Organizations for tenants.
- **Data**: Postgres (dev local container, Azure Flexible Server in non‑prod/prod), Azure Blob Storage for resumes/reports.
- **Infra**: Azure, East US 2. One RG per env. IaC via Bicep. Naming `hr-{env}-{service}`.
- **CI/CD**: GitHub Actions for CI, deploy, infra, docs refresh.

## How to keep this updated
- Update this file whenever goals, users, or success metrics change.
- The `docs-refresh.yml` workflow will open a PR to refresh relevant sections when infra or app structure changes.
