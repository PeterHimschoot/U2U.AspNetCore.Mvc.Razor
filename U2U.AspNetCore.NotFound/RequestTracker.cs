using System;
using System.Collections.Generic;
using System.Linq;

namespace U2U.AspNetCore.NotFound
{
  public class RequestTracker
  {
    private INotFoundRepository repo;
    private static object locker = new object();

    public RequestTracker(INotFoundRepository repo)
    {
      if (repo == null)
      {
        throw new ArgumentNullException(nameof(repo));
      }
      this.repo = repo;
    }

    public void Record(string url)
    {
      lock (locker)
      {
        var request = this.repo.NotFoundRequests.SingleOrDefault(r => r.Path == url);
        if (request != null)
        {
          request.IncrementCount();
        }
        else
        {
          request = new NotFoundRequest(url);
          request.IncrementCount();
          this.repo.AddNotFoundRequest(request);
        }
      }
    }

    public IEnumerable<NotFoundRequest> NotFoundRequests
  => repo.NotFoundRequests;

    public NotFoundRequest GetRequest(string path)
      => this.repo.GetRequest(path);

    public void UpdateRequest(NotFoundRequest notFoundRequest)
    {
      this.repo.UpdateNotFoundRequest(notFoundRequest);
    }
  }
}