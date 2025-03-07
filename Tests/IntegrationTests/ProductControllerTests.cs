using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using BackEnd.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Dynamic;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.BusinessLogic;
using BackEnd.Controllers;

public class ProductControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProductsByCategory_ReturnsOk()
    {
        var response = await _client.GetAsync("/products/beverages");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
        content.Should().NotBeNull();
        content.Should().HaveCountGreaterThan(0);
        content.All(product => product.category == "beverages").Should().BeTrue();
    }

    [Fact]
    public async Task GetProductsByCategory_NotFound()
    {
        var response = await _client.GetAsync("/products/wrong-category"); //This category does not exist
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("No products found for category: wrong-category");
    }

    [Fact]
    public async Task GetProductBySlug_ReturnsOk()
    {
        var response = await _client.GetAsync("/products/capsules/nespresso-double-espresso-chiaro-10"); //This product exists in the database
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Product>();
        content.Should().NotBeNull();
        content.category.Should().Be("capsules");
        content.slug.Should().Be("nespresso-double-espresso-chiaro-10");
    }

    [Fact]
    public async Task GetProductBySlug_BadRequest()
    {
        var response = await _client.GetAsync("/products/capsules/wrong-product-slug"); //Product does not exist
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadAsStringAsync();
        content.Should().Be("Invalid product data");
    }

    [Fact]
    public async Task GetProductById_ReturnsOk()
    {
        var response = await _client.GetAsync("/products/product/1");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<Product>();
        content.Should().NotBeNull();
        content.id.Should().Be(1);
    }

    [Fact]
    public async Task GetProductById_NotFound()
    {
        var response = await _client.GetAsync("/products/product/9999"); //The product with this id does not exist
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("No product found with ID: 9999");
    }

    [Fact]
    public async Task GetAllProducts_ReturnsOk()
    {
        var response = await _client.GetAsync("/products");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
        content.Should().NotBeNull();
        content.Should().HaveCountGreaterThan(0);
    }
}