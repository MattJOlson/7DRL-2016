namespace Ninjathulhu.Game.Events
{
    public interface IEvent
    {
        int SequenceId { get; }
        void PassTo(Component component);
    }
}
