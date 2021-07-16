using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Models;

namespace ToysAndGames.Contracts
{
    public interface IResponse
    {
        ResponseModel Response();
    }
}
