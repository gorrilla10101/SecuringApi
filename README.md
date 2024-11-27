# SecuringApi

An example of securing and authorizing APIs. 

# MainAPI

The MainApi is the entrypoint to the system. It is the only publicly exposed API

# Client Api

The client API is an API that will be used to manage client data. 

# Report Api

The Report Api will represent an API responsible for generating reports. 

# Authentication.Extensions

Project for creating a standardize authentication process for Apis. 

# keycloak

Keycloak is an identity provider capable or handling OIDC and SAMl authentication. There is a tenant called MyRealm that is used by the APIs to validate the JWT tokens using the .wellknown endpoints for configuration. 

## Master Realm

The master realm in keycloak acts as the "SuperAdmin" and is the only realm capable of accessing and managing other realms. The username and password is *admin*. Realms are what keycloak calls tenants. 

## MyRealm

MyRealm is the realm used for the application. MainApi, ClientService and ReportService are registered as clients but they can't authenticate themselves. They are used to group roles together inside of keycloak. 
The ExampleApplication is a client with *Direct Access Grant* also known as the Resource Owner, which allows the username and password to be passed with the client id and secret. While the authorization code flow is preferred for user interaction, 
This is useful for userless environments and integration tests. 