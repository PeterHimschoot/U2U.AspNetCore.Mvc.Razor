## U2U.AspNetCore.Mvc.Razor

Use razor to generate files outside of the normal MVC Controller/View chain, for example in your middleware, or for sending dynamic email messages.

All you need is a `HttpContext`.

# To generate contexts from Razor as a string

Start by creating a viewModel instance. The ViewModel is used to pass data to the Razor file, ViewData or ViewBag is not supported. 

Create a Razor file, using the ViewModel's class as the `@model`:

```Razor
@model TestRazor.Models.RazorViewModel

Your message: @Model.Message
```


Then call the `RenderToStringAsync` method (which is an extension method on `HttpContext`) passing the path to the razor file and the viewmodel. You will get the result back as a string.

```CSharp
var viewModel = new RazorViewModel { Message = "Generated from razor!" };
var contents = await HttpContext.RenderToStringAsync("~/Views/Home/Razor.cshtml", viewModel);
```

# To generate Razor contents to the response stream

Start by creating a viewModel instance. The ViewModel is used to pass data to the Razor file, ViewData or ViewBag is not supported. 

Create a Razor file, using the ViewModel's class as the `@model`:

```Razor
@model IEnumerable<U2U.AspNetCore.NotFound.NotFoundRequest>

<!DOCTYPE html>
<html>
<body>
  <h1>Fix 404s</h1>
  <table>
    <thead id="requestHeader">
      <tr>
        <th class="path">Path</th>
        <th>404 Count</th>
        <th>Corrected Path</th>
      </tr>
    </thead>
    <tbody>
      @foreach (var request in Model)
      {
        <tr class="requestRow">
          <td>@request.Path</td>
          <td>@request.Hits</td>"
          @if (!String.IsNullOrEmpty(request.FixedPath))
          {
          <td>@request.FixedPath</td>
          }
          else
          {
          <td>
            <input type="text" />
            <a href='@string.Format("?path={0}&fixedPath=", request.Path)' class="fixLink">Save</a>
          </td>
          }
        </tr>
        }
      </tbody>
    </table>
  </body>
</html>
```

Then call the `RenderToStringAsync` method  (which is an extension method on `HttpContext`) passing the path to the razor file and the viewmodel. The resulting razor content is written to the result stream.

```CSharp
var viewModel = tracker.NotFoundRequests.OrderByDescending(r => r.Hits).ToList();
await context.RenderAsync("~/Views/Shared/NotFound.cshtml", viewModel);
```

#Sources

Sources of this package are available on github repository <https://github.com/PeterHimschoot/U2U.AspNetCore.Mvc.Razor>

Any bugs, remarks, etc... can always be sent to <peter@u2u.be>





