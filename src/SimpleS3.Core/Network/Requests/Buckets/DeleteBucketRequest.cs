﻿using Genbox.SimpleS3.Core.Abstracts.Enums;
using Genbox.SimpleS3.Core.Network.Requests.Interfaces;

namespace Genbox.SimpleS3.Core.Network.Requests.Buckets
{
    /// <summary>
    /// Deletes a bucket. All objects (including all object versions and delete markers) in the bucket must be deleted before the bucket itself can
    /// be deleted.
    /// </summary>
    public class DeleteBucketRequest : BaseRequest, IHasBucketName
    {
        public DeleteBucketRequest(string bucketName) : base(HttpMethod.DELETE)
        {
            BucketName = bucketName;
        }

        public string BucketName { get; set; }
    }
}