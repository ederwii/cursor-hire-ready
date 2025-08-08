# HireReady.ai — Comprehensive Project Brief (Updated)

> Use this document as input to the “Ultimate Prompt” so Cursor can interrogate, scaffold, and automate from POC to MVP to Prod. Keep commas instead of em dashes.

## 1) Vision, Problem, and Goals
**Vision:** Level the playing field in hiring by automating high‑quality, fair, and explainable first‑round interviews that adapt to each job and candidate.

**Problem:** Companies often rely on interviewers without deep technical context, which leads to false negatives and false positives. Requirements are fluid, clients rarely know exactly what they need, and early screens waste time.

**Goals:**
- Convert vague or detailed inputs into clear, testable job definitions.
- Generate adaptive interviews from a candidate’s resume and the job definition.
- Capture trustworthy signals, reduce “noise,” and surface an explainable score.
- Multi‑tenant, enterprise‑grade platform with candidate self‑service portal.

**Primary Users:**
- **Recruiter/Hiring Manager:** defines jobs, reviews interviews, leaves feedback, moves candidates.
- **Candidate:** takes the interview, sees progress, receives structured feedback.
- **System Admin:** manages tenants, usage, billing, and compliance.

**Success Metrics:**
- 50 percent reduction in time‑to‑screen for first round.
- 30 percent improvement in “quality of slate” (as rated by hiring managers).
- Interview completion rate above 80 percent.
- Evidence of fairness and consistency via standardized rubrics and logs.

## 2) Product Scope by Phase
### POC
- Job definition intake, conversational or form based.
- Resume upload, PDF parsing to profile.
- Question set generator: static plus simple adaption based on missing signals.
- Candidate portal with PIN, typed answers only, time limit, auto save.
- Basic scoring rubric, downloadable PDF report.
- Single tenant dev environment, Auth0 test tenant.
- Minimal KPIs: time to complete, average score, dropout rate.

**Exit:** One happy path runs end to end in cloud, smoke tests pass, Auth0 works.

### MVP
- Multi‑tenant with Auth0 Organizations.
- Interview generator v2: adaptive follow‑ups, coverage tracking, topic budgets.
- Anti‑cheating telemetry: focus change count, paste events, typing cadence, time per question, optional webcam disabled by default, clear consent if enabled later.
- Reviewer dashboard: per‑candidate timeline, comments with threads, tags, internal vs public notes.
- Candidate portal: PIN or Auth0 login, progress view, feedback receipt, optional paid “prep pack.”
- Analytics: funnel, question difficulty, score distributions, bias checks.
- CI/CD, infra as code, Playwright e2e, unit and integration tests, coverage SLO.
- Staging parity environment, rollback plan.
  
**Exit:** Core stories live, green QA suite on main, staging deploy auto, error budget defined.

### Production Ready
- SLOs, alerts, backups, data retention policies, audit logs.
- PII handling, tenant data isolation, configurable data residency where feasible.
- Role based access control, fine‑grained permissions, export APIs, webhooks.
- Scalable job queues, rate limits, usage based billing.
- Security review and pen test, DPA templates, SOC2 prep checklist.

**Exit:** Meet SLOs, pass security review, rollback tested, IaC idempotent.

## 3) Multi‑Tenancy and Security
- **Auth:** Auth0, Organizations for tenants, SPA PKCE for web, RS256 for API.
- **Tenancy Model:** Shared app and DB with tenantId on all rows, row‑level security at the API layer, plus query filters. Future option for dedicated DB per tenant.
- **Permissions:** Roles, permissions matrix, allow internal vs public comments.
- **Secrets:** GitHub Environments for dev, Azure Key Vault for staging and prod.
- **Compliance Posture:** PII minimization, configurable retention, right to delete, audit trails.

## 4) Core Features
### 4.1 Job Definition Intake
- **Two Modes:** conversational intake assistant, or deterministic form.
- **Outputs:** responsibilities, must‑haves, nice‑to‑haves, seniority, evaluation rubric, time budget for interview, difficulty target, interview “mood.”
- **Change Tracking:** version jobs and rubrics, link them to interviews.

### 4.2 Resume Understanding
- PDF upload, text extraction, structured profile: skills, projects, seniority signals, gaps.
- Highlight uncertainty or missing data explicitly.

