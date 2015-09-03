using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    interface ILogService
    {
        bool writeEventLog(AuditLog AL);

    }
}
