using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp;
using Xunit;

namespace GildedRoseSystem.Tests
{

    public class GildedRoseTests
    {

        [Fact]
        public void UpdateQuality_WhenSellIn1Day_ShouldDecreaseByOne()
        {
            List<Item> items = CreateSingleItemList(itemName: "foo", quality: 50, sellIn: 1);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 49;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenSellIn0Day_ShouldDecreaseTwiceAsFast()
        {
            List<Item> items = CreateSingleItemList(itemName: "foo", quality: 50, sellIn: 0);
            csharp.GildedRose gildedRose = new csharp.GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 48;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenQualityIsZero_ShouldReturnZero()
        {
            List<Item> items = CreateSingleItemList(itemName: "foo", quality: 0, sellIn: 0);
            csharp.GildedRose gildedRose = new csharp.GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 0;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdatedQuality_WhenAgedBrie_ShouldIncrease()
        {
            var items = CreateSingleItemList(itemName: "Aged Brie", quality: 1, sellIn: 1);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 2;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdatedQuality_WhenAgedBrie_ShouldIncreaseTwiceAfterSelling()
        {
            var items = CreateSingleItemList(itemName: "Aged Brie", quality: 1, sellIn: 0);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 3;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdatedQuality_ShouldNotBeMoreThan50()
        {
            var items = CreateSingleItemList(itemName: "Aged Brie", quality: 50, sellIn: 1);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 50;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdatedQuality_WhenBackStagePasses_AndSellIn11_QualityIncreases()
        {
            var items = CreateSingleItemList(itemName: "Backstage passes to a TAFKAL80ETC concert", quality: 1, sellIn: 11);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 2;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdatedQuality_WhenBackStagePasses_AndSellIn10DaysOrLess_QualityIncreasesBy2()
        {
            var items = CreateSingleItemList(itemName: "Backstage passes to a TAFKAL80ETC concert", quality: 1, sellIn: 10);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 3;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdatedQuality_WhenBackStagePasses_AndSellIn6Days_QualityIncresesBy2()
        {
            var items = CreateSingleItemList(itemName: "Backstage passes to a TAFKAL80ETC concert", quality: 1, sellIn: 6);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 3;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdatedQuality_WhenBackStagePasses_AndSellIn5DaysOrLess_QualityIncresesBy3()
        {
            var items = CreateSingleItemList(itemName: "Backstage passes to a TAFKAL80ETC concert", quality: 1, sellIn: 5);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 4;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void UpdatedQuality_WhenBackStagePasses_QualityIsZeroAfterSell()
        {
            var items = CreateSingleItemList(itemName: "Backstage passes to a TAFKAL80ETC concert", quality: 1, sellIn: 0);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 0;
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_ShouldNeverDecreaseQuality()
        {
            var items = CreateSingleItemList(itemName: "Sulfuras, Hand of Ragnaros", quality: 10, sellIn: 0);
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            var expectedQuality = 10;
            Assert.Equal(expectedQuality, items[0].Quality);
        }



        private static List<Item> CreateSingleItemList(string itemName, int quality, int sellIn)
        {
            return new List<Item>() { new Item() { Name = itemName, Quality = quality, SellIn = sellIn } };
        }
    }
}
