using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Drawing;

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
                    AutoReconnect = true,
                    Token = "NDIyNDI3NjU3MjQyODA0MjI0.DYbn7g.nrK4gfZufKCZL-yxUhifSBLGm_4",
                    TokenType = TokenType.Bot
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
               [Command("commands")]
                public async Task comds(CommandContext ctx)
                {
                    var embed = new DiscordEmbedBuilder()
                    .WithDescription("this shows all of the commands")
                    .WithColor(new DiscordColor("#f03434"))
                    .WithAuthor(
                    "Commands"
                    )
                    .AddField("Changenick", "!changenick - Changes username of a person. Usage: !changenick <name>", false)
                    .AddField("Random", "!random - Roll a number. Usage: !random <minnumber> <maxnumber>", false)
                    .AddField("Hi", "!hi - bot greets you!", false);
                    await ctx.RespondAsync(null, false, embed);
                }
            }
    }
}
