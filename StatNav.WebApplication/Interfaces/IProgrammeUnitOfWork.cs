using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatNav.WebApplication.Interfaces
{
    public interface IProgrammeUnitOfWork : IDisposable
    {
        IProgrammeRepository ProgrammeRepository { get; }
        void Complete();
    }

}
