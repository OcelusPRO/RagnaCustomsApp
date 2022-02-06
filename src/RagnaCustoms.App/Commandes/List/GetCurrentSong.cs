using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RagnaCustoms.App.Properties;
using RagnaCustoms.App.Views;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace RagnaCustoms.App.Commandes
{
    internal class CurrentSongCommand : ICommandes
    {
        List<string> ICommandes.Names()
        {
            return new List<string> { "song" };
        }

        string ICommandes.Help()
        {
            return "Get current sont info";
        }

        public List<UserType> IllegalUsers()
        {
            return new List<UserType>();
        }

        bool ICommandes.Action(
            JoinedChannel joinedChannel,
            TextBox prefixe,
            TwitchClient client,
            TwitchBotForm me,
            OnMessageReceivedArgs e
        )
        {
            var song = me.GetCurrentSong();
            client.SendMessage(joinedChannel.Channel,
                $"Current played song : {song.Name}{(me._songList.Contains(song) ? $" -- Request by {song.Requester}" : "")}");
            return true;
        }
    }
}