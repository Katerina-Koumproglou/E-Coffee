// using Xunit;
// using Microsoft.AspNetCore.Mvc.Testing;
// using BackEnd.Models;
// using FluentAssertions;
// using System.Net;
// using System.Net.Http.Json;
// using System.Dynamic;
// using System.Text.Json;
// using System.Threading.Tasks;
// using System;
// using Microsoft.EntityFrameworkCore;
// using BackEnd.Data;
// using BackEnd.BusinessLogic;
// using BackEnd.Controllers;

// public class ProductControllerTests : IClassFixture<WebApplicationFactory<Program>>
// {
//     private readonly HttpClient _client;

//     public ProductControllerTests(WebApplicationFactory<Program> factory)
//     {
//         _client = factory.CreateClient();
//     }

//     private ProductController GetProduct_InMemoryDb()
//     {
//         var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "InMemoryEcoffeeDb").Options;

//         var context = new ApplicationDbContext(options);
//         context.Products.AddRange(new List<Product>{
//             new Product { name = "Test Product", category = "Test Category", slug = "test-product"}
//         });
//         context.SaveChanges();

//         var productService = new ProductService(context);
//         return new ProductController(productService);

//     }

//     [Fact]
//     public async Task TestProductController()
//     {
//         var controller = GetProduct_InMemoryDb();
//     }
// }