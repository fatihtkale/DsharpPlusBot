using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Drawing;
using ImageMagick;
using ImageMagick.Configuration;
using System.Linq;
using Fortnite.Net;
using Fortnite.Net.Clients;
using Fortnite.Net.Resources;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;
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
                Token = "NDI3MTg3NTg4ODg2MDM2NTAw.DZwu2A.bXM3nL66-FFPmvR7kRrNs7UeOyI",
                TokenType = TokenType.Bot
            });
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });
            discord.MessageCreated += async e =>
            {
                if (Scam.censoredWords.Any(x => e.Message.Content.ToLower().Contains(x))){
                    var scamlink = new DiscordEmbedBuilder()
                    .WithColor(new DiscordColor("#f03434"))
                    .WithAuthor("🚫 Scam link found! 🚫")
                    .AddField("📩 Sent by:", $"{e.Message.Author.Username}#{e.Message.Author.Discriminator}", false)
                    .AddField("📝 Message contained:", $"{e.Message.Content}", false)
                    .AddField("🗑️ Message was deleted", $"In, {e.Message.Channel}",false)
                    .WithTimestamp(DateTime.Now);
                    await e.Guild.GetChannel(427905802553262080).SendMessageAsync(null, false, scamlink);
                    await e.Message.DeleteAsync();
                    //Removed strike system for now.
                    var reason = "";
                    var amount = 0;
                    reason = "Scam link.";
                    amount = 2;
                    await e.Guild.GetChannel(427905843535675401).SendMessageAsync($"{e.Message.Author.Username}#{e.Message.Author.Discriminator}" + "\n" + $"- {reason}" + "\n" + "Strikes: " + $"{amount}/3");
                }
                //bad words
                if (Curse.censoredWords.Any(x => e.Message.Content.ToLower().Contains(x))){
                    var curse = new DiscordEmbedBuilder()
                    .WithColor(new DiscordColor("#f03434"))
                    .WithAuthor("🚫 Curse word found! 🚫")
                    .AddField("📩 Sent by:", $"{e.Message.Author.Username}#{e.Message.Author.Discriminator}", false)
                    .AddField("📝 Message contained:", $"{e.Message.Content}", false)
                    .AddField("🗑️ Message was deleted", $"In, {e.Message.Channel}",false)
                    .WithTimestamp(DateTime.Now);
                    await e.Message.DeleteAsync();
                    await e.Guild.GetChannel(427905802553262080).SendMessageAsync(null, false, curse);
                }
            };            
            commands.RegisterCommands<Commands>();
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
            public class Commands
            {
                [Description("Gives rank")]
                public async Task getrank(CommandContext ctx, string platform, [Description("!getrank <ign>")] [RemainingText] string ign){
                    Profile pl = new FortniteClient("fc5c9c9c-0888-4f97-a5ff-1478a29b3c92").GetProfile(platform, ign);

                    var bronze = ctx.Guild.GetRole(435591542716235807);
                    var silver = ctx.Guild.GetRole(435591510080094209);
                    var gold = ctx.Guild.GetRole(435591466488823809);
                    var plat = ctx.Guild.GetRole(435591580942860298);

                    if (int.Parse(pl.LifeTimeStats.Wins) >= 10)
                    {
                        await ctx.Member.GrantRoleAsync(bronze, null);
                    }
                    if (int.Parse(pl.LifeTimeStats.Wins) >= 50)
                    {
                        await ctx.Member.RevokeRoleAsync(bronze,null);
                        await ctx.Member.GrantRoleAsync(silver, null);
                    }
                    if (int.Parse(pl.LifeTimeStats.Wins) >= 100)
                    {
                        await ctx.Member.RevokeRoleAsync(silver,null);
                        await ctx.Member.GrantRoleAsync(gold, null);
                    }
                    if (int.Parse(pl.LifeTimeStats.Wins) >= 250)
                    {
                        await ctx.Member.RevokeRoleAsync(gold,null);
                        await ctx.Member.GrantRoleAsync(plat, null);
                    }
                }

                [Command("spank")]
                [Description("Changes Nickname")]
                public async Task spank(CommandContext ctx,[Description("!spank <name>")] DiscordMember user){
                    using (MagickImage image = new MagickImage("spanking.jpg"))
                    {
                        using (MagickImage watermark = new MagickImage(ctx.Message.Author.AvatarUrl))
                        {
                            // Draw the watermark in the bottom right corner
                            watermark.Resize(200, 200);
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
                    if(ctx.User.Mention != name){
                        await ctx.RespondAsync($"Error changing name to: {name}. You have a higher rank than the bot. Try removing rank, and try again :D");
                    }else{
                        await ctx.RespondAsync($"Changed Nickname of, {ctx.User.Mention}, to " + name);    
                    }
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
