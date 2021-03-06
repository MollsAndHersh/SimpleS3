﻿using System;
using Genbox.HttpBuilders;
using Genbox.SimpleS3.Core.Abstracts.Enums;
using Genbox.SimpleS3.Core.Builders;
using Genbox.SimpleS3.Core.Enums;
using Genbox.SimpleS3.Core.Network.Requests.Interfaces;

namespace Genbox.SimpleS3.Core.Network.Requests.Objects
{
    /// <summary>
    /// Creates a copy of an object that is already stored in Amazon S3. When copying an object, you can preserve all metadata (default) or specify
    /// new metadata. However, the ACL is not preserved and is set to private for the user making the request. To override the default ACL setting, specify a
    /// new ACL when generating a copy request.
    /// </summary>
    public class CopyObjectRequest : BaseRequest, IHasObjectAcl, IHasCache, IHasMetadata, IHasTags, IHasLock, IHasSse, IHasSseCustomerKey, IHasStorageClass, IHasRequestPayer, IHasWebsiteRedirect, IHasVersionId, IHasBucketName, IHasObjectKey, IHasLegalHold
    {
        internal CopyObjectRequest() : base(HttpMethod.PUT)
        {
            MetadataDirective = MetadataDirective.Copy;
            TaggingDirective = TaggingDirective.Copy;

            AclGrantRead = new AclBuilder();
            AclGrantReadAcp = new AclBuilder();
            AclGrantWriteAcp = new AclBuilder();
            AclGrantFullControl = new AclBuilder();
            IfETagNotMatch = new ETagBuilder();
            IfETagMatch = new ETagBuilder();
            Metadata = new MetadataBuilder();
            Tags = new TagBuilder();
            SseContext = new KmsContextBuilder();
        }

        public CopyObjectRequest(string sourceBucketName, string sourceObjectKey, string destinationBucketName, string destinationObjectKey) : this()
        {
            SourceBucketName = sourceBucketName;
            SourceObjectKey = sourceObjectKey;
            DestinationBucketName = destinationBucketName;
            DestinationObjectKey = destinationObjectKey;
        }

        public string SourceBucketName { get; internal set; }
        public string SourceObjectKey { get; internal set; }
        public string DestinationBucketName { get; internal set; }
        public string DestinationObjectKey { get; internal set; }
        public MetadataDirective MetadataDirective { get; set; }
        public TaggingDirective TaggingDirective { get; set; }
        string IHasBucketName.BucketName { get => DestinationBucketName; set => throw new NotSupportedException(); }
        public DateTimeOffset? IfModifiedSince { get; set; }
        public DateTimeOffset? IfUnmodifiedSince { get; set; }
        public ETagBuilder IfETagMatch { get; }
        public ETagBuilder IfETagNotMatch { get; }
        public LockMode LockMode { get; set; }
        public DateTimeOffset? LockRetainUntil { get; set; }
        public bool? LockLegalHold { get; set; }
        public MetadataBuilder Metadata { get; }
        public ObjectCannedAcl Acl { get; set; }
        public AclBuilder AclGrantRead { get; }
        public AclBuilder AclGrantReadAcp { get; }
        public AclBuilder AclGrantWriteAcp { get; }
        public AclBuilder AclGrantFullControl { get; }
        string IHasObjectKey.ObjectKey { get => DestinationObjectKey; set => throw new NotSupportedException(); }
        public Payer RequestPayer { get; set; }
        public SseAlgorithm SseAlgorithm { get; set; }
        public string? SseKmsKeyId { get; set; }
        public KmsContextBuilder SseContext { get; set; }

        public void ClearSensitiveMaterial()
        {
            if (SseCustomerKey != null)
                Array.Clear(SseCustomerKey, 0, SseCustomerKey.Length);
        }

        public SseCustomerAlgorithm SseCustomerAlgorithm { get; set; }
        public byte[]? SseCustomerKey { get; set; }
        public byte[]? SseCustomerKeyMd5 { get; set; }
        public StorageClass StorageClass { get; set; }
        public TagBuilder Tags { get; }
        public string? VersionId { get; set; }
        public string? WebsiteRedirectLocation { get; set; }

        public override void Reset()
        {
            SourceBucketName = null!;
            SourceObjectKey = null!;
            DestinationBucketName = null!;
            DestinationObjectKey = null!;
            MetadataDirective = MetadataDirective.Unknown;
            TaggingDirective = TaggingDirective.Unknown;
            IfModifiedSince = null;
            IfUnmodifiedSince = null;
            IfETagMatch.Reset();
            IfETagNotMatch.Reset();
            LockMode = LockMode.Unknown;
            LockRetainUntil = null;
            LockLegalHold = null;
            Metadata.Reset();
            Acl = ObjectCannedAcl.Unknown;
            AclGrantRead.Reset();
            AclGrantReadAcp.Reset();
            AclGrantWriteAcp.Reset();
            AclGrantFullControl.Reset();
            RequestPayer = Payer.Unknown;
            SseAlgorithm = SseAlgorithm.Unknown;
            SseKmsKeyId = null;
            SseContext.Reset();
            SseCustomerAlgorithm = SseCustomerAlgorithm.Unknown;
            SseCustomerKey = null;
            SseCustomerKeyMd5 = null;
            StorageClass = StorageClass.Unknown;
            Tags.Reset();
            VersionId = null;
            WebsiteRedirectLocation = null;

            base.Reset();
        }
    }
}