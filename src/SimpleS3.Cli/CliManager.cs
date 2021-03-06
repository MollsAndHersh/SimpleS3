﻿using Genbox.SimpleS3.Abstracts;
using Genbox.SimpleS3.Cli.Core.Managers;
using Genbox.SimpleS3.Core;
using Genbox.SimpleS3.Core.Abstracts.Enums;
using Genbox.SimpleS3.Extensions;
using Genbox.SimpleS3.Extensions.ProfileManager.Abstracts;
using Genbox.SimpleS3.Extensions.ProfileManager.Extensions;
using Genbox.SimpleS3.Extensions.ProfileManager.Setup;
using Microsoft.Extensions.DependencyInjection;

namespace Genbox.SimpleS3.Cli
{
    public class CliManager
    {
        private static CliManager _cliManager;

        private CliManager(string profileName, AwsRegion region)
        {
            ServiceCollection services = new ServiceCollection();
            IS3ClientBuilder builder = services.AddSimpleS3();

            builder.CoreBuilder.UseProfileManager()
                               .UseDataProtection();

            //Override the region if it is set via commandline
            builder.Services.PostConfigure<S3Config>(config =>
            {
                if (region != AwsRegion.Unknown)
                    config.Region = region;
            });

            services.AddSingleton<BucketManager>();
            services.AddSingleton<ObjectManager>();

            ServiceProvider provider = services.BuildServiceProvider();
            ProfileManager = provider.GetRequiredService<IProfileManager>();

            IProfile profile = ProfileManager.GetProfile(profileName) ?? ConsoleSetup.SetupProfile(ProfileManager, profileName);

            S3Client = provider.GetRequiredService<IClient>();
            BucketManager = provider.GetRequiredService<BucketManager>();
            ObjectManager = provider.GetRequiredService<ObjectManager>();
        }

        private IClient S3Client { get; }
        public BucketManager BucketManager { get; }
        public ObjectManager ObjectManager { get; }
        public IProfileManager ProfileManager { get; }

        public static CliManager GetCliManager(string? profile, AwsRegion region)
        {
            return _cliManager ??= new CliManager(profile ?? Extensions.ProfileManager.ProfileManager.DefaultProfile, region);
        }
    }
}