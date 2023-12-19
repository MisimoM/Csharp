using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AddressBookMaui.Messages
{
    public class UpdatedListMessage : ValueChangedMessage<string>
    {
        public UpdatedListMessage(string value) : base(value)
        {

        }
    }
}
