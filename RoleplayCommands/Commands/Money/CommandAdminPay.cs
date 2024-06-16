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
    [Command("adminpay")]
    [CommandAlias("adminp")]
    [CommandSyntax("<player> <amount>")]
    public class CommandAdminPay : OpenMod.Core.Commands.Command
    {
        private readonly RoleplayCommands m_plugin;
        private readonly IUnturnedUserDirectory m_userDirectory;
        public CommandAdminPay(IUnturnedUserDirectory userDirectory, RoleplayCommands plugin,  IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_plugin = plugin;
            m_userDirectory = userDirectory;
        }

        protected override async Task OnExecuteAsync()
        {
            UnturnedUser user = (UnturnedUser)Context.Actor;
            UnturnedUser target = m_userDirectory.FindUser(await Context.Parameters.GetAsync<string>(0), OpenMod.API.Users.UserSearchMode.FindByNameOrId);
            if(target == null) throw new UserFriendlyException("Jugador no encontrado.");

            uint amount = await Context.Parameters.GetAsync<uint>(1);

            if (amount < 1) throw new CommandWrongUsageException(Context);

            target.Player.Player.skills.askAward(amount);

            await user.PrintMessageAsync($"<color=#8EFF56>[MDB Economy]</color> <color=#FFFFFF>Has añadido</color> {amount}$ <color=#FFFFFF>al jugador</color> {target.Player.Player.channel.owner.playerID.characterName}");
            await UniTask.CompletedTask;
        }
    }
}
