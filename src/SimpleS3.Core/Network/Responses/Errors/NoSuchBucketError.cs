﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace Genbox.SimpleS3.Core.Network.Responses.Errors
{
    [PublicAPI]
    public class NoSuchBucketError : GenericError
    {
        internal NoSuchBucketError(IDictionary<string, string> lookup) : base(lookup)
        {
            BucketName = lookup["BucketName"];
        }

        public string BucketName { get; }

        public override string GetErrorDetails()
        {
            return $"BucketName: {BucketName}";
        }
    }
}