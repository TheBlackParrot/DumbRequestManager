﻿using System.IO;
using DumbRequestManager.Configuration;
using DumbRequestManager.Installers;
using IPA;
using IPA.Config.Stores;
using IPA.Loader;
using IPA.Utilities;
using JetBrains.Annotations;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using IPAConfig = IPA.Config.Config;

namespace DumbRequestManager;

[Plugin(RuntimeOptions.SingleStartInit)]
[NoEnableDisable]
[UsedImplicitly]
internal class Plugin
{
    internal static IPALogger Log { get; private set; } = null!;
    internal static readonly string UserDataDir = Path.Combine(UnityGame.UserDataPath, "DumbRequestManager");
    internal static Hive.Versioning.Version PluginVersion = null!;

    [Init]
    public Plugin(IPALogger ipaLogger, IPAConfig ipaConfig, Zenjector zenjector, PluginMetadata metadata)
    {
        if (!Directory.Exists(UserDataDir))
        {
            Directory.CreateDirectory(UserDataDir);
        }
        
        Log = ipaLogger;
        zenjector.UseLogger(Log);
        
        PluginConfig c = ipaConfig.Generated<PluginConfig>();
        PluginConfig.Instance = c;

        PluginVersion = metadata.HVersion;

        zenjector.UseHttpService();
        zenjector.Install<AppInstaller>(Location.App);
        zenjector.Install<MenuInstaller>(Location.Menu);
        zenjector.Install<PlayerInstaller>(Location.Player);
        
        Log.Info("Plugin loaded");
    }

    public static void DebugMessage(string message)
    {
#if DEBUG
        Log.Info(message);
#endif
    }
}