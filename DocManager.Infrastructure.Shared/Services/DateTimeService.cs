using ServicioTecnico.Infrastructure.Shared.Interfaces;
using System;

namespace ServicioTecnico.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
