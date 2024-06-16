using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenMod.API.Commands;
using OpenMod.API.Plugins;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Plugins;
using OpenMod.Unturned.Users;
using SDG.Unturned;
using UnityEngine;

namespace RoleplayCommands
{
    [Command("twitter")]
    [CommandAlias("twt")]
    [CommandSyntax("<text>")]
    public class CommandTwitter : OpenMod.Core.Commands.Command
    {
        private readonly RoleplayCommands m_plugin;
        public CommandTwitter(RoleplayCommands plugin,  IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_plugin = plugin;
        }

        protected override async Task OnExecuteAsync()
        {
            UnturnedUser user = (UnturnedUser)Context.Actor;
            if (Context.Parameters.Count == 0) throw new CommandWrongUsageException(Context);
            string entorno = string.Join(" ", Context.Parameters);
            var config = m_plugin.config.Twitter;
            await UniTask.SwitchToMainThread();
            ChatManager.say($"{config.Prefix} @{user.Player.Player.channel.owner.playerID.characterName.TrimStart()}: <color={config.Text}>{entorno}", Color.white, true);
            await UniTask.CompletedTask;
        }
    }
}
