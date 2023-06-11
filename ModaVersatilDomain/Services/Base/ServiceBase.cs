using ModaVersatilDomain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Services.Base
{
    public class ServiceBase
    {
        public readonly IUnitOfWork UnitOfWork;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
