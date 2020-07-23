using FuneralClientV2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClientV2.Modules
{
    public class VRCMod
    {
        public virtual string Name => "Example Module";

        public virtual string Description => "Example Description";

        public virtual bool RequiresUpdate { get; set; }

        public VRCMod() => ConsoleUtil.Info($"VRC Mod {this.Name} has Loaded. {this.Description}");

        public virtual void OnStart()
        {

        }

        public virtual void OnUpdate()
        {

        }
    }
}
