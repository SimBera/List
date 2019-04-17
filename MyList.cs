using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teltonika_Uzd {
	public class MyList {
		public List<MyList> mainList = new List<MyList> ();
		public string displayName { get; set; }
		public MyList parent { get; set; }
		public int level { get; set; }
		public int possition { get; set; }
		public void addItem (string name, string newName, MyList newParent) {
			if (displayName == name) {
				MyList list = new MyList ();
				list.displayName = newName;
				list.parent = newParent;
				list.level = level + 1;
				mainList.Add (list);
			} else {
				foreach (MyList a in mainList) {
					a.addItem (name, newName, a);
				}
			}
		}
		public void getList (string name) {
			if (displayName == name) {
				Console.WriteLine ("Name: " + displayName);
				Console.WriteLine ("Parent list: " + parent.displayName);
				Console.WriteLine ("Level: " + level);
				Console.WriteLine ("Items in the list:");
				foreach (MyList a in mainList) {
					Console.WriteLine ("  " + a.displayName);
				}
			} else {
				foreach (MyList a in mainList) {
					a.getList (name);
				}
			}
		}
		public void delete (string name) {

			mainList.RemoveAll (x => x.displayName == name);
			foreach (MyList a in mainList) {
				a.delete (name);
			}
		}
		public void printAll () {
			string tabulator = "";
			for (int i = 0; i < level; i++) {
				tabulator = "  " + tabulator;
			}
			Console.WriteLine (tabulator + displayName);
			foreach (MyList a in mainList) {
				a.printAll ();
			}
		}
		public void update (string name, string newName) {
			mainList.Where (x => x.displayName == name).ToList ().ForEach (s => s.displayName = newName);
			foreach (MyList a in mainList) {
				a.update (name, newName);
			}
		}
		public void sortList (string name) {
			if (displayName == name) {
				mainList.Sort (Comparer<MyList>.Create ((x, y) => x.displayName.CompareTo (y.displayName)));
			} else {
				foreach (MyList a in mainList) {
					a.sortList (name);
				}
			}
		}
		public void sortListDecending (string name) {
			if (displayName == name) {
				mainList.Sort (Comparer<MyList>.Create ((x, y) => -1 * x.displayName.CompareTo (y.displayName)));
			} else {
				foreach (MyList a in mainList) {
					a.sortListDecending (name);
				}
			}
		}
		public MyList parentObject (string name) {
			if (string.Equals(displayName, name)) {
				return parent;
			} else {
				foreach (MyList a in mainList) {
					if (a != null) { return a; } else {
						return a.parentObject (name);
					}
				}
			}
			return null;
		}
		public int destinationIndex (string name) {
			int indexr = -3;
			foreach (MyList a in mainList) {
				if (string.Equals(a.displayName, name)) {
					indexr = mainList.IndexOf (a);
					return mainList.IndexOf (a);
				} else {
					if (indexr > -1) { return indexr; } else {
						return a.destinationIndex (name);
					}
				}
			}
			return -1;
		}
		public MyList relocate (string name) {
			foreach (MyList a in mainList) {
				if (string.Equals(a.displayName, name)) {
					return a;
				} else {
					if (a != null) {
						return a;
					} else {
						return a.relocate (name);
					}
				}
			}
			return null;
		}
		public int relocateIndex (string name) {
			int indexr = -3;
			foreach (MyList a in mainList) {
				if (string.Equals(a.displayName, name)) {
					indexr = mainList.IndexOf (a);
					return mainList.IndexOf (a);
				} else {
					if (indexr > -1) {
						return indexr;

					} else {
						return a.relocateIndex (name);
					}
				}
			}
			return -1;
		}

		        public bool IsPrime(int candidate) 
        { 
            if (candidate < 2) 
            { 
                return false; 
            }

            for (var divisor = 2; divisor <= Math.Sqrt(candidate); divisor++) 
            { 
                if (candidate % divisor == 0) 
                { 
                    return false; 
                } 
            } 
            return true;  
        } 
    }

	}
