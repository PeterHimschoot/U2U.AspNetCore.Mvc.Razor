using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using U2U.AspNetCore.NotFound;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class NotFoundExtensions
  {
    public static IServiceCollection AddNotFoundSqlServerDb(
      this IServiceCollection services)
    => services.AddScoped<INotFoundRepository, NotFoundRepository>();

    public static IServiceCollection AddNotFound(this IServiceCollection services)
    => services
      .AddScoped<NotFoundPageMiddleware>()
      .AddScoped<RequestTracker>();

    //public static IApplicationBuilder UseNotFound(
    //  this IApplicationBuilder builder,
    //  NotFoundOptions options)
    //=> builder.UseMiddleware<NotFoundMiddleware>(options);

    //public static IApplicationBuilder UseNotFound(this IApplicationBuilder builder)
    //=> builder.UseNotFound(new NotFoundOptions
    //{
    //  Behavior = NotFoundOptions.FixPathBehavior.UrlRewrite
    //});

    //public static IApplicationBuilder UseNotFoundPage(
    //  this IApplicationBuilder builder,
    //  NotFoundPageOptions options)
    //=> builder.UseMiddleware<NotFoundPageMiddleware>(options);

    public static IApplicationBuilder UseNotFoundPage(this IApplicationBuilder builder)
      => builder.UseMiddleware<NotFoundPageMiddleware>();
    //  => builder.Map("/fix404s", b => b.UseMiddleware<NotFoundPageMiddleware>());

    // => builder.UseNotFoundPage(new NotFoundPageOptions { Path = "/fix404s" });
  }
}