### 4.3 Interview Generation, Adaptive Logic
- **Inputs:** job definition, resume profile, time budget, difficulty, mood.
- **Planner:** allocate minutes across topics, enforce coverage thresholds.
- **Question Bank:** seed by role, expand with AI, deduplicate by skill tag.
- **Adaptive Passes:** if a required competency is weak or untested, inject a short follow‑up, keep the total under time budget.
- **Guardrails:** do not ask personal or protected‑class questions, respect safety filters, avoid trick questions that have no job relevance.
- **Explainability:** every question ties to a rubric criterion and skill tag.

### 4.4 Candidate Experience
- **Access:** short PIN or Auth0 login. PINs time boxed, single use by default.
- **UX:** mobile first, auto save, resume later, progress bar, time remaining.
- **Anti‑Cheat Signals:** window blur count, paste events, typing cadence, answer latency, network interruptions. No webcam or mic by default, add only with explicit consent.
- **Accessibility:** WCAG 2.1 AA baseline, high contrast theme, keyboard nav.

### 4.5 Reviewer Experience
- Candidate timeline, answers with context and signals.
- Rubric scoring UI, calibrated rating scales, weighted competencies.
- Threaded comments, @mentions, internal vs public notes, attachments.
- Decision actions: shortlist, rejection with reason, move to next stage.

### 4.6 Reports and KPIs
- Per job: completion rate, average score, question difficulty, time per section.
- Per tenant: pipeline health, time‑to‑screen, false negative risk flag, bias check indicators.
- Export: CSV, JSON, PDF. Webhooks for ATS integration later.

### 4.7 Monetization Hooks
- Tenant subscription tiers based on interview credits, storage, seats.
- Candidate “prep pack” one‑time purchase: personalized study guide from job profile, with links and structured practice prompts, watermarked PDF.

## 5) Architecture, Stack, and Infra
- **Frontend:** React + Vite, TypeScript, Tailwind or shadcn/ui, mobile first.
- **Backend:** .NET 8 Web API, Clean Architecture, SOLID, MediatR for commands and queries.
- **AI Layer:** Azure OpenAI for question generation, rubric expansion, summarization. Keep prompts deterministic, log versions, include test prompts. Avoid hallucinations by grounding on job definition and resume profile only, never invent facts.
- **DB:** Postgres in dev, Azure Database for PostgreSQL in staging and prod.
- **Storage:** Azure Blob Storage for resumes and generated PDFs.
- **Queues:** Azure Service Bus for async interview generation and report creation.
- **Hosting:** Azure App Service or Container Apps for web and API.
- **IaC:** Bicep, per environment, cheapest options in dev.
- **Observability:** Serilog to App Insights, dashboards, basic alerts.
- **Primary Region:** Azure East US 2 (optimal latency for Mexico and US East), optional Central US DR.

## 6) Data Model Sketch
(Same as before — see original brief.)

## 7) Non‑Functional Requirements
- **Performance:** P95 API under 400 ms for standard operations, generation runs async.
- **Scalability:** horizontal scale on API and workers, queue driven.
- **Security:** least privilege, key rotation, audit logs, rate limits, IP throttling.
- **Privacy:** consent prompts for telemetry, retention rules by tenant.
- **Internationalization:** en default, add es quickly, store locale per candidate.

## 8) Marketing Site — hireready.ai
- **Stack:** Next.js or Astro, Tailwind, SSR for SEO, Stripe checkout.
- **Pages:**
  1. Home — value prop, hero video
  2. Features — recruiter portal, candidate portal, adaptive AI
  3. Pricing — hybrid + credits calculator
  4. About — vision, trust content
  5. Contact — form + Calendly
  6. Legal — Privacy, Terms, Disclaimers
- **CTAs:** Free Trial, Book Demo
- **SEO:** blog section, schema markup, analytics
- **Localization:** en/es
- **Launch Hooks:** share images, early adopter offers

## 9) Pricing Model
### Hybrid (Seats + Credits)
- $99/month per recruiter seat, includes 20 interviews.
- Additional interviews $4 each.
- Prep packs $15 each.

**Rationale:** Predictable MRR with usage-based upside.

## 10) Payment Gateway
- **Stripe**: supports MX RFC persona física, MXN + USD, multi-currency, API-friendly.

## 11) Disclaimers and Compliance
- “This tool aids recruitment decisions but does not replace human judgment.”
- “Candidates must consent to data collection and anti-cheating measures.”
- GDPR, CCPA basics in MVP; SOC2 readiness post-MVP.
- PII handling, deletion on request, audit logs.

## 12) QA Strategy and Coverage
(Same as before, include coverage targets, automation rules, Playwright + unit tests.)

## 13) Exit Criteria
(Same as before, POC → MVP → Prod Ready definitions.)
