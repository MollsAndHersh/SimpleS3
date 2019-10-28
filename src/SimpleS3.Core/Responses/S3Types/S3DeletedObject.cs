﻿namespace Genbox.SimpleS3.Core.Responses.S3Types
{
    public class S3DeletedObject
    {
        public string ObjectKey { get; set; }
        public string VersionId { get; set; }
        public bool DeleteMarker { get; set; }
        public string DeleteMarkerVersionId { get; set; }

        public override string ToString()
        {
            return ObjectKey;
        }
    }
}