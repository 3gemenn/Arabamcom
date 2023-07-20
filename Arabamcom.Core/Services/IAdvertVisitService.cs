using Arabamcom.Core.DTOs;
using Arabamcom.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabamcom.Core.Services
{
    public interface IAdvertVisitService
    {
        Task<bool> Record(int id);
    }
}
