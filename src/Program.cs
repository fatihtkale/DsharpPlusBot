using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Drawing;
using System.Linq;
namespace DiscordBottest
{
    class Program
    {
            static DiscordClient discord;
            static Curse curses = new Curse();
            static CommandsNextModule commands;
            static void Main(string[] args)
            {
                MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            static async Task MainAsync(string[] args)
            {
<<<<<<< HEAD
                if (Scam.censoredWords.Any(x => e.Message.Content.ToLower().Contains(x))){
                    var scamlink = new DiscordEmbedBuilder()
                    .WithColor(new DiscordColor("#f03434"))
                    .WithAuthor("🚫 Scam link found! 🚫")
                    .AddField("📩 Sent by:", $"{e.Message.Author}", false)
                    .AddField("📝 Message contained:", $"{e.Message.Content}", false)
                    .AddField("🗑️ Message was deleted", $"In, {e.Message.Channel}",false)
                    .WithTimestamp(DateTime.Now);
                    await e.Guild.GetChannel(423582347259150358).SendMessageAsync(null, false, scamlink);
                    await e.Message.DeleteAsync();
                    var reason = "";
                    var amount = 0;
                    reason = "Scam link.";
                    amount = 2;
                    await e.Guild.GetChannel(423582371044917258).SendMessageAsync($"{e.Message.Author.Username}#{e.Message.Author.Discriminator}" + "\n" + $"- {reason}" + "\n" + "Strikes: " + $"{amount}/3");
                }
                //bad words
                if (Curse.censoredWords.Any(x => e.Message.Content.ToLower().Contains(x))){
                    var curse = new DiscordEmbedBuilder()
                    .WithColor(new DiscordColor("#f03434"))
                    .WithAuthor("🚫 Curse word found! 🚫")
                    .AddField("📩 Sent by:", $"{e.Message.Author}", false)
                    .AddField("📝 Message contained:", $"{e.Message.Content}", false)
                    .AddField("🗑️ Message was deleted", $"In, {e.Message.Channel}",false)
                    .WithTimestamp(DateTime.Now);
                    await e.Message.DeleteAsync();
                    await e.Guild.GetChannel(423582347259150358).SendMessageAsync(null, false, curse);
                }
            };            
            commands.RegisterCommands<Commands>();
            await discord.ConnectAsync();
            await Task.Delay(-1);
                discord = new DiscordClient(new DiscordConfiguration
                {
                    AutoReconnect = true,
                    Token = "NDIyNDI3NjU3MjQyODA0MjI0.DYnTBw",
=======
                discord = new DiscordClient(new DiscordConfiguration
                {
                    AutoReconnect = true,
                    Token = "NDIyNDI3NjU3MjQyODA0MjI0.DYnTBw.TrjvtbAmyY-xVnnpCx5Q9dAi0lA",
>>>>>>> parent of 30b08c2... Added new spank command :O
                    TokenType = TokenType.Bot
                });
                commands = discord.UseCommandsNext(new CommandsNextConfiguration
                {
                    StringPrefix = "!"
                });
                discord.MessageCreated += async e =>
                {
                        if (Curse.censoredWords.Any(x => e.Message.Content.ToLower().Contains(x))){
                            var curse = new DiscordEmbedBuilder()
                            .WithDescription("this shows all of the commands")
                            .WithColor(new DiscordColor("#f03434"))
                            .WithAuthor("🚫 Curse word found! 🚫")
                            .AddField("📩 Sent by:", $"{e.Message.Author}", false)
                            .AddField("📝 Message contained:", $"{e.Message.Content}", false)
                            .AddField("🗑️ Message was deleted", $"In, {e.Message.Channel}",false)
                            .WithTimestamp(DateTime.Now);
                            await e.Guild.GetChannel(423463286252634114).SendMessageAsync(null, false, curse);
                        }
                };
                
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
                    await ctx.RespondAsync($"👋 Hello!, {ctx.User.Mention}!");
                }

                [Command("random")]
                public async Task Random(CommandContext ctx, int min, int max)
                {
                    var rnd = new Random();
                    await ctx.RespondAsync($"🎲 Your random number is: {rnd.Next(min, max)}!");
                }
               [Command("commands")]
                public async Task comds(CommandContext ctx)
                {
                    var helpembed = new DiscordEmbedBuilder()
                    .WithDescription("this shows all of the commands")
                    .WithColor(new DiscordColor("#f03434"))
                    .WithAuthor("Commands")
                    .AddField("Changenick", "!changenick - Changes username of a person. Usage: !changenick <name>", false)
                    .AddField("Random", "!random - Roll a number. Usage: !random <minnumber> <maxnumber>", false)
                    .AddField("Hi", "!hi - bot greets you!", false);
                    await ctx.RespondAsync(null, false, helpembed);
                }
            }
    }
}