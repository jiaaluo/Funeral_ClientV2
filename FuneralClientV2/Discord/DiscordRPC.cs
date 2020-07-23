using FuneralClientV2.Utils;
using FuneralClientV2.Wrappers;
using Il2CppSystem.IO;
using Il2CppSystem.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FuneralClientV2.Discord
{
    public static class DiscordRPC
    {
        private static DiscordRpc.RichPresence presence;
        private static DiscordRpc.EventHandlers eventHandlers;

        public static void Start()
        {
            if (!File.Exists("Dependencies/discord-rpc.dll"))
            {
                new System.Threading.Thread(() =>
                {
                    new WebClient().DownloadFile("https://cdn-20.anonfiles.com/ZfN5JdHfo5/9db29b29-1595523322/discord-rpc.dll", "Dependencies/discord-rpc.dll");
                }).Start();
            }
            eventHandlers = default(DiscordRpc.EventHandlers);
            presence.details = "A very cool public free cheat";
            presence.state = "Starting Game...";
            presence.largeImageKey = "funeral_logo";
            presence.smallImageKey = "big_pog";
            presence.partySize = 0;
            presence.partyMax = 0;
            presence.startTimestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            DiscordRpc.Initialize("735902136629592165", ref eventHandlers, true, "");
            DiscordRpc.UpdatePresence(ref presence);
            new System.Threading.Thread(() =>
            {
                System.Timers.Timer timer = new System.Timers.Timer(15000);
                timer.Elapsed += Update;
                timer.AutoReset = true;
                timer.Enabled = true;
            }).Start();
        }
        public static void Update(object sender, ElapsedEventArgs args)
        {
            var room = RoomManagerBase.field_Internal_Static_ApiWorld_0;
            presence.state = $"In a(n) {room.currentInstanceAccess} instance";
            if (room.currentInstanceAccess == VRC.Core.ApiWorldInstance.AccessType.InviteOnly) presence.largeImageKey = "big_pog";
            else presence.largeImageKey = "even_more_pog";
            presence.smallImageKey = "funeral_logo";
            presence.partySize = 1;
            presence.partyMax = GeneralWrappers.GetPlayerManager().GetAllPlayers().Count;
            presence.largeImageText = $"As {PlayerWrappers.GetCurrentPlayer().GetVRC_Player().GetAPIUser().displayName}";
            presence.smallImageText = GeneralUtils.Version;
            DiscordRpc.UpdatePresence(ref presence);
        }
    }
}
