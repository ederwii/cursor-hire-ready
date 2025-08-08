# Security

## Threat model snapshot
- Risks: auth misconfig, data leakage across tenants, insecure file uploads, secret exposure, SSRF via PDF generation.
- Mitigations: Auth0 with PKCE and RS256, tenant scoping at API, size/type checks for uploads, secrets in Key Vault (staging/prod), least privilege.

## Auth0 configuration
- SPA: Universal Login, PKCE, allowed origins/callbacks per env.
- API: RS256, audience https://api.hireready.ai, scopes per role.
- Orgs: enable tenant isolation and role mapping.

## Secrets handling
- Dev: GitHub Environments.
- Staging/Prod: Azure Key Vault; access via managed identities.

## OWASP checklist (selected)
- A01: Broken Access Control → roles/permissions, server‑side checks.
- A02: Cryptographic Failures → TLS everywhere, RS256, key rotation.
- A05: Security Misconfiguration → IaC defaults hardened, headers.
- A08: Software/Data Integrity → lockfiles, CI pinning.
- A10: SSRF → restrict outbound, validate URLs.

## How to keep this updated
- Review at each phase and after security changes.
