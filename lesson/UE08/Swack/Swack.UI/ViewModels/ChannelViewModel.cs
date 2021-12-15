using Swack.Logic;
using Swack.Logic.Models;
using System.Collections.ObjectModel;

namespace Swack.UI.ViewModels
{
    public class ChannelViewModel : ViewModelBase
    {
        private readonly Channel channel;
        private int unreadMessages;


        public ChannelViewModel(Channel channel)
        {
            this.channel = channel ?? throw new System.ArgumentNullException(nameof(channel));
        }

        public string Name
        {
            get { return channel.Name; }
        }

        public ObservableCollection<Message> Messages { get; } = new();

        public int UnreadMessages
        {
            get => unreadMessages;
            set => Set(ref unreadMessages, value);
        }
    }
}
