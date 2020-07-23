using FuneralClientV2.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClientV2.Settings
{
    public class Config
    {
        public List<FavoritedAvatar> ExtendedFavoritedAvatars = new List<FavoritedAvatar>();

        public bool CleanConsole = true;

        public bool Optimization = true;

        public bool SpoofHWID = true;

        public bool LogModerations = false;

        public bool AntiKick = true;

        public bool AntiPublicBan = true;

        public bool AntiIpLog = true;

        public bool AntiBlock = false;

        public int MainMenuButtonX = 5;

        public int MainMenuButtonY = 2;
    }
}
