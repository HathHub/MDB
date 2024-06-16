using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MoreLinq;
using OpenMod.API.Commands;
using OpenMod.API.Plugins;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Plugins;
using OpenMod.Unturned.Users;
using SDG.Unturned;
using UnityEngine;

namespace RoleplayCommands
{
    [Command("me")]
    [CommandSyntax("<text>")]
    public class CommandMe : OpenMod.Core.Commands.Command
    {
        private readonly RoleplayCommands m_plugin;
        private readonly IUnturnedUserDirectory m_unturnedUserDirectory;
        public CommandMe(IUnturnedUserDirectory unturnedUserDirectory, RoleplayCommands plugin,  IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_plugin = plugin;
            m_unturnedUserDirectory = unturnedUserDirectory;
        }

        protected override async Task OnExecuteAsync()
        {
            UnturnedUser user = (UnturnedUser)Context.Actor;
            if (Context.Parameters.Count == 0) throw new CommandWrongUsageException(Context);
            string entorno = string.Join(" ", Context.Parameters);
            var config = m_plugin.config.Me;
            m_unturnedUserDirectory.GetOnlineUsers()
                .ForEach(x =>
                {
                    if ((user.Player.Player.transform.position - x.Player.Player.transform.position).sqrMagnitude < 25f * 25f)
                    {
                        x.Player.PrintMessageAsync($"{config.Prefix} {user.Player.Player.channel.owner.playerID.characterName.TrimStart()}: <color={config.Text}>* <i>{entorno}</i> *", System.Drawing.Color.White);
                    }
                });
            await UniTask.CompletedTask;
        }
    }
}
