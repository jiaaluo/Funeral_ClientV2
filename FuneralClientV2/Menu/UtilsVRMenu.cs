using BestHTTP;
using FuneralClientV2.Wrappers;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;
using VRCSDK2;

namespace FuneralClientV2.Utils
{
    public class UtilsVRMenu : QMNestedButton
    {
        public UtilsVRMenu(QMNestedButton parent) : base(parent, 1, 1, "Utils", "Extended utilities you can use to manage the game better", Color.red, Color.white, Color.red, Color.cyan)
        {
            new QMToggleButton(this, 1, 0, "Enable\nFlight", delegate
            {
                Physics.gravity = Vector3.zero;
                GeneralUtils.Flight = true;
                GeneralUtils.ToggleColliders(!GeneralUtils.Flight);
            }, "Disable\nFlight", delegate
            {
                Physics.gravity = GeneralUtils.SavedGravity;
                GeneralUtils.Flight = false;
                GeneralUtils.ToggleColliders(!GeneralUtils.Flight);
            }, "Toggle Flight and move around within the air with ease!", Color.red, Color.white).setToggleState(GeneralUtils.Flight);
            new QMToggleButton(this, 2, 0, "Enable\nESP", delegate
            {
                GeneralUtils.ESP = true;
                GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].transform.Find("SelectRegion"))
                    {
                        array[i].transform.Find("SelectRegion").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                        array[i].transform.Find("SelectRegion").GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.magenta);
                        GeneralWrappers.GetHighlightsFX().EnableOutline(array[i].transform.Find("SelectRegion").GetComponent<Renderer>(), GeneralUtils.ESP);
                    }
                }
            }, "Disable\nESP", delegate
            {
                GeneralUtils.ESP = false;
                GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].transform.Find("SelectRegion"))
                    {
                        array[i].transform.Find("SelectRegion").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                        array[i].transform.Find("SelectRegion").GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.magenta);
                        GeneralWrappers.GetHighlightsFX().EnableOutline(array[i].transform.Find("SelectRegion").GetComponent<Renderer>(), GeneralUtils.ESP);
                    }
                }
            }, "Decide whether you want the upper game, get an advantage, and see all players anywhere within the world.", Color.red, Color.white).setToggleState(GeneralUtils.ESP);
            new QMSingleButton(this, 3, 0, "Avatar\nBy\nID", delegate
            {
                ConsoleUtil.Info("Enter Avatar ID: ");
                string ID = Console.ReadLine();
                VRC.Core.API.SendRequest($"avatars/{ID}", VRC.Core.BestHTTP.HTTPMethods.Get, new ApiModelContainer<ApiAvatar>(), null, true, true, 3600f, 2, null);
                new PageAvatar
                {
                    avatar = new SimpleAvatarPedestal
                    {
                        field_Internal_ApiAvatar_0 = new ApiAvatar
                        {
                            id = ID
                        }
                    }
                }.ChangeToSelectedAvatar();
                GeneralWrappers.GetVRCUiPopupManager().AlertPopup("<color=cyan>Success!</color>", "<color=green>Successfully cloned that avatar by It's Avatar ID.</color>");
            }, "Sets your current avatar using an avatar ID.", Color.red, Color.white);
            new QMSingleButton(this, 4, 0, "Join\nBy\nID", delegate
            {
                ConsoleUtil.Info("Enter Instance ID: ");
                string ID = Console.ReadLine();
                Networking.GoToRoom(ID);
            }, "Joins an instance by It's ID.", Color.red, Color.white);
        }
    }
}
