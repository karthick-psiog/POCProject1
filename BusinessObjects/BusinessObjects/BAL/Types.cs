using BusinessObjects.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    class EventTypeName
    {
     public   List<Dictionary<string, int>> EventType = new List<Dictionary<string, int>>();

        public EventTypeName() {
            EventType = DataStore.getEventTypes();
        }
    }

}
