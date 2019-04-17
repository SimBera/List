using System;
using System.Collections.Generic;
using Teltonika_Uzd;
using Xunit;

namespace Prime.UnitTests.Services {
    // public class DataGenerator : IEnumerable<object[]> {
        
    //     private readonly List<object[]> _data = new List<object[]> {

    //         new MyList { displayName = "List1" },
    //         new MyList { displayName = "List2" },
    //         new MyList { displayName = "List3" },
    //         new MyList { displayName = "List4" },
    //         new MyList { displayName = "SubList1" },
    //         new MyList { displayName = "SubList2" },
    //         new MyList { displayName = "SubList3" },
    //         new MyList { displayName = "SubList4" }
    //     };

    //     public IEnumerator<object[]> GetEnumerator () { return _data.GetEnumerator (); }
    //     IEnumerator IEnumerable.GetEnumerator () { return GetEnumerator (); }

    

    // #region Sample_TestCode
    // [Theory]
    // [ClassData (typeof(DataGenerator))]
    // public void TreeCreated_WithDataGenerator (MyList list1, MyList list2, MyList list3, MyList list4) {

    //     list1.addItem (list1.displayName, list2.displayName, list1);
    //     list1.addItem (list1.displayName, list3.displayName, list1);
    //     list1.addItem (list1.displayName, list4.displayName, list1);

    //     bool result1 = Equals (list1.mainList[0].displayName, list2.displayName);
    //     string firstItem = list1.mainList[0].displayName;
    //     string addedItem = list2.displayName;

    //     Assert.True (result1, $"Main List first Item {firstItem} and addedItem {addedItem} ");

    //     result1 = Equals (list1.mainList[1].displayName, list3.displayName);
    //     firstItem = list1.mainList[1].displayName;
    //     addedItem = list3.displayName;

    //     Assert.True (result1, $"Main List first Item {firstItem} and addedItem {addedItem} ");

    //     result1 = Equals (list1.mainList[2].displayName, list3.displayName);
    //     firstItem = list1.mainList[2].displayName;
    //     addedItem = list4.displayName;

    //     Assert.True (result1, $"Main List first Item {firstItem} and addedItem {addedItem} ");

    // }
    // #endregion
    // }
}