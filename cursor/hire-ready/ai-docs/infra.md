# Infra

## Environments and regions
- Azure East US 2. Resource groups: `hr-dev-rg`, `hr-staging-rg`, `hr-prod-rg`.
- Naming: `hr-{env}-{service}`.

## Resources per env (baseline)
- App Service plans and apps: `web`, `api` (cheapest for dev).
- Azure Functions (Consumption) for workers.
- Azure Service Bus namespace with queues: `interview-generation`, `scoring-jobs`.
- Azure Storage account with containers: `resumes`, `reports`.
- Azure Database for PostgreSQL Flexible Server.
- Application Insights.

## IaC
- Bicep modules under `infra/bicep`. Manual GitHub Action `infra.yml` provisions or updates per env.

## Deployment flow and rollback
- Build → deploy to environment slot (if used) → smoke tests → swap or keep.
- Rollback by redeploying previous artifact or swapping slots.

## How to keep this updated
- Update with any new resources or changes to sizing/regions.
