param environment string // dev|staging|prod
param location string = 'eastus2'
param nameBase string = 'hr'

var rgName = '${nameBase}-${environment}-rg'
var tags = {
  environment: environment
  project: 'HireReady'
}

// Modules (placeholders) — wire up as they are implemented
// module storage 'modules/storage.bicep' = {
//   name: 'storage'
//   params: { environment: environment, nameBase: nameBase, location: location, tags: tags }
// }
