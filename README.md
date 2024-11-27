# SecuringApi

An example of securing and authorizing APIs using Jwt Bearer tokens and Role Based Access (RBAC)

# MainAPI

The MainApi is the entrypoint to the system. It is the only publicly exposed API. The MainAPI doesn't check roles, it verifies that the token is valid and includes an Audience for MainApi. It passes the token to the other APIs to handle any further authorization. 
If MainApi was more than an orchestrator then it may have it's own authorization mechanis. 

# Client Service

The client API is an API that will be used to manage client data. The ClientService checks for the role ClientReader. 

# Report Service

The Report Api will represent an API responsible for generating reports. The report service uses ReportCreator and ReportReader roles to authorize a user. The ReportCreator allows the reports to be created while the reader allows them to be viewed.
Being a ReportCreator does not guarantee that you can see the report. 

# Authentication.Extensions

Project for creating a standardize authentication process for Apis. 

# keycloak

Keycloak is an identity provider capable or handling OIDC and SAMl authentication. There is a tenant called MyRealm that is used by the APIs to validate the JWT tokens using the .wellknown endpoints for configuration. 

## Master Realm

The master realm in keycloak acts as the "SuperAdmin" and is the only realm capable of accessing and managing other realms. The username and password is *admin*. Realms are what keycloak calls tenants. 

## MyRealm

MyRealm is the realm used for the application. MainApi, ClientService and ReportService are registered as clients but they can't authenticate themselves. They are used to group roles together inside of keycloak. 
The ExampleApplication is a client with *Direct Access Grant* also known as the Resource Owner, which allows the username and password to be passed with the client id and secret. While the authorization code flow is preferred for user interaction, 
This is useful for user-less environments and integration tests. 

There is also a test user created with the username and password of testuser.