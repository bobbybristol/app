﻿namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void process(IProvideDetailsToCommands request);
    bool can_process(IProvideDetailsToCommands request);
  }
}