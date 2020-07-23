using FuneralClientV2.Utils;
using FuneralClientV2.Wrappers;
using Harmony;
using Il2CppSystem.Runtime.Remoting.Messaging;
using Il2CppSystem.Security.Cryptography;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnityEngine;
using VRC;
using VRC.UI;
using VRCSDK2;
using static VRC.SDKBase.VRC_EventHandler;

namespace FuneralClientV2.Patching
{
    public static class PatchManager
    {
        private static HarmonyMethod GetLocalPatch(string name) { return new HarmonyMethod(typeof(PatchManager).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic)); }

        private static List<Patch> RetrievePatches()
        {
            List<Patch> patches = new List<Patch>()
            {
                new Patch("WorldTriggers", AccessTools.Method(typeof(VRC_EventHandler), "InternalTriggerEvent", null, null), GetLocalPatch("TriggerEvent"), null),
                new Patch("HWIDSpoofer", typeof(VRC.Core.API).GetMethod("get_DeviceID"), GetLocalPatch("SpoofDeviceID"), null),
                new Patch("AntiKick", typeof(ModerationManager).GetMethod("KickUserRPC"), GetLocalPatch("AntiKick"), null),
                //new Patch("AntiBlock", typeof(ModerationManager).GetMethod("BlockStateChangeRPC"), GetLocalPatch("AntiBlock"), null),
                new Patch("ForceClone", typeof(UserInteractMenu).GetMethod("Update"), GetLocalPatch("CloneAvatarPrefix"), null),
                new Patch("EmoteMenuFix", typeof(VRCUiCurrentRoom).GetMethod("Method_Private_Void_17"), GetLocalPatch("NonExistentPrefix"), null) //stupid fix to fix emote menu not working :(
            };
            return patches;
        }

        public static void ApplyPatches()
        {
            var patches = RetrievePatches();
            foreach (var patch in patches) patch.ApplyPatch();
            ConsoleUtil.Info("All Patches have been applied successfully.");
        }

        #region Patches
        private static bool TriggerEvent(ref VrcEvent __0, ref VrcBroadcastType __1, ref int __2, ref float __3)
        {
            if (__1 == VrcBroadcastType.Always || __1 == VrcBroadcastType.AlwaysUnbuffered) if (!GeneralUtils.WorldTriggers) return false;
            if (GeneralUtils.WorldTriggers) __1 = VrcBroadcastType.Always;
            return true;
        }

        private static bool SpoofDeviceID(ref string __result)
        {
            __result = GeneralUtils.RandomString(50);
            ConsoleUtil.Info($"[HWID Spoofer] New HWID: {__result}");
            return true;
        }

        private static bool AntiKick(ref string __0, ref string __1, ref string __2, ref string __3, ref Player __4)
        {
            //to-do; add support for moderation logging
            return !GeneralUtils.AntiKick;
        }

        private static bool AntiBlock(ref string __0, ref bool __1, ref Player __2)
        {
            //to-do; add support for moderation logging
            var us = GeneralWrappers.GetPlayerManager().GetPlayer(__0);
            var them = __2.GetAPIUser();
            if (__1 && us.GetAPIUser().id == PlayerWrappers.GetCurrentPlayer().GetVRC_Player().GetAPIUser().id && GeneralUtils.AntiBlock) return false;
            else return true;
        }

        private static void NonExistentPrefix() { }

        private static bool CloneAvatarPrefix(ref UserInteractMenu __instance)
        {
            bool result = true;
            if (__instance.menuController.activeAvatar.releaseStatus != "private")
            {
                bool flag2 = !__instance.menuController.activeUser.allowAvatarCopying;
                if (flag2)
                {
                    __instance.cloneAvatarButton.gameObject.SetActive(true);
                    __instance.cloneAvatarButton.interactable = true;
                    __instance.cloneAvatarButtonText.color = new Color(0.8117647f, 0f, 0f, 1f);
                    result = false;
                }
                else
                {
                    __instance.cloneAvatarButton.gameObject.SetActive(true);
                    __instance.cloneAvatarButton.interactable = true;
                    __instance.cloneAvatarButtonText.color = new Color(0.470588237f, 0f, 0.8117647f, 1f);
                    result = false;
                }
            }
            return result;
        }
        #endregion
    }
}
