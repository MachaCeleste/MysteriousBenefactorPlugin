using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace MysteriousBenefactorPlugin;

[BepInPlugin("com.machaceleste.mysteriousbenefactorplugin", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    public static ConfigEntry<int> initIncome;

    private void Awake()
    {
        initIncome = Config.Bind("Main", "Initial Income", 0, new ConfigDescription("Sets how much money your mysterious benifactor deposits when you first make a bank account, setting to 0 disables mod", new AcceptableValueRange<int>(0, 30000)));

        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony("com.machaceleste.mysteriousbenefactorplugin");
        harmony.PatchAll();
    }
}