using Lockstep.Web.Config;
using Lockstep.Web.Hubs;
using Lockstep.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly SiteConfig _siteConfig;
        private readonly IMediator _mediator;
        private readonly IHubContext<ChatHub> _hub;
        private readonly IHubContext<NotificationsHub> _hubNotify;

        public HomeController(ILogger<HomeController> logger,
            IHttpClientFactory httpClientFactory,
            IOptions<SiteConfig> options, IConfiguration config,
            IMediator mediator,
            IHubContext<ChatHub> hub,
            IHubContext<NotificationsHub> hubNotify
            )
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
            _siteConfig = options.Value;
            _mediator = mediator;
            _hub = hub;
            _hubNotify = hubNotify;
        }

        public async Task<IActionResult> Index()
        {
             await _hub.Clients.All.SendAsync("ReceiveMessage", "site", "hello");
            await _hubNotify.Clients.All.SendAsync("Send", "Notification");
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", "site", "hello");
            return View();
        }



        private async Task<string> GetAsync(string url, Dictionary<string, string> @params, CancellationToken cancellationToken)
        {
            var client = httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromMinutes(1);
            client.BaseAddress = new Uri(url);
            var httpsResponse = await client.GetAsync(url, cancellationToken);
            if (httpsResponse.IsSuccessStatusCode)
            {
                var content = await httpsResponse.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                return string.Empty;
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
