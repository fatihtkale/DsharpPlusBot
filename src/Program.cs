using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Drawing;
using ImageMagick;
using ImageMagick.Configuration;
using System.Linq;
namespace DiscordBottest
{
    class Program
    {
        static DiscordClient discord;
        static CommandsNextModule commands;
        static Curse curses = new Curse();
        static Scam scam = new Scam();
        
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                AutoReconnect = true,
                Token = "TOKEN",
                TokenType = TokenType.Bot
            });
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
<<<<<<< HEAD
                StringPrefix = "!"
            });
            discord.MessageCreated += async e =>
            {
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
=======
                discord = new DiscordClient(new DiscordConfiguration
                {
                    AutoReconnect = true,
                    Token = "NDIyNDI3NjU3MjQyODA0MjI0.DYnTBw",
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
>>>>>>> master
            }
            public class Commands
            {
                [Command("spank")]
                [Description("Changes Nickname")]
                public async Task spank(CommandContext ctx,[Description("!spank <name>")] DiscordMember user){
                    using (MagickImage image = new MagickImage("spanking.jpg"))
                    {
                        using (MagickImage watermark = new MagickImage(ctx.Message.Author.AvatarUrl))
                        {
                            // Draw the watermark in the bottom right corner
                            image.Composite(watermark, Gravity.North, CompositeOperator.Over);
                            var water = new MagickImage(user.AvatarUrl);
                            water.Resize(200, 200);
                            image.Composite(water, 130, 400, CompositeOperator.Over);
                        }
                        image.Write("spank.jpg");
                    }
                    await ctx.RespondWithFileAsync("spank.jpg", $"You spanked {user.Username}#{user.Discriminator} 🍑👏");
                }
 
                [Command("changenick")]
                [Description("Changes Nickname")]
                public async Task Changenick(CommandContext ctx,[Description("!changenick <name>")] [RemainingText] string name){
                    await ctx.RespondAsync($"Changed Nickname of, {ctx.User.Mention}, to " + name);
                    await ctx.Member.ModifyAsync(nickname: name);
                }

                [Command("hi")]
                [Description("Says hi to specified user!")]
                public async Task Hi(CommandContext ctx)
                {
                    await ctx.RespondAsync($"👋 Hello!, {ctx.User.Mention}!");
                }
                
                [Command("random")]
                [Description("Rolls a random number!")]
                public async Task Random(CommandContext ctx, int min, int max)
                {
                    var rnd = new Random();
                    await ctx.RespondAsync($"🎲 Your random number is: {rnd.Next(min, max)}!");
                }
            }
    }
}
