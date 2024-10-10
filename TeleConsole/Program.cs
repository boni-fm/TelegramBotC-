﻿using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("7086712976:AAHpDdORNShuOMRgKlxSAunk35dZ-dpOreo", cancellationToken: cts.Token);
var me = await bot.GetMeAsync();
bot.OnMessage += OnMessage;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel(); // stop the bot

// method that handle messages received by the bot:
async Task OnMessage(Message msg, UpdateType type)
{
    if (msg.Text is null) return;	// we only handle Text messages here
    Console.WriteLine($"Received {type} '{msg.Text}' in {msg.Chat}");
    // let's echo back received text in the chat
    await bot.SendTextMessageAsync(msg.Chat, $"{msg.From} said: {msg.Text}");
}

//using Telegram.Bot;
//using Telegram.Bot.Types;
//using Telegram.Bot.Types.Enums;

//using var cts = new CancellationTokenSource();
//var bot = new TelegramBotClient("YOUR_BOT_TOKEN");
//var me = await bot.GetMeAsync();

//Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
//Console.ReadLine();
//cts.Cancel(); // stop the bot

//// method that handle messages received by the bot:
//async Task OnMessage(Message msg, UpdateType type)
//{
//    if (msg.Text is null) return;	// we only handle Text messages here
//    Console.WriteLine($"Received {type} '{msg.Text}' in {msg.Chat}");
//    // let's echo back received text in the chat
//    await bot.SendTextMessageAsync(msg.Chat, $"{msg.From} said: {msg.Text}");
//}
