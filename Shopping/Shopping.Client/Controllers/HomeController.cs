﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Common;
using Shopping.Client.Models;

namespace Shopping.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpClient = httpClientFactory.CreateClient(Constants.SHOPPING_API_CLIENT_NAME);
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("/api/v2/products");
        var content = await response.Content.ReadAsStringAsync();
        var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

        return View(productList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

