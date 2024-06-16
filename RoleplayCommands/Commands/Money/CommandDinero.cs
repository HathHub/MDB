using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenMod.API.Commands;
using OpenMod.API.Plugins;
using OpenMod.Core.Commands;
using OpenMod.Extensions.Games.Abstractions.Players;
using OpenMod.Unturned.Plugins;
using OpenMod.Unturned.Users;
using SDG.Unturned;
using UnityEngine;

namespace RoleplayCommands
{
    [Command("dinero")]
    public class CommandDinero : OpenMod.Core.Commands.Command
    {
        private readonly RoleplayCommands m_plugin;
        private readonly IUnturnedUserDirectory m_userDirectory;
        public CommandDinero(IUnturnedUserDirectory userDirectory, RoleplayCommands plugin,  IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_plugin = plugin;
            m_userDirectory = userDirectory;
        }

        protected override async Task OnExecuteAsync()
        {
            UnturnedUser user = (UnturnedUser)Context.Actor;
            await user.PrintMessageAsync($"<color=#8EFF56>[MDB Economy]</color> <color=#FFFFFF>Tienes: {user.Player.Player.skills.experience}$");
            await UniTask.CompletedTask;
        }
    }
}
