using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Helpers
{
    public static class GetObjectResult
    {
        public static T GetValue<T>(this ActionResult<T> result)
        {
            if (result.Result != null)
                return (T)((ObjectResult)result.Result).Value;
            return result.Value;
        }

    }
}
