using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Models.JSON;
using Lab_3.Repo;

namespace Lab_3.Models.DTO
{
    internal class CollectedOrder
    {
        private Set set;
        private int sushiCount;
        private int sauceCount;

        private readonly AllSushi sushiRepo = AllSushi.getInstance();
        private readonly AllSauces sauceRepo = AllSauces.getInstance();

        public CollectedOrder(Set set, int sushiCount, int sauceCount)
        {
            this.set = set;
            this.sushiCount = sushiCount;
            this.sauceCount = sauceCount;
        }

        public Set GetSet()
        {
            return set;
        }

        public int GetSushiCount()
        {
            return sushiCount;
        }

        public int GetSauceCount()
        {
            return sauceCount;
        }

        public Sushi? GetSushi()
        {
            if (set != null)
            {
                return sushiRepo.GetById(set.Id);
            }

            return null;
        }

        public List<Sauces> GetSauces()
        {
            List<Sauces> list = new List<Sauces>();
            if (set != null && set.Sauces != null)
            {
                foreach (int sauceId in set.Sauces)
                {
                    Sauces? sauce = sauceRepo.GetById(sauceId);
                    if (sauce != null)
                    {
                        list.Add(sauce);
                    }
                }
            }

            return list;
        }

        public double GetDiscount()
        {
            switch (sushiCount)
            {
                case 10:
                    return 0.9;
                case 20:
                    return 0.8;
                case 30:
                    return 0.7;
                default:
                    return 0.0;
            }
        }

        public double GetPrice()
        {
            Sushi? sushi = GetSushi();
            double sushiPrice = 0.0;
            if (sushi != null)
            {
                sushiPrice = sushi.Price * sushiCount * GetDiscount();
            }
            double saucesPrice = 0.0;
            foreach (Sauces sauce in GetSauces())
            {
                saucesPrice += sauce.Price;
            }

            return sushiPrice + saucesPrice * sauceCount;
        }

        public Order GetModel()
        {
            return new Order()
            {
                set = set,
                sushiCount = sushiCount,
                sauceCount = sauceCount
            };
        }
    }
}
