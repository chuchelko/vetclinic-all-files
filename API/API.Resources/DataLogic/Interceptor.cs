namespace API.Resources.DataLogic
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore.Diagnostics;

    public class Interceptor : DbCommandInterceptor
    {
        public override DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
        {
            Console.WriteLine(result.CommandText);
            return result;
        }

    }
}
