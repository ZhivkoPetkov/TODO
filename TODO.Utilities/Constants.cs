using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Utilities
{
    public static class Constants
    {
        public static string databaseName = "todo-db" + DateTime.UtcNow.DayOfYear;
    }
}
