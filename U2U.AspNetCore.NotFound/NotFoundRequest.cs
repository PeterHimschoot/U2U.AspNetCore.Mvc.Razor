using System;
using System.Collections.Generic;
using System.Text;

namespace U2U.AspNetCore.NotFound
{
  public class NotFoundRequest
  {
    public int Id { get; set; }

    public string Path { get; set; }

    public string FixedPath { get; set; }

    public int Hits { get; set; }

    public NotFoundRequest() { }

    public NotFoundRequest(string path)
    {
      this.Path = path;
    }
    public void IncrementCount()
    {
      Hits += 1;
    }

    internal void SetCorrectedPath(string fixedPath)
    {
      this.FixedPath = fixedPath;
    }
  }
}
