# API Resource Server
Install JwtBearer

`Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 3.1.8`


Edit Startup.cs

Plugin values for `DOMAIN`, `AUTH_SERVER`, and `AUTH_SERVER_AUDIENCE` from your Okta environment.

`
options.Authority = "https://{DOMAIN}/oauth2/{AUTH_SERVER}";
options.Audience = "{AUTH_SERVER_AUDIENCE}";
`

Run:

`dotnet run`
