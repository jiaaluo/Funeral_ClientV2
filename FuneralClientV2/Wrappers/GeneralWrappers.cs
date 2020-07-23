using BestHTTP.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;

namespace FuneralClientV2.Wrappers
{
    public static class GeneralWrappers
    {
        public static PlayerManager GetPlayerManager() { return PlayerManager.Method_Public_Static_PlayerManager_0(); }

        public static QuickMenu GetQuickMenu() { return QuickMenu.prop_QuickMenu_0; }

        public static VRCUiManager GetVRCUiPageManager() { return VRCUiManager.field_Protected_Static_VRCUiManager_0; }

        public static UserInteractMenu GetUserInteractMenu() { return Resources.FindObjectsOfTypeAll<UserInteractMenu>()[0]; }

        public static GameObject GetPlayerCamera() { return GameObject.Find("Camera (eye)"); }

        public static VRCVrCamera GetVRCVrCamera() { return VRCVrCamera.field_Private_Static_VRCVrCamera_0; }

        public static string GetRoomId() { return APIUser.CurrentUser.location; }

        public static void SetToolTipBasedOnToggle(this UiTooltip tooltip)
        {
            UiToggleButton componentInChildren = tooltip.gameObject.GetComponentInChildren<UiToggleButton>();

            if (componentInChildren != null && !string.IsNullOrEmpty(tooltip.alternateText))
            {
                string displayText = (!componentInChildren.toggledOn) ? tooltip.alternateText : tooltip.text;
                if (TooltipManager.field_Private_Static_Text_0 != null) //Only return type field of text
                {
                    TooltipManager.Method_Public_Static_Void_String_5(displayText); //Last function to take string parameter
                }
                else if (tooltip != null) tooltip.text = displayText;
            }
        }
        public static void SetPosition(this Transform transform, float x_pos, float y_pos)
        {
            var quickMenu = GetQuickMenu();
            float X = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            float Y = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            transform.transform.localPosition = new Vector3(X * x_pos, Y * y_pos);
        }

        public static VRCUiManager GetVRCUiManager() { return VRCUiManager.prop_VRCUiManager_0; }

        public static HighlightsFX GetHighlightsFX() { return HighlightsFX.prop_HighlightsFX_0; }

        public static void EnableOutline(this HighlightsFX instance, Renderer renderer, bool state) => instance.Method_Public_Void_Renderer_Boolean_0(renderer, state); //First method to take renderer, bool parameters

        public static VRCUiPopupManager GetVRCUiPopupManager() { return Resources.FindObjectsOfTypeAll<VRCUiPopupManager>()[0]; }

        public static void AlertPopup(this VRCUiPopupManager manager, string title, string text) => manager.Method_Public_Void_String_String_Single_0(title, text, 10f);
    }
}
