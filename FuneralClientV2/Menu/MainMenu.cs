using FuneralClientV2.Settings;
using FuneralClientV2.Utils;
using Il2CppSystem.Threading;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FuneralClientV2.Menu
{
    public class MainMenu : QMNestedButton
    {
        public MainMenu() : base("ShortcutMenu", Configuration.GetConfig().MainMenuButtonX, Configuration.GetConfig().MainMenuButtonY, "Funeral\nV2", "A client for vrchat's il2cpp system, hopefully just an updated version of my old publicly sold client, with more features and fixed bugs of course.", Color.red, Color.white, Color.red, Color.cyan)
        {
            new QMSingleButton(this, 1, 0, "GitHub", new Action(() =>
            {
                Process.Start("https://github.com/Yaekith/Funeral_ClientV2");
            }), "Open the github repository in a new browser window", Color.red, Color.white);
            new QMSingleButton(this, 2, 0, "Discord", new Action(() =>
            {
                Process.Start("https://discord.gg/8fwurVW");
            }), "Join the official discord", Color.red, Color.white);
            new QMSingleButton(this, 3, 0, "Daily\nNotice", new Action(() =>
            {
                new System.Threading.Thread(() =>
                {
                    var information = new WebClient().DownloadString("https://pastebin.com/raw/BjsgVdQp");
                    GeneralUtils.InformHudText(Color.cyan, information);
                })
                { IsBackground = true }.Start();
            }), "Gather information about the latest notice in the Discord", Color.red, Color.white);
            new QMSingleButton(this, 4, 0, "Credits", new Action(() =>
            {
                GeneralUtils.InformHudText(Color.yellow, "Yaekith - Developer");
            }), "Displays who made this cheat", Color.red, Color.white);
            new UtilsVRMenu(this);
            new FunVRMenu(this);
            new ProtectionsVRMenu(this);
            new TargetVRMenu();
            new FavoritesVRMenu(this);
            new QMToggleButton(this, 1, 2, "Clear\nConsole", delegate
            {
                Configuration.GetConfig().CleanConsole = true;
                Configuration.SaveConfiguration();
            }, "Don't Clear\nConsole", delegate
            {
                Configuration.GetConfig().CleanConsole = false;
                Configuration.SaveConfiguration();
            }, "Decide whether you want your console to be clean constantly", Color.red, Color.white).setToggleState(Configuration.GetConfig().CleanConsole);
        }
    }
}
