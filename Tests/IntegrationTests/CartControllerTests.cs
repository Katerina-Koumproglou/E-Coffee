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
            userId = 45,
            productId = 3,
            quantity = 1
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
            productId = 999, //Product does not exist
            quantity = 1
        };

        var response = await _client.PostAsJsonAsync("api/cart/add", userAddsNonexistentProduct);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("Product was not added to cart.");
    }

    [Fact]
    public async Task RemoveFromCart_ReturnsOk()
    {
        var userHasProduct = new
        {
            userId = 46,
            productId = 4,
            quantity = 1
        };

        await _client.PostAsJsonAsync("api/cart/add", userHasProduct);

        var response = await _client.SendAsync(new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri("api/cart/remove", UriKind.Relative),
            Content = JsonContent.Create(userHasProduct)
        });

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("Product removed from cart successfully.");
    }

    [Fact]
    public async Task RemoveFromCart_NotFound()
    {
        var request = new
        {
            userId = 45,
            productId = 999, //Product does not exist
            quantity = 1
        };

        var response = await _client.SendAsync(new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri("api/cart/remove", UriKind.Relative),
            Content = JsonContent.Create(request)
        });

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("Product was not removed from cart.");
    }

    [Fact]
    public async Task GetCartProducts_ReturnsOk()
    {
        var userId = 45;
        var response = await _client.GetAsync($"api/cart/{userId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<List<object>>();
        content.Should().NotBeNull();
        content.Should().BeOfType<List<object>>();
    }

    [Fact]
    public async Task GetCartWithQuantities_ReturnsOk()
    {
        var userId = 45;
        var response = await _client.GetAsync($"api/cart/quantities/{userId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<List<object>>();
        content.Should().NotBeNull();
        content.Should().BeOfType<List<object>>();
    }

    [Fact]
    public async Task GetCartWithQuantities_NotFound()
    {
        var userId = 999; //This user does not exist
        var response = await _client.GetAsync($"api/cart/quantities/{userId}");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("No items found in the cart.");
    }

    [Fact]
    public async Task ModifyCartQuantities_ReturnsOk()
    {
        var request = new
        {
            userId = 45,
            productId = 3,
            quantity = 1
        };

        var response = await _client.PostAsJsonAsync($"api/cart/quantities/modification", request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("Cart updated successfully.");
    }

    [Fact]
    public async Task ModifyCartQuantities_NotFound()
    {
        var request = new
        {
            userId = 999, //User and product do not exist
            productId = 999,
            quantity = 1
        };

        var response = await _client.PostAsJsonAsync($"api/cart/quantities/modification", request);
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        content["message"].ToString().Should().Be("Product not found in cart.");
    }
}