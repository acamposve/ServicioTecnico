using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Infrastructure.Shared.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
