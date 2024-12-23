﻿using Bookify.Infrastructure.Authentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Bookify.Infrastructure.Authentication;

public sealed class AdminAuthorizationDelegatingHandler : DelegatingHandler
{
    private readonly KeycloakOptions _keycloakOptions;

    public AdminAuthorizationDelegatingHandler(IOptions<KeycloakOptions> keycloakOptions)
    {
        _keycloakOptions = keycloakOptions.Value;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var authorizationToken = await GetAuthorizationToken(cancellationToken);

        request.Headers.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            authorizationToken.AccessToken);

        var httpResponseMessage = await base.SendAsync(request, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();

        return httpResponseMessage;
    }

    private async Task<AuthorizationToken> GetAuthorizationToken(CancellationToken cancellationToken)
    {
        var authorizationRequestParameters = new KeyValuePair<string, string>[]
        {
            new("client_id", _keycloakOptions.AdminClientId),
            new("client_secret", _keycloakOptions.AdminClientSecret),
            new("scope", "openid email"),
            new("grant_type", "client_credentials")
        };

        var authorizationRequestContent = new FormUrlEncodedContent(authorizationRequestParameters);

        var authorizationRequest = new HttpRequestMessage(
            HttpMethod.Post,
            new Uri(_keycloakOptions.TokenUrl))
        {
            Content = authorizationRequestContent
        };

        var authorizationResponse = await base.SendAsync(authorizationRequest, cancellationToken);

        if (authorizationResponse.StatusCode == HttpStatusCode.Conflict)
        {
            // Handle the conflict, e.g., log a message or throw a custom exception
            throw new ApplicationException("Conflict occurred while requesting authorization token.");
        }

        authorizationResponse.EnsureSuccessStatusCode();

        return await authorizationResponse.Content.ReadFromJsonAsync<AuthorizationToken>() ??
               throw new ApplicationException();
    }
}