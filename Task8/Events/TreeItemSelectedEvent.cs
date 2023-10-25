using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Events
{
    public class TreeItemSelectedEvent : PubSubEvent<object>
    {
    }
}
