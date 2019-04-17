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
            MyList list1 = new MyList { displayName = "List1" };
            MyList list2 = new MyList { displayName = "List2" };
            MyList list3 = new MyList { displayName = "List3" };
            MyList list4 = new MyList { displayName = "List4" };
            MyList subList1 = new MyList { displayName = "SubList1" };
            MyList subList2 = new MyList { displayName = "SubList2" };
            MyList subList3 = new MyList { displayName = "SubList3" };
            MyList subList4 = new MyList { displayName = "SubList4" };

            /*
            Generating Tree
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
            list1.addItem (list1.displayName, list2.displayName, list1);
            list1.addItem (list1.displayName, list3.displayName, list1);
            list1.addItem (list1.displayName, list4.displayName, list1);

            list2.addItem (list2.displayName, subList1.displayName, list2);
            list2.addItem (list2.displayName, subList2.displayName, list2);
            list2.addItem (list2.displayName, subList3.displayName, list2);
            list2.addItem (list2.displayName, subList4.displayName, list2);
            //Tree Test
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
            //Test4
            firstItem = list2.mainList[0].displayName;
            result1 = firstItem.Equals (subList1.displayName);
            addedItem = subList1.displayName;
            Assert.True (result1, $"{firstItem} == {addedItem} ?? subList1");
            //Test5
            firstItem = list2.mainList[1].displayName;
            addedItem = subList2.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? subList2");
            //Test6
            firstItem = list2.mainList[2].displayName;
            addedItem = subList3.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? subList3");
            //Test7
            firstItem = list2.mainList[3].displayName;
            addedItem = subList4.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? subList4");
            //Parent Test 1
            firstItem = list1.displayName;
            addedItem = list2.parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list1 Parent");
            //Parent Test 2
            firstItem = list1.displayName;
            addedItem = list3.parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list1 Parent");
            //Parent Test 3
            firstItem = list1.displayName;
            addedItem = list4.parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list1 Parent");
            //SubParent Test 1
            firstItem = list2.displayName;
            addedItem = subList1.parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list2 Parent");
            //SubParent Test 2
            firstItem = list2.displayName;
            addedItem = subList2.parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list2 Parent");
            //SubParent Test 3
            firstItem = list2.displayName;
            addedItem = subList3.parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list2 Parent");
            //SubParent Test 4
            firstItem = list2.displayName;
            addedItem = subList4.parent.displayName;
            result1 = firstItem.Equals (addedItem);
            Assert.True (result1, $"{firstItem} == {addedItem} ?? list2 Parent");

        }
        #endregion

    }
}