using System.Collections.Generic;

namespace Ninjathulhu.Game.Events
{
    public class EventBus
    {
        private List<IEvent> _events;

        public EventListener MakeListener()
        {
            return null;
        }
    }

    public class EventListener
    {
        private List<IEvent> _buffer;
        private int _lastId;
    }
}