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
			MyList parentObject = null;
			MyList relocateObject = null;
			string consolieLine = input;
			string[] parsedLine = consolieLine.Split (" ");
			switch (parsedLine[0]) {
				case "add": // add <listName>(main adds to main list) <addString>
					if (parsedLine[1] == "main") {
						//Console.WriteLine("Add sucsess");
						MyList list = new MyList ();
						list.displayName = parsedLine[2];
						list.level = 0;
						list.parent = new MyList ();
						list.parent.displayName = "costomMade";
						mainList.Add (list);
						printTree ();
					} else {
						foreach (MyList a in mainList) {
							a.addItem (parsedLine[1], parsedLine[2], a);
						}
					}
					printTree ();
					init (Console.ReadLine ());
					break;
				case "read":
					Console.Clear ();
					//Console.WriteLine("read sucsess");
					if (parsedLine[1] == "main") {
						foreach (MyList a in mainList) {
							Console.WriteLine (a.displayName);
						}
					} else {
						foreach (MyList a in mainList) {
							a.getList (parsedLine[1]);
						}
					}
					//printTree();
					init (Console.ReadLine ());
					break;
				case "update":
					//Console.WriteLine ("update sucsess");
					mainList.Where (x => x.displayName == parsedLine[1]).ToList ().ForEach (s => s.displayName = parsedLine[2]); //.ToList()
					foreach (MyList a in mainList) {
						a.update (parsedLine[1], parsedLine[2]);
					}
					printTree ();
					init (Console.ReadLine ());
					break;
				case "delete":
					foreach (MyList a in mainList) {
						if (a.displayName == parsedLine[1]) {
							mainList.Remove (a);
						} else { a.delete (parsedLine[1]); }
					}
					printTree ();
					//Console.WriteLine("delete sucsess");
					init (Console.ReadLine ());
					break;
				case "?":
					Console.WriteLine ("add <parentListName>(default 'main') <newListName> - creates an new item in the list");
					Console.WriteLine ("read <listName> - reads parameters of the object");
					Console.WriteLine ("delete <listName> - deletes an object");
					Console.WriteLine ("sortup <listName> - sorts the list up alphabetically");
					Console.WriteLine ("sortdown <listName> - sorts the list down alphabetically");
					Console.WriteLine ("place <listName> <destination listName> - plases firt list to second list's place");
					Console.WriteLine ("tree - prints a List tree");
					init (Console.ReadLine ());
					break;
				case "tree":
					printTree ();
					init (Console.ReadLine ());
					break;
				case "sortup":
					if (parsedLine[1] == "main") {
						mainList.Sort (Comparer<MyList>.Create ((x, y) => x.displayName.CompareTo (y.displayName)));
					} else {
						foreach (MyList a in mainList) {
							a.sortList (parsedLine[1]);
						}
					}
					printTree ();
					init (Console.ReadLine ());
					break;
				case "sortdown":
					if (parsedLine[1] == "main") {
						mainList.Sort (Comparer<MyList>.Create ((x, y) => -1 * x.displayName.CompareTo (y.displayName)));
					}
					foreach (MyList a in mainList) {
						a.sortListDecending (parsedLine[1]);
					}
					printTree ();
					init (Console.ReadLine ());
					break;
				case "place":
					int destIndex = -1;
					int relocateIndex = -1;
					 
				foreach (MyList a in mainList)
				{

					if (parentObject == null) {
						parentObject = a.parentObject(parsedLine[1]);
					}
					if (destIndex == -1) {
						destIndex = a.destinationIndex(parsedLine[1]);
					} 
					if (relocateObject == null) {
						relocateObject = a.relocate(parsedLine[2]);
					}
					if (relocateIndex == -1) {
						relocateIndex = a.relocateIndex(parsedLine[2]);
					}
				}
				if(destIndex>0 &&relocateIndex>0){
					Console.WriteLine( "parent object name "+parentObject.displayName);
					Console.WriteLine( "Destination index "+destIndex);
					Console.WriteLine( "RElocationobject ame "+relocateObject.displayName);
					Console.WriteLine( "reLocate index "+relocateIndex);
					init (Console.ReadLine ());
				}else{Console.WriteLine("Indexes not found");
					Console.WriteLine( "parent object name "+parentObject.displayName);
					Console.WriteLine( "Destination index "+destIndex);
					Console.WriteLine( "RElocationobject ame "+relocateObject.displayName);
					Console.WriteLine( "reLocate index "+relocateIndex);
					init (Console.ReadLine ());
				}
				
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
		public void printTree () {
			Console.Clear ();
			foreach (MyList a in mainList) {
				a.printAll ();
			}
		}

	}

}