using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBottest
{
    class Program
    {
            static DiscordClient discord;
            static CommandsNextModule commands;
            static void Main(string[] args)
            {
                MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            static async Task MainAsync(string[] args)
            {
                discord = new DiscordClient(new DiscordConfiguration
                {
                    Token = "NDIyNDI3NjU3MjQyODA0MjI0.DYbn7g.nrK4gfZufKCZL-yxUhifSBLGm_4",
                    TokenType = TokenType.Bot,
                    UseInternalLogHandler = true,
                    LogLevel = LogLevel.Debug
                });
                commands = discord.UseCommandsNext(new CommandsNextConfiguration
                {
                    StringPrefix = "!"
                });

                commands.RegisterCommands<Commands>();

                await discord.ConnectAsync();
                await Task.Delay(-1);
            }
            public class Commands
            {
                [Command("changenick")]
                public async Task Changenick(CommandContext ctx,[RemainingText]  string name){
                    await ctx.RespondAsync($"Changed Nickname of, {ctx.User.Mention}, to " + name);
                    await ctx.Member.ModifyAsync(nickname: name);
                }

                [Command("hi")]
                public async Task Hi(CommandContext ctx)
                {
                    await ctx.RespondAsync($"👋 Hai, {ctx.User.Mention}!");
                }

                [Command("random")]
                public async Task Random(CommandContext ctx, int min, int max)
                {
                    var rnd = new Random();
                    await ctx.RespondAsync($"🎲 Your random number is: {rnd.Next(min, max)}");
                }
            }
    }
}
