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
                GeneralUtils.AntiKick = true;
            }, "Disable\nAnti Kick", delegate
            {
                GeneralUtils.AntiKick = false;
            }, "Harvest the infinite power of this world and decide whether people can kick you from the instance or not.", Color.red, Color.white);
            new QMToggleButton(this, 2, 0, "Enable\nAnti Block", delegate
            {
                GeneralUtils.AntiBlock = true;
            }, "Disable\nAnti Block", delegate
            {
                GeneralUtils.AntiBlock = false;
            }, "Decide whether you want to see people who you've blocked and/or people who have blocked you.", Color.red, Color.white);
            new QMToggleButton(this, 3, 0, "Enable\nAnti Public Ban", delegate
            {
                GeneralUtils.AntiPublicBan = true;
            }, "Disable\nAnti Public Ban", delegate
            {
                GeneralUtils.AntiPublicBan = false;
            }, "This feature is actually supposed to allow you to enter public instances when you're public banned, nice game VRChat.", Color.red, Color.white);
            new QMToggleButton(this, 4, 0, "Enable\nOptimization", delegate
            {
                GeneralUtils.Optimization = true;
            }, "Disable\nOptimization", delegate
            {
                GeneralUtils.Optimization = false;
            }, "This feature, when enabled, auto-hides players when they're far away from you.", Color.red, Color.white);
        }
    }
}
