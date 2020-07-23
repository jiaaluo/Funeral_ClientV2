using FuneralClientV2.Wrappers;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRCSDK2;

namespace FuneralClientV2.Utils
{
    public static class GeneralUtils
    {
        public static bool WorldTriggers = false;

        public static bool Flight = false;

        public static bool ESP = false;

        public static bool SpinBot = false;

        public static bool Headflipper = false;

        public static bool DeafenNonFriends = false;

        public static bool AntiKick = true;

        public static bool AntiBlock = false;

        public static bool AntiPublicBan = true;

        public static bool LogModerations = false;

        public static bool Optimization = false;

        public static bool ClearConsole = false;

        public static bool RainbowButtons = true;

        public static List<string> Deafened = new List<string>();

        public static Vector3 SavedGravity = Physics.gravity;

        public static List<QMButtonBase> Buttons = new List<QMButtonBase>();

        private static System.Random random = new System.Random();

        public static void InformHudText(Color color, string text)
        {
            VRCUiManager.prop_VRCUiManager_0.hudMessageText.color = color;
            VRCUiManager.prop_VRCUiManager_0.Method_Public_Void_String_0($"[FUNERAL V2] {text}");
        }

        public static void ToggleColliders(bool toggle)
        {
            Collider[] array = UnityEngine.Object.FindObjectsOfType<Collider>();
            Component component = PlayerWrappers.GetCurrentPlayer().GetComponents(Collider.Il2CppType).FirstOrDefault<Component>(); //Fix this later but im lazy ok

            for (int i = 0; i < array.Length; i++)
            {
                Collider collider = array[i];
                bool flag = collider.GetComponent<PlayerSelector>() != null || collider.GetComponent<VRC.SDKBase.VRC_Pickup>() != null || collider.GetComponent<QuickMenu>() != null || collider.GetComponent<VRC_Station>() != null || collider.GetComponent<VRC.SDKBase.VRC_AvatarPedestal>() != null;
                if (!flag && collider != component) collider.enabled = toggle;
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void ToggleUIButton(string Name, bool state)
        {
            QMToggleButton Button = null;
            foreach(var button in Buttons)
            {
                var button2 = (QMToggleButton)button;
                if (button2.getOnText().ToLower().Contains(Name.ToLower())) Button = button2;
            }
            if (Button != null) Button.setToggleState(state);
        }
    }
}
