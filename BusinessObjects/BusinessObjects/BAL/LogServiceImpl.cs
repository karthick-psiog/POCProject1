using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DAL;
namespace BusinessObjects.BAL
{
    class LogServiceImpl:ILogService
    {
        public  bool writeEventLog(AuditLog AL)
            {
                DataStore.writeEventLog(AL);
                return true;
            }
    }
}
