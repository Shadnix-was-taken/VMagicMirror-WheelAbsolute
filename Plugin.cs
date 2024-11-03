using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace WheelAbsolute
{
    [BepInPlugin("de.shadnix.vmagicmirror.wheelabsolute", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("VMagicMirror.exe")]
    public class Plugin : BaseUnityPlugin
    {
        internal static bool harmonyPatchesLoaded = false;
        internal static Harmony harmonyInstance = new Harmony("de.shadnix.vmagicmirror.wheelabsolute");
        internal static ManualLogSource logSource;

        private void Awake()
        {
            // Plugin startup logic
            logSource = base.Logger;
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
