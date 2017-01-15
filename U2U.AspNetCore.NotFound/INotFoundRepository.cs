using System;
using System.Collections.Generic;
using System.Text;

namespace U2U.AspNetCore.NotFound
{
  public interface INotFoundRepository
  {
    NotFoundRequest GetRequest(string path);

    void AddNotFoundRequest(NotFoundRequest request);

    void UpdateNotFoundRequest(NotFoundRequest request);

    IEnumerable<NotFoundRequest> NotFoundRequests { get; }
  }
}
