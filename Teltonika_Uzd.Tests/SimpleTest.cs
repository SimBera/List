using System;
using Teltonika_Uzd;
using Xunit;

namespace Prime.UnitTests.Services {
    public class SimpleTest {
        private readonly MyList _MyList;

        #region Sample_TestCode
        [Fact]
        public void ReturnTrue_AddListsToList1 () {
            MyList list1 = new MyList { displayName = "List1" };
            MyList list2 = new MyList { displayName = "List2" };
            MyList list3 = new MyList { displayName = "List3" };
            MyList list4 = new MyList { displayName = "List4" };
            MyList subList1 = new MyList { displayName = "SubList1" };
            MyList subList2 = new MyList { displayName = "SubList2" };
            MyList subList3 = new MyList { displayName = "SubList3" };
            MyList subList4 = new MyList { displayName = "SubList4" };
            //Adding Items
            list1.addItem (list1.displayName, list2.displayName, list1);
            list1.addItem (list1.displayName, list3.displayName, list1);
            list1.addItem (list1.displayName, list4.displayName, list1);
            //Test1
            bool result1 = list1.mainList[0].displayName.Equals (list2.displayName);
            string firstItem = list1.mainList[0].displayName;
            string addedItem = list2.displayName;
            Assert.True (result1, $" {firstItem} == {addedItem}?? list2");
            //Test2
            result1 = list1.mainList[1].displayName.Equals (list3.displayName);
            firstItem = list1.mainList[1].displayName;
            addedItem = list3.displayName;
            Assert.True (result1, $" {firstItem} == {addedItem}?? list3");
            //Test3
            result1 = list1.mainList[2].displayName.Equals (list4.displayName);
            firstItem = list1.mainList[2].displayName;
            addedItem = list4.displayName;
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list4");
        }

        [Fact]
        public void ReturnTrue_BuildingATree () {
            // MyList list1 = new MyList { displayName = "List1" };
            // MyList list2 = new MyList { displayName = "List2" };
            // MyList list3 = new MyList { displayName = "List3" };
            // MyList list4 = new MyList { displayName = "List4" };
            // MyList subList1 = new MyList { displayName = "SubList1" };
            // MyList subList2 = new MyList { displayName = "SubList2" };
            // MyList subList3 = new MyList { displayName = "SubList3" };
            // MyList subList4 = new MyList { displayName = "SubList4" };
            MyList mainList1 = new MyList { displayName = "MainList" };
            string list1 = "List1";
            string list2 = "List2";
            string list3 = "List3";
            string list4 = "List4";
            string subList1 = "subList1";
            string subList2 = "subList2";
            string subList3 = "subList3";
            string subList4 = "subList4";

            /*
            Generating Tree
            MainList1
                List1
                List2
                    SubList1
                    SubList2
                    SubList3
                    SubList4
                List3
                List4
             */
            //Adding Items
            
            mainList1.addItem (mainList1.displayName, list1, mainList1);
            mainList1.addItem (mainList1.displayName, list2, mainList1);
            mainList1.addItem (mainList1.displayName, list3, mainList1);
            mainList1.addItem (mainList1.displayName, list4, mainList1);

            mainList1.addItem (mainList1.mainList[1].displayName, subList1, mainList1.mainList[1]);
            mainList1.addItem (mainList1.mainList[1].displayName, subList2, mainList1.mainList[1]);
            mainList1.addItem (mainList1.mainList[1].displayName, subList3, mainList1.mainList[1]);
            mainList1.addItem (mainList1.mainList[1].displayName, subList4, mainList1.mainList[1]);
            //mainList1Tree Test
            //Test1
            bool result1 = mainList1.mainList[0].displayName.Equals (list1);
            string firstItem = mainList1.mainList[0].displayName;
            string addedItem = list1;
            Assert.True (result1, $" {firstItem} == {addedItem}?? list1");
            //Test2
            result1 = mainList1.mainList[1].displayName.Equals (list2);
            firstItem = mainList1.mainList[1].displayName;
            addedItem = list2;
            Assert.True (result1, $" {firstItem} == {addedItem}?? list2");
            //Test3
            result1 = mainList1.mainList[2].displayName.Equals (list3);
            firstItem = mainList1.mainList[2].displayName;
            addedItem = list3;
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list3");
            //Test4
            firstItem = mainList1.mainList[1].mainList[0].displayName;
            result1 = firstItem.Equals (subList1);
            addedItem = subList1;
            Assert.True (result1, $"{firstItem} == {addedItem} ?? subList1");
            //Test5
            firstItem = mainList1.mainList[1].mainList[1].displayName;
            addedItem = subList2;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? subList2");
            //Test6
            firstItem = mainList1.mainList[1].mainList[2].displayName;
            addedItem = subList3;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? subList3");
            //Test7
            firstItem = mainList1.mainList[1].mainList[3].displayName;
            addedItem = subList4;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? subList4");
            //Parent Test 1
            firstItem = mainList1.displayName;
            addedItem = mainList1.mainList[0].parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? MainList Parent");
            //Parent Test 2
            firstItem = mainList1.displayName;
            addedItem = mainList1.mainList[1].parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? MainList Parent");
            //Parent Test 3
            firstItem = mainList1.displayName;
            addedItem = mainList1.mainList[2].parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? MainList Parent");
            //SubParent Test 1
            firstItem = list2;
            addedItem = mainList1.mainList[1].mainList[0].parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list2 Parent");
            //SubParent Test 2
            firstItem = list2;
            addedItem = mainList1.mainList[1].mainList[1].parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list2 Parent");
            //SubParent Test 3
            firstItem = list2;
            addedItem = mainList1.mainList[1].mainList[2].parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list2 Parent");
            //SubParent Test 4
            firstItem = list2;
            addedItem = mainList1.mainList[1].mainList[3].parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list2 Parent");

        }
        #endregion

    }
}