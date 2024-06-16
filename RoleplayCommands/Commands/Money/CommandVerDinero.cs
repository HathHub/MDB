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
    [Command("verdinero")]
    [CommandAlias("vd")]
    [CommandSyntax("<player>")]
    public class CommandVerDinero : OpenMod.Core.Commands.Command
    {
        private readonly RoleplayCommands m_plugin;
        private readonly IUnturnedUserDirectory m_userDirectory;
        public CommandVerDinero(IUnturnedUserDirectory userDirectory, RoleplayCommands plugin,  IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_plugin = plugin;
            m_userDirectory = userDirectory;
        }

        protected override async Task OnExecuteAsync()
        {
            UnturnedUser target = m_userDirectory.FindUser(await Context.Parameters.GetAsync<string>(0), OpenMod.API.Users.UserSearchMode.FindByNameOrId);
            if(target == null) throw new UserFriendlyException("Jugador no encontrado.");

            await target.PrintMessageAsync($"<color=#8EFF56>[MDB Economy]</color> <color=#FFFFFF>El jugador</color> {target.Player.Player.channel.owner.playerID.characterName} <color=#FFFFFF>tiene</color> {target.Player.Player.skills.experience}$");
            await UniTask.CompletedTask;
        }
    }
}
