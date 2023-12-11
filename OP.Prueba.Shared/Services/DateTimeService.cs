using OP.Prueba.Application.Interfaces;

namespace OP.Prueba.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.Now;
    }
}
