﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OrderManagement.Api.BackgroundServices
{
  public class UpdateChannel
  {
    private const int MAX_QUEUE_LENGTH = 5;

    private readonly Channel<Guid> channel;
    private readonly ILogger<UpdateChannel> logger;

    public UpdateChannel(ILogger<UpdateChannel> logger)
    {
      var options = new BoundedChannelOptions(MAX_QUEUE_LENGTH)
      {
        SingleWriter = false,
        SingleReader = true
      };
      this.channel = Channel.CreateBounded<Guid>(options);
      this.logger = logger;
    }

    public async Task<bool> AddUpdateTaskAsync(Guid customerId,
                                               CancellationToken cancellationToken = default)
    {

    }

    public IAsyncEnumerable<Guid> ReadAllAsync(CancellationToken cancellationToken = default)
    {

    }

    public bool TryCompleteWriter(Exception ex = null) => channel.Writer.TryComplete(ex);
  }
}
