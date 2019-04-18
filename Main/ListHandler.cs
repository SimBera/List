using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Teltonika_Uzd {
	public class ListHandler {
		List<MyList> mainList = new List<MyList> ();
		public void init (string input) {
			parsedLine = parse(input);
			Switcher (parsedLine);
		}
		public string parse (string input) {
			string[] parsedLine = input.Split (" ");
			return parsedLine;
		}
		public void Switcher (string[] parstedLine) {
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
				default:
					Console.WriteLine ("Ender Valid command");
					Console.WriteLine ("For command list type ?");
					init (Console.ReadLine ());
					break;
			}
		}
		public void Place (List<MyList> mainList, string parsedLine1, string parsedLine2) {
			int destIndex = -1;
			int relocateIndex = -1;
			MyList parentObject = null;
			MyList relocateObject = null;
			foreach (MyList a in mainList) {

				if (parentObject == null) {
					parentObject = a.parentObject (parsedLine1);
				}
				if (destIndex == -1) {
					destIndex = a.destinationIndex (parsedLine1);
				}
				if (relocateObject == null) {
					relocateObject = a.relocate (parsedLine2);
				}
				if (relocateIndex == -1) {
					relocateIndex = a.relocateIndex (parsedLine2);
				}
			}
			if (destIndex > 0 && relocateIndex > 0) {
				Console.WriteLine ("parent object name " + parentObject.displayName);
				Console.WriteLine ("Destination index " + destIndex);
				Console.WriteLine ("RElocationobject ame " + relocateObject.displayName);
				Console.WriteLine ("reLocate index " + relocateIndex);
				init (Console.ReadLine ());
			} else {
				Console.WriteLine ("Indexes not found");
				Console.WriteLine ("parent object name " + parentObject.displayName);
				Console.WriteLine ("Destination index " + destIndex);
				Console.WriteLine ("RElocationobject ame " + relocateObject.displayName);
				Console.WriteLine ("reLocate index " + relocateIndex);
				init (Console.ReadLine ());
			}
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
		public void Help () {
			Console.WriteLine ("add <parentListName>(default 'main') <newListName> - creates an new item in the list");
			Console.WriteLine ("read <listName> - reads parameters of the object");
			Console.WriteLine ("delete <listName> - deletes an object");
			Console.WriteLine ("sortup <listName> - sorts the list up alphabetically");
			Console.WriteLine ("sortdown <listName> - sorts the list down alphabetically");
			Console.WriteLine ("place <listName> <destination listName> - plases firt list to second list's place");
			Console.WriteLine ("tree - prints a List tree");
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

	}

}