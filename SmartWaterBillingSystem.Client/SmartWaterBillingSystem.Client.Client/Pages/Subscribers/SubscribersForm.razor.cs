namespace SmartWaterBillingSystem.Client.Client.Pages.Subscribers
{
    public partial class SubscribersForm()
    {
        private List<SubscriberClientDto> _subscribers = [];

        private void HandleSubscriberFound(SubscriberClientDto subscriber)
        {
            _subscribers.RemoveAll(S => S.PersonalIDNumber == subscriber.PersonalIDNumber);
            _subscribers.Insert(0, subscriber);
        }

        private void HandleSubscriberCreated(SubscriberClientDto create) => _subscribers.Insert(0, create);

        private void HandleSubscriberDeleted(string personalIDNumber) => _subscribers.RemoveAll(S => S.PersonalIDNumber == personalIDNumber);
    }
}
