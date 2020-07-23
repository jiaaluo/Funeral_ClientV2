using FuneralClientV2.Discord;
using FuneralClientV2.Menu;
using FuneralClientV2.Modules;
using FuneralClientV2.Patching;
using FuneralClientV2.Settings;
using FuneralClientV2.Utils;
using MelonLoader;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FuneralClientV2
{
    public class FuneralClient : MelonMod
    {
        public static List<VRCMod> Modules = new List<VRCMod>();

        public override void VRChat_OnUiManagerInit()
        {
            try
            {
                ConsoleUtil.Info("[DEBUG] VRChat_OnUiManagerInit callback was fired.");
                Modules.ForEach(y => y.OnStart());
                new QMSingleButton("CameraMenu", 1, 1, "Move Menu Button\nLeft", new Action(() =>
                {
                    if (Configuration.GetConfig().MainMenuButtonX != 1)
                    {
                        Configuration.GetConfig().MainMenuButtonX--;
                        Configuration.SaveConfiguration();
                        GeneralUtils.InformHudText(Color.yellow, "Successfully saved menu button position\nRestart your game for it to take effect.");
                    }
                }), "Moves the main menu button to the left within the UI", Color.red, Color.white);
                new QMSingleButton("CameraMenu", 1, 2, "Move Menu Button\nRight", new Action(() =>
                {
                    if (Configuration.GetConfig().MainMenuButtonX != 1)
                    {
                        Configuration.GetConfig().MainMenuButtonX++;
                        Configuration.SaveConfiguration();
                        GeneralUtils.InformHudText(Color.yellow, "Successfully saved menu button position\nRestart your game for it to take effect.");
                    }
                }), "Moves the main menu button to the right within the UI", Color.red, Color.white);
                new QMSingleButton("CameraMenu", 2, 1, "Move Menu Button\nUp", new Action(() =>
                {
                    if (Configuration.GetConfig().MainMenuButtonY != 0)
                    {
                        Configuration.GetConfig().MainMenuButtonY--;
                        Configuration.SaveConfiguration();
                        GeneralUtils.InformHudText(Color.yellow, "Successfully saved menu button position\nRestart your game for it to take effect.");
                    }
                }), "Moves the main menu button up within the UI", Color.red, Color.white);
                new QMSingleButton("CameraMenu", 2, 2, "Move Menu Button\nDown", new Action(() =>
                {
                    if (Configuration.GetConfig().MainMenuButtonY != 4)
                    {
                        Configuration.GetConfig().MainMenuButtonY++;
                        Configuration.SaveConfiguration();
                        GeneralUtils.InformHudText(Color.yellow, "Successfully saved menu button position\nRestart your game for it to take effect.");
                    }
                }), "Moves the main menu button up within the UI", Color.red, Color.white);
                new MainMenu();
                PatchManager.ApplyPatches();
            }
            catch (Exception) { }
        }

        public override void OnApplicationStart()
        {
            ConsoleUtil.SetTitle("Funeral Client V2 = Developed by Yaekith");
            Configuration.CheckExistence();
            DiscordRPC.Start();
            Modules.Add(new GeneralHandlers());
            ConsoleUtil.Info("Waiting for VRChat UI Manager to Initialise..");
        }

        public override void OnUpdate()
        {
            List<VRCMod> Mods = Modules.Where(y => y.RequiresUpdate).ToList();
            Mods.ForEach(x => x.OnUpdate());
        }
    }
}
