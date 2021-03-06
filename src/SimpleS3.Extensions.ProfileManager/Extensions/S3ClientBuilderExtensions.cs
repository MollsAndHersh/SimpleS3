﻿using System;
using Genbox.SimpleS3.Core.Abstracts;
using Genbox.SimpleS3.Extensions.ProfileManager.Abstracts;
using Genbox.SimpleS3.Extensions.ProfileManager.Serializers;
using Genbox.SimpleS3.Extensions.ProfileManager.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Genbox.SimpleS3.Extensions.ProfileManager.Extensions
{
    public static class S3ClientBuilderExtensions
    {
        /// <summary>Adds a profile manager that is configured to use the disk for storage and JSON for serialization</summary>
        public static IProfileManagerBuilder UseProfileManager(this ICoreBuilder builder, Action<DiskStorageOptions>? config = null)
        {
            builder.Services.AddSingleton<IProfileManager, ProfileManager>();
            builder.Services.AddSingleton<IStorage, DiskStorage>();
            builder.Services.AddSingleton<IProfileSerializer, JsonProfileSerializer>();

            if (config != null)
                builder.Services.Configure(config);

            ProfileManagerBuilder managerBuilder = new ProfileManagerBuilder(builder.Services);
            return managerBuilder;
        }
    }
}