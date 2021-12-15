using Swack.Logic;
using Swack.Logic.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Swack.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessagingLogic messagingLogic;

        public MainViewModel(IMessagingLogic messagingLogic)
        {
            this.messagingLogic = messagingLogic ?? throw new System.ArgumentNullException(nameof(messagingLogic));
            this.messagingLogic.MessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(Message message)
        {
            var channel = Channels.FirstOrDefault(c => message.Channel.Name == c.Name);
            if (channel is not null)
            {
                channel.Messages.Add(message);
                channel.UnreadMessages++;
            }

        }

        public async Task InitializeAsync()
        {
            foreach (var channel in await messagingLogic.GetChannelsAsync())
            {
                Channels.Add(new ChannelViewModel(channel));
            }
        }

        public ObservableCollection<ChannelViewModel> Channels { get; private set; } = new();

        private ChannelViewModel currentChannel;
        public ChannelViewModel CurrentChannel
        {
            get { return currentChannel; }
            set
            {
                Set(ref currentChannel, value);
                currentChannel.UnreadMessages = 0;
            }
        }
    }
}
