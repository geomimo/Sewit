using Sewit.Contracts;
using Sewit.Data;
using Sewit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IDressRepository _dressRepository;
        private readonly ITopComponentRepository _topComponentRepository;
        private readonly ISkirtComponentRepository _skirtComponentRepository;
        private readonly ISleeveComponentRepository _sleeveComponentRepository;


        public RecommendationService(IDressRepository dressRepository,
                                     ITopComponentRepository topComponentRepository,
                                     ISkirtComponentRepository skirtComponentRepository,
                                     ISleeveComponentRepository sleeveComponentRepository)
        {
            _dressRepository = dressRepository;
            _topComponentRepository = topComponentRepository;
            _skirtComponentRepository = skirtComponentRepository;
            _sleeveComponentRepository = sleeveComponentRepository;
        }

        private class DressDistance
        {
            public Dress Dress { get; set; }
            public int Distance { get; set; }
        }

        public List<Dress> RecommnedDresses(Dictionary<string, int> preferences, int dressId = -1)
        {
            var allDressses = _dressRepository.FindAll();
            var allTops = _topComponentRepository.FindAll();
            var allSkirts = _skirtComponentRepository.FindAll();
            var allSleeves = _sleeveComponentRepository.FindAll();

            var prefString = CreateBoolString(preferences, allTops, allSkirts, allSleeves);

            var distances = new List<DressDistance>();
            foreach (var dress in allDressses)
            {
                var categories = new Dictionary<string, int>()
                {
                    { "Top", dress.TopId },
                    { "Skirt", dress.SkirtId },
                    { "Sleeve", dress.SleeveId }
                };

                var boolString = CreateBoolString(categories, allTops, allSkirts, allSleeves);
                distances.Add(new DressDistance() { Dress = dress, Distance = HammingDist(prefString, boolString) });
            }

            if (dressId == -1)
            {
                return distances.OrderBy(d => d.Distance).Take(6).Select(d=>d.Dress).ToList();
            }

            distances = distances.Where(d=>d.Dress.DressId != dressId).OrderBy(d => d.Distance).Take(15).ToList();
            var random = new Random();
            var recommendations = new List<Dress>();

            int i = 0;
            while (true)
            {
                var index = random.Next(distances.Count);
                if (recommendations.Contains(distances[index].Dress))
                {
                    continue;
                }
                recommendations.Add(distances[index].Dress);
                i++;
                if (i == 6)
                {
                    break;
                }
            }

            return recommendations;
        }

       

        private string CreateBoolString(Dictionary<string, int> preferences, List<TopComponent> allTops, List<SkirtComponent> allSkirts, List<SleeveComponent> allSleeves)
        {
            var prefString = "";
            for (int i = 0; i < 4; i++)
            {
                if (allTops[i].TopId == preferences["Top"])
                {
                    prefString += "1";
                }
                else
                {
                    prefString += "0";
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (allSkirts[i].SkirtId == preferences["Skirt"])
                {
                    prefString += "1";
                }
                else
                {
                    prefString += "0";
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (allSleeves[i].SleeveId == preferences["Sleeve"])
                {
                    prefString += "1";
                }
                else
                {
                    prefString += "0";
                }
            }

            return prefString;
        }

        private int HammingDist(String str1,  String str2)
        {
            int i = 0, count = 0;
            while (i < str1.Length)
            {
                if (str1[i] != str2[i])
                    count++;
                i++;
            }
            return count;
        }
    }
}
