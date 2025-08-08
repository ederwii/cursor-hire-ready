# QA Strategy

## Test pyramid
- Unit: Vitest (FE), xUnit (API), Functions unit tests.
- Integration: API with in‑memory or containerized Postgres.
- E2E: Playwright headless for critical flows.

## Coverage targets
- Initial: 70% lines in FE and API. Increase over time.

## Critical paths and smoke tests
- Create job → upload resume → generate interview → candidate answers → score → download PDF.

## CI gating rules
- Required checks on PR: build, lint, typecheck, unit tests, selected e2e smoke.
- Flaky policy: quarantine with owner and auto‑open issue; fix within sprint.

## How to keep this updated
- Keep critical paths in sync with product changes; ensure e2e covers them.
