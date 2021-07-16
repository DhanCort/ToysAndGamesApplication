using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGames.Models
{
    public class ResponseModel
    {
        public int Status { get; set; } = 200;
        public string Message { get; set; } = "Success";
        public Object Products { get; set; } = null;
    }
}
