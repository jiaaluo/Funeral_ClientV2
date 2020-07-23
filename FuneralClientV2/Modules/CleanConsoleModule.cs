using FuneralClientV2.Utils;
using FuneralClientV2.Wrappers;
using Il2CppSystem.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FuneralClientV2.Modules
{
    public class CleanConsoleModule : VRCMod
    {
        public override string Name => "Clean Console";

        public override string Description => "Cleans the console every x amount of minutes, to get rid of annoying spam -_-";

        public override bool RequiresUpdate => true;

        public override void OnStart() 
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10000;
            timer.Elapsed += CleanConsole;
            timer.Enabled = true;
            timer.AutoReset = true;
        }

        private void CleanConsole(object sender, System.Timers.ElapsedEventArgs e) { if (GeneralUtils.ClearConsole) Console.Clear(); }

        public override void OnUpdate() { }
    }
}
