﻿using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Genbox.SimpleS3.Core.Common;

namespace Genbox.SimpleS3.Core.Tests.Code.Other
{
    /// <summary>HTTP handler that fails with non transient HTTP errors after N requests</summary>
    internal class NonTransientFailingHttpHandler : BaseFailingHttpHandler
    {
        private readonly int _afterNRequests;

        public NonTransientFailingHttpHandler(int afterNRequests)
        {
            Validator.RequireThat(afterNRequests >= 1, nameof(afterNRequests), "afterNRequests must be greater than or equal 1");

            _afterNRequests = afterNRequests;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (++RequestCounter > _afterNRequests)
            {
                // Blow up with an non-transient HTTP response
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = GetEmptyXmlContent(),
                    RequestMessage = request
                };
            }

            await ConsumeRequestAsync(request).ConfigureAwait(false);

            return CreateResponse(request, HttpStatusCode.OK);
        }
    }
}