﻿using Genbox.SimpleS3.Core.Abstracts.Enums;

namespace Genbox.SimpleS3.Core.Network.Requests
{
    public abstract class SignedBaseRequest : BaseRequest
    {
        protected SignedBaseRequest(HttpMethod method, string url) : base(method)
        {
            Url = url;
        }

        public string Url { get; }
    }
}