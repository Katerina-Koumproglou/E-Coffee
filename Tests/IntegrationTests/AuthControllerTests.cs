using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using BackEnd.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task SignUp_ReturnsSuccess()
    {
        var signupUser = new
        {
            name = "Mark",
            surname = "Smith",
            address = "2 Cornelia St",
            phone = "1234567890",
            email = $"john{Guid.NewGuid()}@gmail.com",
            password = "Pass12345"
        };

        var response = await _client.PostAsJsonAsync("/auth/signup", signupUser);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("User created successfully.");
    }

    [Fact]
    public async Task SignUp_ReturnsError_EmailAlreadyExists()
    {
        var existingUser = new
        {
            name = "Mark",
            surname = "Smith",
            address = "2 Cornelia St",
            phone = "1234567890",
            email = "test@gmail.com", //This email exists already
            password = "Pass12345"
        };

        var response = await _client.PostAsJsonAsync("/auth/signup", existingUser);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        content.GetProperty("message").GetString().Should().Be("Email is already in use.");
    }

    [Fact]
    public async Task Login_ReturnsToken_SuccessfulScenario()
    {
        var loginUser = new
        {
            email = "test@gmail.com",
            password = "123456789"
        };

        var response = await _client.PostAsJsonAsync("/auth/login", loginUser);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var token = content.GetProperty("token").GetString();
        token.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task Login_ReturnsUnauthorized_UnsuccessfulScenario()
    {
        var loginUser = new
        {
            email = "test@gmail.com",
            password = "WrongPassword"
        };

        var response = await _client.PostAsJsonAsync("/auth/login", loginUser);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        content.GetProperty("message").GetString().Should().Be("Invalid credentials.");
    }
}