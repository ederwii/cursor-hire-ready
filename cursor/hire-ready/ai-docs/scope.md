# Scope

## User stories by phase
### POC
- As a recruiter, I define a job via conversational intake or form and get a job definition with rubric.
- As a candidate, I enter a PIN to access an interview, answer typed questions with autosave, and submit.
- As a recruiter, I download a PDF report with scores and notes.

### MVP
- As an org admin, I manage tenants via Auth0 Organizations.
- As a recruiter, I see analytics and candidate timelines with comments and tags.
- As a candidate, I log in with Auth0, resume progress, and receive structured feedback.
- The system captures anti‑cheat telemetry (blur count, paste events, typing cadence, latency).

### Production Ready
- As a system admin, I configure retention, audit logs, and alerts; I can export data and manage roles/permissions.

## In-scope vs out-of-scope (current)
- In: PIN portal, typed answers, PDF report, basic rubric, Auth0 integration, multi‑tenant (MVP+), Azure deploys, CI/CD, basic analytics.
- Out (for now): Audio/video interviews, ATS integrations, advanced billing, webcam proctoring.

## Acceptance criteria (testable)
- POC: End‑to‑end happy path deployed, Auth0 login works, smoke suite green on main.
- MVP: Multi‑tenant enabled, adaptive follow‑ups, telemetry recorded, green QA suite on main, staging auto‑deploy.
- Prod: SLOs defined/met, rollback tested, IaC idempotent, security review passed.

## How to keep this updated
- Update when scope changes; align acceptance criteria with QA tests and CI gates.
