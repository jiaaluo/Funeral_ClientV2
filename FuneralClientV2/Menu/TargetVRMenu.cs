using FuneralClientV2.Wrappers;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FuneralClientV2.Menu
{
    public class TargetVRMenu : QMNestedButton
    {
        public TargetVRMenu() : base("UserInteractMenu", 3, 3, "Player\nOptions", "Open this menu and control what you want of other players.", Color.red, Color.white, Color.red, Color.cyan)
        {
            new QMSingleButton(this, 1, 0, "Teleport", new Action(() =>
            {
                PlayerWrappers.GetCurrentPlayer().transform.position = PlayerWrappers.GetSelectedPlayer(GeneralWrappers.GetQuickMenu()).transform.position;
            }), "Teleports you to the selected player.", Color.red, Color.white);
            new QMToggleButton(this, 2, 0, "Local\nBlock", delegate
            {
                var player = PlayerWrappers.GetSelectedPlayer(GeneralWrappers.GetQuickMenu());
                player.gameObject.SetActive(false);
            }, "Local\nUnblock", delegate
            {
                var player = PlayerWrappers.GetSelectedPlayer(GeneralWrappers.GetQuickMenu());
                player.gameObject.SetActive(true);
            }, "Decide whether you want to block this user locally, meaning, the blocking doesn't effect them but it also makes them disappear to yourself.", Color.red, Color.white);
        }
    }
}
