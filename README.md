# SecuringApi

This is an example of securing .net apis with OIDC and Bearer tokens. All Apis are protected by default requiring a valid, unexpired token and a specific audience. 

# MainAPI

The MainAPI is the entry point to the system. It is the only publicly exposed API. The swagger UI is used to represent an "application" that would be using the APIs. 
Instead of using a JWT Bearer token like the other APIs do, it leverages OpenId Connect and Cookie authentication. Utilizing this mechanism for application apis removes the need to store the token directly on the browser, in a readable format. 

This implementation stores the access_token in an encrypted cookie. It is also possible to configure a session store and just send an Opaque cookie which is more secure but harder to scale. 

MainApi does not apply strict authorization rules. It requires a valid user but otherwise leaves authorization to the services. It has two endpoints `/Report` and `/Settings/GetAllSettings`

## /Report

The `/Report` endpoint represents an order sensitive request where it makes a call to `/client/{clientid}/` to get client data that is passed to the `/report` endpoint. 

## /Settings/GetAllSettings

The `Settings/GetAllSettings` makes a call to `/client/{clientId}/settings` and `/Report/Settings?clientId={clientId}`. Since these calls are not dependent on each other it uses Task.WhenAll to allow them to be called simultaneously. 

## Polly Retry

All of the http clients are registered with the HttpClientFactory with a retry. It uses polly to implement exponential backoff when on 500s, timeouts and 404s. 


# Client Service

The client service uses a Jwt Bearer token with a ClientService audience for validating the token. It has two endpoints `GET /Client/{ClientId}` which is protected by an authorization policy called `CanGetClientInfo`and requires a role. The second endpoing is `GET /client/{clientId}/settings` which is protected by a different policy called `CanReadClientSettings`

# Report Service

The report service uses a Jwt Bearer token with a ReportService audience for validating the token. It has two endpoints `POST /Report` which is protected by an authorization policy called `CanGenerateReport`and requires a role. The second endpoing is `/Report/Settings?clientId={clientId}` which is protected by a different policy called `CanReadReportSettings`

# keycloak

Keycloak is an identity provider capable or handling OIDC and SAMl authentication. There is a tenant called MyRealm that is used by the APIs to validate the JWT tokens using the .wellknown endpoints for configuration. The test user credentials are `testuser` for the username and password. 

# dcproj

Developing software with multiple dependencies can be a pain. To simplify this process, I dockerized all the applications and then created a dcproj file in Visual Studios. The dcproj file allows you to execute docker compose commands to run your application. This allowed me to start all 3 APIs and keycloak together. 

# Running the application (Easy Way)

1. install docker desktop or rancher desktop 
2. update hosts file so that host.docker.internal points to 127.0.0.1 (localhost)
3. Run the application using `docker compose up -d` or through Visual Studios. 

Note: Visual Studios changes the project name of the compose file so data does not transfer between the two running methods.    