using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U2U.AspNetCore.NotFound
{
  public class NotFoundRepository : INotFoundRepository
  {
    private NotFoundDbContext context;

    public NotFoundRepository(NotFoundDbContext context)
    {
      this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<NotFoundRequest> NotFoundRequests
      => context.NotFoundRequests.AsEnumerable();

    public void AddNotFoundRequest(NotFoundRequest request)
    {
      this.context.NotFoundRequests.Add(request);
      this.context.SaveChanges();
    }

    public NotFoundRequest GetRequest(string path)
    {
      return context.NotFoundRequests.ToList().FirstOrDefault(r => r.Path == path);
    }

    public void UpdateNotFoundRequest(NotFoundRequest request)
    {
      this.context.Entry(request).State = EntityState.Modified;
      this.context.SaveChanges();
    }
  }
}
