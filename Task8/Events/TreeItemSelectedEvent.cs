using Prism.Events;
using Task8.Data.Entity;

namespace Task8.Events
{
    public class TreeItemSelectedEvent : PubSubEvent<DbEntity>
    {
    }
}
