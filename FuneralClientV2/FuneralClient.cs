using FuneralClientV2.Discord;
using FuneralClientV2.Menu;
using FuneralClientV2.Modules;
using FuneralClientV2.Patching;
using FuneralClientV2.Settings;
using FuneralClientV2.Utils;
using MelonLoader;
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
            Modules.Add(new CleanConsoleModule());
            ConsoleUtil.Info("Waiting for VRChat UI Manager to Initialise..");
        }

        public override void OnUpdate()
        {
            List<VRCMod> Mods = Modules.Where(y => y.RequiresUpdate).ToList();
            Mods.ForEach(x => x.OnUpdate());
        }
    }
}
