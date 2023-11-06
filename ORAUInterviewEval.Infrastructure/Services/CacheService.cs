using ORAUInterviewEval.Core.Interfaces;

namespace ORAUInterviewEval.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        public Dictionary<int, string> GetPrograms()
        {
            var progs = new Dictionary<int, string>();
            progs.Add(1,"National School Lunch");
            progs.Add(2, "No Child Left Behind");
            progs.Add(3, "Head Start");
            progs.Add(99, "Other Program");
            
            return progs;
        }
    }
}
