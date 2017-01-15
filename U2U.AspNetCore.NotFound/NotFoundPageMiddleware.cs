using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using U2U.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace U2U.AspNetCore.NotFound
{
  public class NotFoundPageMiddleware
  {
    private RequestTracker tracker;

    public NotFoundPageMiddleware(RequestDelegate next, RequestTracker tracker)
    {
      this.tracker = tracker ?? throw new ArgumentNullException(nameof(tracker));
    }

    public async Task Invoke(HttpContext context)
    {
      //var keys = context.Request.Query.Keys;
      //if (keys.Contains(pathKey) && keys.Contains(fixedPathKey))
      //{
      //  var notFoundRequest = tracker.GetRequest(context.Request.Query[pathKey]);
      //  notFoundRequest.SetCorrectedPath(context.Request.Query[fixedPathKey]);
      //  tracker.UpdateRequest(notFoundRequest);
      //}
      var model = tracker.NotFoundRequests.OrderByDescending(r => r.Hits).ToList();
      await context.RenderAsync("~/Views/Shared/NotFound.cshtml", model);
    }
  }
}
