using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace csharp
{
    public class GildedRose
    {
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        readonly IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateQualityItem(item);
            }
        }

        private void UpdateQualityItem(Item item)
        {
            if (item.Name == Sulfuras || item.Quality <= 0)
            {
                return;
            }

            if ((item.Name == Backstage || item.Name == AgedBrie) && item.Quality >= 50)
            {
                return;
            }
            if (item.Name == Backstage && item.SellIn <= 0)
            {
                item.Quality = 0;
                return;
            }
            if (item.Name == AgedBrie && item.SellIn <= 0)
            {
                item.Quality = item.Quality + 2;
                return;
            }

            if (item.Name != AgedBrie && item.Name != Backstage)
            {
                item.Quality = item.Quality - 1;
            }
            else
            {
                item.Quality = item.Quality + 1;

                if (item.Name == Backstage)
                {
                    if (item.SellIn < 11)
                    {
                        item.Quality = item.Quality + 1;
                    }

                    if (item.SellIn < 6)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }
}
