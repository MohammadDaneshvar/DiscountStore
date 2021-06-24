using NUnit.Framework;
using System.Collections.Generic;
using UnitTest.DataSamples;

namespace Application.UnitTests
{
    public static class ProductItemCaseSource
    {
        public static IEnumerable<TestCaseData> TestCase_Add_NewItem
        {
            get
            {
                yield return new TestCaseData(DataSample.Items[0],DataSample.Items)
                    .SetName("TestCase_Add_NewItem").SetDescription("Add new item to the Cart and check the number of product before and after adding");

            }
        }
        public static IEnumerable<TestCaseData> TestCase_Remove_Item
        {
            get
            {
                yield return new TestCaseData(DataSample.Items[0], DataSample.Items)
                    .SetName("TestCase_Remove_NewItem").SetDescription("Remove item in the Cart and check the number of product before and after removeing");

            }
        }
        public static IEnumerable<TestCaseData> TestCase_Item_With_2_Number_Of_BigMug
        {
            get
            {
                yield return new TestCaseData(DataSample.Get_Item_With_2_Number_Of_BigMug())
                    .SetName("Get_Items_With_2_Number_Of_BigMug").SetDescription("calculate items total with 2 number of BigMug");

            }
        }
        public static IEnumerable<TestCaseData> TestCase_Item_With_2_Number_Of_NapkinsPack
        {
            get
            {
                yield return new TestCaseData(DataSample.Get_Item_With_2_Number_Of_NapkinsPack())
                    .SetName("Get_Items_With_3Count_Of_Each_Product").SetDescription("calculate items total with 2 number of NapkinsPack");
            }
        }
        public static IEnumerable<TestCaseData> TestCase_Item_With_2_Number_Of_Vase
        {
            get
            {
                yield return new TestCaseData(DataSample.Get_Item_With_1_Number_Of_Vase())
                    .SetName("Get_Items_With_1_Number_Of_Each_Product").SetDescription("calculate items total with 1 number of Vase");
            }
        }

    }
}
