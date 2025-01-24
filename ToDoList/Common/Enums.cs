namespace Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Enums
{
    public enum ResponsesID
    {
        Successful = 1,
        NotFound = 0,
        Error = -1,
        Exception = -2,
    }

    public enum Roles
    {
        Admin = 1,
        Standard = 2,
    }
}
