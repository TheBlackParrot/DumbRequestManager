﻿using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using JetBrains.Annotations;

// ReSharper disable RedundantDefaultMemberInitializer

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace DumbRequestManager.Configuration;

[UsedImplicitly]
internal class PluginConfig
{
    public static PluginConfig Instance { get; set; } = null!;
    
    public virtual string HttpAddress { get; set; } = "localhost";
    public virtual int HttpPort { get; set; } = 13337;
    
    public virtual string WebSocketAddress { get; set; } = "localhost";
    public virtual int WebSocketPort { get; set; } = 13338;
    
    public virtual string WebHookUrl { get; set; } = string.Empty;
    
    public virtual bool PlayAudioPreviews { get; set; } = true;
    public virtual bool PlayRemoteAudioPreviews { get; set; } = false;
    public virtual bool NeverUseLocalCoverImages { get; set; } = true;
    
    public virtual int MapDownloadTimeout { get; set; } = 300;
    public virtual bool ShowRequestersInsteadOfMappers { get; set; } = false;
    
    public virtual string ProtobufCacheURL { get; set; } = "https://theblackparrot.me/DumbRequestManager/cache.proto.gz";
}