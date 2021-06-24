using Application.UnitTests;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serviece.CartServices;
using Servieces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTest.DataSamples;

namespace Test
{
    public class Tests
    {
        private ICartService _cartService;
        private IServiceProvider _serviceProvider;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.ConfigureServices();
            _serviceProvider = services.BuildServiceProvider();
            _cartService = _serviceProvider.GetService<ICartService>();
        }

        [TestCaseSource(typeof(ProductItemCaseSource), nameof(ProductItemCaseSource.TestCase_Add_NewItem))]
        public void Test_Number_Of_Items_After_Adding_New_Item(Item item, List<Item> items)
        {
            foreach (var productItem in items)
            {
                _cartService.Add(new Item(productItem.Product,productItem.Count));
            }
            _cartService.Add(item);
            var countOfAllProductInItemsBeforAddNewItem = items.Sum(x => x.Count);
            var countOfAllProductInItemsAfterAddNewItem = _cartService.GetItems().Sum(x => x.Count);
            var countOfAllProductInItem = item.Count;
            Assert.AreEqual(countOfAllProductInItemsBeforAddNewItem + countOfAllProductInItem, countOfAllProductInItemsAfterAddNewItem);
        }
        [TestCaseSource(typeof(ProductItemCaseSource), nameof(ProductItemCaseSource.TestCase_Remove_Item))]
        public void Test_Number_Of_Items_After_Removing_Item(Item item ,List<Item> items)
        {
            foreach (var productItem in items)
            {
                _cartService.Add(new Item(productItem.Product, productItem.Count));
            }
            _cartService.Remove(item);
            var countOfAllProductInItemsBeforRemoveItem = items.Sum(x => x.Count);
            var countOfAllProductInItemsAfterRemoveItem = _cartService.GetItems().Sum(x => x.Count);
            var countOfAllProductInItem = item.Count;
            Assert.AreEqual(countOfAllProductInItemsBeforRemoveItem- countOfAllProductInItem, countOfAllProductInItemsAfterRemoveItem);
        }
        [TestCaseSource(typeof(ProductItemCaseSource), nameof(ProductItemCaseSource.TestCase_Item_With_2_Number_Of_BigMug))]
        public void BigMugDiscount_Calculate_Test(Item productItem)
        {
            _cartService.Add(productItem);
            var totalFromServie = _cartService.GetTotal();
            var bigMugDiscount = new BigMugDiscount();
            var discountPercent = bigMugDiscount.countableDiscount.FirstOrDefault(c => c.min <= productItem.Count && c.max > productItem.Count).percent;
            var total = productItem.Count * productItem.Product.Price * discountPercent;
            Assert.AreEqual(totalFromServie, total);
        }
        [TestCaseSource(typeof(ProductItemCaseSource), nameof(ProductItemCaseSource.TestCase_Item_With_2_Number_Of_NapkinsPack))]
        public void NapkinsPack_Discount_Calculate_Test(Item productItem)
        {
            _cartService.Add(productItem);
            var totalFromServie = _cartService.GetTotal();
            var napkinspackDiscount = new NapkinspackDiscount();
            var discountPercent = napkinspackDiscount.countableDiscount.FirstOrDefault(c => c.min <= productItem.Count && c.max > productItem.Count).percent;
            var total = productItem.Count * productItem.Product.Price * discountPercent;
            Assert.AreEqual(totalFromServie, total);
        }
        [TestCaseSource(typeof(ProductItemCaseSource), nameof(ProductItemCaseSource.TestCase_Item_With_2_Number_Of_Vase))]
        public void Vase_Discount_Calculate_Test(Item productItem)
        {
            _cartService.Add(productItem);
            var totalFromServie = _cartService.GetTotal();
            var vaseDiscount = new VaseDiscount();
            var discountPercent = vaseDiscount.countableDiscount.FirstOrDefault(c => c.min <= productItem.Count && c.max > productItem.Count).percent;
            var total = productItem.Count * productItem.Product.Price * discountPercent;
            Assert.AreEqual(totalFromServie, total);
        }
    }
}