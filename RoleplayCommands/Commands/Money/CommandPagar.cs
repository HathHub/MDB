using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using OpenMod.API.Commands;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Users;
using SDG.Unturned;

namespace RoleplayCommands
{
    [Command("pagar")]
    [CommandSyntax("<player> <amount>")]
    public class CommandPagar : OpenMod.Core.Commands.Command
    {
        private readonly RoleplayCommands m_plugin;
        private readonly IUnturnedUserDirectory m_userDirectory;
        public CommandPagar(IUnturnedUserDirectory userDirectory, RoleplayCommands plugin,  IServiceProvider serviceProvider) : base(serviceProvider)
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
            if(amount > user.Player.Player.skills.experience) throw new UserFriendlyException("No tienes esa cantidad de dinero");
            if (target == Context.Actor) throw new UserFriendlyException("No puedes pagarte a ti mismo");

            user.Player.Player.skills.askSpend(amount);
            target.Player.Player.skills.askAward(amount);


            await target.PrintMessageAsync($"<color=#8EFF56>[MDB Economy]</color> <color=#FFFFFF>El jugador</color> {user.Player.Player.channel.owner.playerID.characterName} <color=#FFFFFF>te ha transferido</color> {amount}$");
            await user.PrintMessageAsync($"<color=#8EFF56>[MDB Economy]</color> <color=#FFFFFF>Has transferido</color> {amount}$ <color=#FFFFFF>al jugador</color> {target.Player.Player.channel.owner.playerID.characterName}");
            await UniTask.CompletedTask;
        }
    }
}
