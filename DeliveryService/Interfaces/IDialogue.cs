namespace DeliveryService.Interfaces
{
    public interface IDialogue
    {
        IStorable BusinessDialogue(IStorable storage);
        (IStorable, int) ClientDialogue(IStorable storage);
    }
}
