# Client Credentials Flow Client
Install Newtonsoft.Json

`Install-Package Newtonsoft.Json -Version 12.0.2`


Edit appsettings.json

Plugin values for `DOMAIN`, `AUTH_SERVER`, `CLIENT_SECRET`, and `CLIENT_ID` from your Okta environment.

`"TokenUrl": "https://{DOMAIN}/oauth2/{AUTH_SERVER}/v1/token",`

`"ClientId": "{CLIENT_ID}",`

`"ClientSecret": "{CLIENT_SECRET}"`

Run:

`dotnet run`

Open https://localhost:5001
