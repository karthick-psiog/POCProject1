﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    class NotificationImpl:INotification
    {

     public bool notifyRemote(Customer customer)
        {
            return true;
        }
    }
}
