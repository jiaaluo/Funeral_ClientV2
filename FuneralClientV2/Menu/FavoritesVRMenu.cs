using BestHTTP;
using FuneralClientV2.API;
using FuneralClientV2.Settings;
using FuneralClientV2.Wrappers;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;
using VRCSDK2;

namespace FuneralClientV2.Utils
{
    public class FavoritesVRMenu : QMNestedButton
    {
        private bool DeleteMode = false;
        private int X = 1;
        private int Y = 0;
        public FavoritesVRMenu(QMNestedButton parent) : base(parent, 4, 1, "Extended\nFavorites", "Open up the extended favorites menu and add more avatars than the default limit of 16", Color.red, Color.white, Color.red, Color.cyan)
        {
            new QMSingleButton(this, 0, 0, "Next", delegate
            {
                //to-do
            }, "Go to the next page", Color.red, Color.white);

            new QMSingleButton(this, 0, 1, "Back", delegate
            {
               //to-do
            }, "Go back to the previous page", Color.red, Color.white);

            new QMSingleButton(this, 5, 0, "Add\nCurrent Avatar", delegate
            {
                var currentAvatar = PlayerWrappers.GetCurrentPlayer().GetAPIAvatar();
                Configuration.GetConfig().ExtendedFavoritedAvatars.Add(new FavoritedAvatar(currentAvatar.name, currentAvatar.id, currentAvatar.authorName, currentAvatar.authorId));
                Configuration.SaveConfiguration();
                GeneralWrappers.GetVRCUiPopupManager().AlertPopup("<color=cyan>Success!</color>", "<color=green>Successfully added your current Avatar to extended favorites</color>");
            }, "Adds your current avatar to the extended favorites list", Color.red, Color.white);

            new QMSingleButton(this, 5, 1, "Remove\nCurrent Avatar", delegate
            {
                var currentAvatar = GeneralUtils.GetExtendedFavorite(PlayerWrappers.GetCurrentPlayer().GetAPIAvatar().id);
                Configuration.GetConfig().ExtendedFavoritedAvatars.Remove(currentAvatar);
                Configuration.SaveConfiguration();
                GeneralWrappers.GetVRCUiPopupManager().AlertPopup("<color=cyan>Success!</color>", "<color=green>Successfully removed your current Avatar from extended favorites</color>");
            }, "Removes your current avatar from the extended favorites list", Color.red, Color.white);

            new QMToggleButton(this, 5, -1, "Delete\nMode", delegate
            {
                DeleteMode = true;
            }, "Normal\nMode", delegate
            {
                DeleteMode = false;
            }, "Enable/Disable Delete Mode, with this on, you can remove avatars from this list by just clicking their respective buttons", Color.red, Color.white);

            foreach(var avatar in Configuration.GetConfig().ExtendedFavoritedAvatars)
            {
                if (X == 4)
                {
                    if (Y != 4)
                    {
                        new QMSingleButton(this, X, Y, avatar.Name, delegate
                        {
                            if (DeleteMode)
                            {
                                Configuration.GetConfig().ExtendedFavoritedAvatars.Remove(avatar);
                                Configuration.SaveConfiguration();
                                GeneralWrappers.GetVRCUiPopupManager().AlertPopup("<color=cyan>Success!</color>", "<color=green>Successfully removed this Avatar from extended favorites</color>");
                            }
                            else
                            {
                                VRC.Core.API.SendRequest($"avatars/{avatar.ID}", VRC.Core.BestHTTP.HTTPMethods.Get, new ApiModelContainer<ApiAvatar>(), null, true, true, 3600f, 2, null);
                                new PageAvatar
                                {
                                    avatar = new SimpleAvatarPedestal
                                    {
                                        field_Internal_ApiAvatar_0 = new ApiAvatar
                                        {
                                            id = avatar.ID
                                        }
                                    }
                                }.ChangeToSelectedAvatar();
                            }
                        }, $"by {avatar.Author}\nSwitch into this avatar.", Color.red, Color.white);
                    }
                    Y++;
                }
                else
                {
                    new QMSingleButton(this, X, Y, avatar.Name, delegate
                    {
                        if (DeleteMode)
                        {
                            Configuration.GetConfig().ExtendedFavoritedAvatars.Remove(avatar);
                            Configuration.SaveConfiguration();
                            GeneralWrappers.GetVRCUiPopupManager().AlertPopup("<color=cyan>Success!</color>", "<color=green>Successfully removed this Avatar from extended favorites</color>");
                        }
                        else
                        {
                            VRC.Core.API.SendRequest($"avatars/{avatar.ID}", VRC.Core.BestHTTP.HTTPMethods.Get, new ApiModelContainer<ApiAvatar>(), null, true, true, 3600f, 2, null);
                            new PageAvatar
                            {
                                avatar = new SimpleAvatarPedestal
                                {
                                    field_Internal_ApiAvatar_0 = new ApiAvatar
                                    {
                                        id = avatar.ID
                                    }
                                }
                            }.ChangeToSelectedAvatar();
                        }
                    }, $"by {avatar.Author}\nSwitch into this avatar.", Color.red, Color.white);
                    X++;
                }
            }
        }
    }
}
