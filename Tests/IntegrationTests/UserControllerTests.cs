using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using BackEnd.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public UserControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
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
        var response = await _client.GetAsync("/users/1");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<User>();
        content.Should().NotBeNull();
        content.ID.Should().Be(1);
    }

    [Fact]
    public async Task GetUserById_ReturnsNotFound_UserDoesNotExist()
    {
        var response = await _client.GetAsync("/users/900"); //The user with this id does not exist
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

        var response = await _client.PatchAsJsonAsync("/users/1", updatedUser);
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

        var response = await _client.PatchAsJsonAsync("/users/900", updatedUser); //The user with this id does not exist
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

        var response = await _client.PatchAsJsonAsync("/users/1", updatedUser);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<JsonElement>();
        content.GetProperty("message").GetString().Should().Be("Email exists already.");
    }
}