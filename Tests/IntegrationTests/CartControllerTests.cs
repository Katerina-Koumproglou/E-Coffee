using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using BackEnd.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

public class CartControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CartControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task AddToCart_ReturnsOk()
    {
        var userAddsProduct = new
        {
            userId = 46,
            productId = 6
        };
        await _client.PostAsJsonAsync("api/cart/remove", userAddsProduct);

        var response = await _client.PostAsJsonAsync("api/cart/add", userAddsProduct);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("Product added to cart successfully.");
    }

    [Fact]
    public async Task AddToCart_BadRequest()
    {
        var userAddsNonexistentProduct = new
        {
            userId = 46,
            productId = 999
        };

        var response = await _client.PostAsJsonAsync("api/cart/add", userAddsNonexistentProduct);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("Product was not added to cart.");
    }
}