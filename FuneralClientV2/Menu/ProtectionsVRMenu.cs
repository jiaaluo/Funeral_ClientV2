using FuneralClientV2.Settings;
using FuneralClientV2.Wrappers;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FuneralClientV2.Utils
{
    public class ProtectionsVRMenu : QMNestedButton
    {
        public ProtectionsVRMenu(QMNestedButton parent) : base(parent, 3, 1, "Protections", "A menu full of protection options against moderation, and other safety related features.", Color.red, Color.white, Color.red, Color.cyan)
        {
            new QMToggleButton(this, 1, 0, "Enable\nAnti Kick", delegate
            {
                Configuration.GetConfig().AntiKick = true;
                Configuration.SaveConfiguration();
            }, "Disable\nAnti Kick", delegate
            {
                Configuration.GetConfig().AntiKick = false;
                Configuration.SaveConfiguration();
            }, "Harvest the infinite power of this world and decide whether people can kick you from the instance or not.", Color.red, Color.white).setToggleState(Configuration.GetConfig().AntiKick);
            new QMToggleButton(this, 2, 0, "Enable\nAnti Block", delegate
            {
                Configuration.GetConfig().AntiBlock = true;
                Configuration.SaveConfiguration();
            }, "Disable\nAnti Block", delegate
            {
                Configuration.GetConfig().AntiBlock = false;
                Configuration.SaveConfiguration();
            }, "Decide whether you want to see people who you've blocked and/or people who have blocked you.", Color.red, Color.white).setToggleState(Configuration.GetConfig().AntiBlock);
            new QMToggleButton(this, 3, 0, "Enable\nAnti Public Ban", delegate
            {
                Configuration.GetConfig().AntiPublicBan = true;
                Configuration.SaveConfiguration();
            }, "Disable\nAnti Public Ban", delegate
            {
                Configuration.GetConfig().AntiPublicBan = false;
                Configuration.SaveConfiguration();
            }, "This feature is actually supposed to allow you to enter public instances when you're public banned, nice game VRChat.", Color.red, Color.white).setToggleState(Configuration.GetConfig().AntiPublicBan);
            new QMToggleButton(this, 4, 0, "Enable\nOptimization", delegate
            {
                Configuration.GetConfig().Optimization = true;
                Configuration.SaveConfiguration();
            }, "Disable\nOptimization", delegate
            {
                Configuration.GetConfig().Optimization = false;
                Configuration.SaveConfiguration();
            }, "This feature, when enabled, auto-hides players when they're far away from you.", Color.red, Color.white).setToggleState(Configuration.GetConfig().Optimization);
            new QMToggleButton(this, 1, 1, "Enable\nHWID Spoofer", delegate
            {
                Configuration.GetConfig().SpoofHWID = true;
                Configuration.SaveConfiguration();
            }, "Disable\nHWID Spoofer", delegate
            {
                Configuration.GetConfig().SpoofHWID = false;
                Configuration.SaveConfiguration();
            }, "This feature, when enabled, spoofs your deviceId upon game launch, to bypass bans and stuff.", Color.red, Color.white).setToggleState(Configuration.GetConfig().SpoofHWID);
            new QMToggleButton(this, 1, 2, "Enable\nAnti Ip Logging", delegate
            {
                Configuration.GetConfig().AntiIpLog = true;
                Configuration.SaveConfiguration();
            }, "Disable\nAnti Ip Logging", delegate
            {
                Configuration.GetConfig().AntiIpLog = false;
                Configuration.SaveConfiguration();
            }, "This feature, when enabled, prevents your ip from being logged from pathetic grabbing videos on video players.", Color.red, Color.white).setToggleState(Configuration.GetConfig().AntiIpLog);
        }
    }
}
