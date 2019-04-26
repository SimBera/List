using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Teltonika_Uzd {
	public class ListHandler {
		List<MyList> mainList = new List<MyList> ();
		public void generateData () {
			//Generae tst data
			MyList list1 = new MyList { displayName = "List1" };
			//Adding Items
			mainList.Add (list1);
			MyList list2 = mainList.Find (x => x.displayName.Equals ("List2"));
			list1.addItem ("List1", "List2", list1);
			list1.addItem ("List1", "List3", list1);
			list1.addItem ("List1", "List4", list1);
			list1.addItem ("List2", "SubList1", list2);
			list1.addItem ("List2", "SubList2", list2);
			list1.addItem ("List2", "SubList3", list2);
			list1.addItem ("List2", "SubList4", list2);
		}
		//Generate tst data end
		public void init (string input) {
			string[] parsedLine = parse (input);
			Switcher (parsedLine);
		}
		public string[] parse (string input) {
			string[] parsedLine = input.Split (" ");
			return parsedLine;
		}
		public void SortDown (List<MyList> mainList, string parsedLine1) {
			if (parsedLine1 == "main") {
				mainList.Sort (Comparer<MyList>.Create ((x, y) => -1 * x.displayName.CompareTo (y.displayName)));
			}
			foreach (MyList a in mainList) {
				a.sortListDecending (parsedLine1);
			}
		}
		public void SortUp (List<MyList> mainList, string parsedLine1) {
			if (parsedLine1 == "main") {
				mainList.Sort (Comparer<MyList>.Create ((x, y) => x.displayName.CompareTo (y.displayName)));
			} else {
				foreach (MyList a in mainList) {
					a.sortList (parsedLine1);
				}
			}
		}
		public void ReadItem (List<MyList> mainList, string parsedLine1) {
			if (parsedLine1 == "main") {
				foreach (MyList a in mainList) {
					Console.WriteLine (a.displayName);
				}
			} else {
				foreach (MyList a in mainList) {
					a.getList (parsedLine1);
				}
			}
		}
		public void AddNewItem (List<MyList> mainList, string parsedLine1, string parsedLine2) {
			if (parsedLine1 == "main") {
				//Console.WriteLine("Add sucsess");
				MyList list = new MyList ();
				list.displayName = parsedLine2;
				list.level = 0;
				list.parent = new MyList ();
				list.parent.displayName = "costomMade";
				mainList.Add (list);
				printTree ();
			} else {
				foreach (MyList a in mainList) {
					a.addItem (parsedLine1, parsedLine2, a);
				}
			}
		}
		public void update (List<MyList> mainList, string oldName, string newName) {
			mainList.Where (x => x.displayName == oldName).ToList ().ForEach (s => s.displayName = newName);
			foreach (MyList a in mainList) {
				a.update (oldName, newName);
			}
		}
		public void DeleteItem (List<MyList> mainList, string parsedLine1) {
			foreach (MyList a in mainList) {
				if (a.displayName == parsedLine1) {
					mainList.Remove (a);
				} else { a.delete (parsedLine1); }
			}
		}
		public void printTree () {
			Console.Clear ();
			foreach (MyList a in mainList) {
				a.printAll ();
			}
		}
		public void Place (List<MyList> mainList, string parsedLine1, string parsedLine2) {
			int deletionIndex = -1;
			int relocateIndex = -1;
			MyList parentObject = null;
			MyList relocateObject = null;
			foreach (MyList a in mainList) {
				if (parentObject == null) {
					parentObject = a.parentObject (parsedLine1);
				}

				if (relocateObject == null) {
					relocateObject = a.relocate (parsedLine1, null);
				}
				if (relocateIndex == -1) {
					relocateIndex = a.relocateIndex (parsedLine2, -3);
				}
				//if (deletionIndex == -1) {
				//			deletionIndex = a.deletionIndex (parsedLine1, -3);
				//}
			}
			if (parentObject != null || relocateObject != null || relocateIndex > 0) {
				relocateObject.parent.mainList.Remove (relocateObject);
				parentObject.mainList.Insert (relocateIndex, relocateObject);

			} else { Console.WriteLine ("Objects not found"); }

			deletionIndex = -1;
			relocateIndex = -1;
			parentObject = null;
			relocateObject = null;
			//	relocateObject.parent.mainList.Remove (relocateObject);
		}
		public void Help () {
			Console.WriteLine ("add <parentListName>(default 'main') <newListName> - creates an new item in the list");
			Console.WriteLine ("read <listName> - reads parameters of the object");
			Console.WriteLine ("delete <listName> - deletes an object");
			Console.WriteLine ("sortup <listName> - sorts the list up alphabetically");
			Console.WriteLine ("sortdown <listName> - sorts the list down alphabetically");
			Console.WriteLine ("place <listName> <destination listName> - plases firt list to second list's place");
			Console.WriteLine ("tree - prints a List tree");
		}
		public void Switcher (string[] parsedLine) {
			switch (parsedLine[0]) {
				case "add": // add <listName>(main adds to main list) <addString>
					AddNewItem (mainList, parsedLine[1], parsedLine[2]);
					printTree ();
					init (Console.ReadLine ());
					break;
				case "read":
					Console.Clear ();
					ReadItem (mainList, parsedLine[1]);
					init (Console.ReadLine ());
					break;
				case "update":
					//Console.WriteLine ("update sucsess");
					update (mainList, parsedLine[1], parsedLine[2]);
					printTree ();
					init (Console.ReadLine ());
					break;
				case "delete":
					DeleteItem (mainList, parsedLine[1]);
					printTree ();
					//Console.WriteLine("delete sucsess");
					init (Console.ReadLine ());
					break;
				case "?":
					Help ();
					init (Console.ReadLine ());
					break;
				case "tree":
					printTree ();
					init (Console.ReadLine ());
					break;
				case "sortup":
					SortUp (mainList, parsedLine[1]);
					printTree ();
					init (Console.ReadLine ());
					break;
				case "sortdown":
					SortDown (mainList, parsedLine[1]);
					printTree ();
					init (Console.ReadLine ());
					break;
				case "place":
					Place (mainList, parsedLine[1], parsedLine[2]);
					printTree ();
					init (Console.ReadLine ());
					break;
				case "gener":
					generateData ();
					printTree ();
					init (Console.ReadLine ());
					break;
				default:
					Console.WriteLine ("Ender Valid command");
					Console.WriteLine ("For command list type ?");
					init (Console.ReadLine ());
					break;
			}
		}
	}
}