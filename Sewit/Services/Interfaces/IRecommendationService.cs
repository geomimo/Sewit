using Sewit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Services.Interfaces
{
    public interface IRecommendationService
    {
        public List<Dress> RecommnedDresses(Dictionary<string, int> preferences);
    }
}
