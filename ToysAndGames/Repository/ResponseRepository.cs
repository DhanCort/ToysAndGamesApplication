using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Contracts;
using ToysAndGames.Models;

namespace ToysAndGames.Repository
{
    public class ResponseRepository : IResponse
    {
        public ResponseModel Response()
        {
            return new ResponseModel();
        }
    }
}
