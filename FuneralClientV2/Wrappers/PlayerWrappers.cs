using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;

namespace FuneralClientV2.Wrappers
{
    public static class PlayerWrappers
    {
        public static VRCPlayer GetCurrentPlayer() { return VRCPlayer.field_Internal_Static_VRCPlayer_0; }

        public static Il2CppReferenceArray<Player> GetAllPlayers(this PlayerManager instance) { return instance.prop_ArrayOf_Player_0;  }

        public static APIUser GetAPIUser(this Player player) { return player.field_Private_APIUser_0; }

        public static ApiAvatar GetAPIAvatar(this VRCPlayer player) { return player.prop_ApiAvatar_0; }

        public static Player GetVRC_Player(this VRCPlayer player) { return player.field_Private_Player_0; }

        public static VRCPlayer GetVRCPlayer(this Player player) { return player.field_Internal_VRCPlayer_0; }

        public static Player GetPlayer(this PlayerManager instance, string UserID)
        {
            var Players = instance.GetAllPlayers();
            Player FoundPlayer = null;
            for (int i = 0; i < Players.Count; i++)
            {
                var player = Players[i];
                if (player.GetAPIUser().id == UserID) FoundPlayer = player;
            }
            return FoundPlayer;
        }
        public static Player GetPlayer(this PlayerManager instance, int Index)
        {
            var Players = instance.GetAllPlayers();
            return Players[Index];
        }
        public static Player GetSelectedPlayer(this QuickMenu instance)
        {
            var APIUser = instance.field_Private_APIUser_0;
            var playerManager = GeneralWrappers.GetPlayerManager();
            return playerManager.GetPlayer(APIUser.id);
        }

        public static Player GetPlayerByRayCast(this RaycastHit RayCast)
        {
            var gameObject = RayCast.transform.gameObject;
            return GetPlayer(GeneralWrappers.GetPlayerManager(), VRCPlayerApi.GetPlayerByGameObject(gameObject).playerId);
        }

        public static ulong GetSteamID(this VRCPlayer player) { return player.field_Private_UInt64_0; }

        public static ObjectPublicObInBoStHaStBoObInHaUnique GetPhotonPlayer(this Player player) { return player.prop_ObjectPublicObInBoStHaStBoObInHaUnique_0; }

        public static Hashtable GetHashtable(this ObjectPublicObInBoStHaStBoObInHaUnique photonPlayer) { return photonPlayer.prop_Hashtable_0; }
    }
}
