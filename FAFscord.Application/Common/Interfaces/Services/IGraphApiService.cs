using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Common.Interfaces.Services
{
    public interface IGraphApiService
    {
        Task<User> GetUserDetails();
    }
}
