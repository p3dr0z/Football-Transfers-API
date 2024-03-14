namespace FootballTransfersAPI.Data.Services.Interfaces.Messaging
{
    public interface IMessageProducerService
    {
        void ProduceMessage<T>(T message);
    }
}
