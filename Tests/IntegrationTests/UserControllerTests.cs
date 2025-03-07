using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using BackEnd.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public UserControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        AuthenticateClient().Wait();
    }

    private async Task AuthenticateClient()
    {
        var loginRequest = new
        {
            email = "admin@email.com",
            password = "AdminPassword"
        };
        var response = await _client.PostAsJsonAsync("/auth/login", loginRequest);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        var token = content.GetProperty("token").GetString();

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    [Fact]
    public async Task GetUsers_ReturnsOk()
    {
        var response = await _client.GetAsync("/users");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
        content.Should().NotBeNull();
    }

    [Fact]
    public async Task GetUserById_ReturnsUser_Sucessful()
    {
        var response = await _client.GetAsync("/users/45");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<User>();
        content.Should().NotBeNull();
        content.ID.Should().Be(45);
    }

    [Fact]
    public async Task GetUserById_ReturnsNotFound_UserDoesNotExist()
    {
        var response = await _client.GetAsync("/users/9999"); //The user with this id does not exist
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        content.GetProperty("message").GetString().Should().Be("User not found.");
    }

    [Fact]
    public async Task UpdateUser_ReturnsOk()
    {
        var updatedUser = new User
        {
            name = "New name",
            surname = "New surname",
            phone = "1234567890",
            address = "New address",
            email = "newemail@gmail.com",
            password = "New password"
        };

        var response = await _client.PatchAsJsonAsync("/users/47", updatedUser);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        content.GetProperty("message").GetString().Should().Be("User updated successfully.");
    }

    [Fact]
    public async Task UpdateUser_ReturnsNotFound_UserDoesNotExist()
    {
        var updatedUser = new User
        {
            name = "New name",
            surname = "New surname",
            phone = "1234567890",
            address = "New address",
            email = "newemail@gmail.com",
            password = "New password"
        };

        var response = await _client.PatchAsJsonAsync("/users/9999", updatedUser); //The user with this id does not exist
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        content.GetProperty("message").GetString().Should().Be("User not found.");
    }

    [Fact]
    public async Task UpdateUser_ReturnsBadRequest_EmailAlreadyExists()
    {
        var updatedUser = new User
        {
            name = "New name",
            surname = "New surname",
            phone = "1234567890",
            address = "New address",
            email = "test@gmail.com", //This email already exists
            password = "New password"
        };

        var response = await _client.PatchAsJsonAsync("/users/47", updatedUser);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        content.GetProperty("message").GetString().Should().Be("Email exists already.");
    }
}