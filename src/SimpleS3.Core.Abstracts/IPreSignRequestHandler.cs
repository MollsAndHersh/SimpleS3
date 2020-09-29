﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Genbox.SimpleS3.Core.Abstracts
{
    public interface IPreSignRequestHandler
    {
        Task<string> SignRequestAsync<TReq>(TReq request, TimeSpan expiresIn, CancellationToken cancellationToken = default) where TReq : IRequest;
    }
}