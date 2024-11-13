using System;
using System.Collections.Generic;

class RandomSentenceGenerator {
    static Random random = new Random();

    static void Main() {
        List<string> names = new List<string> { "Peter", "Michell", "Jane", "Steve", "Maria", "Ivan", "Yoan", "Georgy" };
        List<string> places = new List<string> { "Sofia", "Plovdiv", "Varna", "Burgas", "Blagoevgrad", "Ruse", "Stara Zagora", "Pleven" };
        List<string> verbs = new List<string> { "eats", "holds", "sees", "plays with", "brings", "writes", "draws", "jumps" };
        List<string> nouns = new List<string> { "stones", "cake", "apple", "laptop", "bikes", "book", "notebook", "laptop" };
        List<string> adverbs = new List<string> { "slowly", "diligently", "warmly", "sadly", "rapidly", "bravely", "happily", "quickly" };
        List<string> details = new List<string> { "near the river", "at home", "in the park", "in the library", "on the beach", "in the mountains", "at the mall", "in the office" };

        while (true) {
            printMenu();
            string command = Console.ReadLine();

            if (command == "0") {
                generateSentences(names, places, verbs, nouns, adverbs, details);
            } 
            else if (command == "1") {
                processUserAction(names, places, verbs, nouns, adverbs, details);
            } 
            else if (command.ToLower() == "q") {
                break;
            } 
            else {
                Console.WriteLine("Invalid option, please try again.");
            }
        }
    }

    static void printMenu() {
        Console.WriteLine("Welcome to the Random Sentence Generator");
        Console.WriteLine("Please choose one of the following options:");
        Console.WriteLine("  0: Generate random sentences.");
        Console.WriteLine("  1: Modify the sentence elements (add, insert, or delete).");
        Console.WriteLine("  Q: Exit");
    }

    static string getRandomWord(List<string> list) {
        return list[random.Next(0, list.Count)];
    }

    static string generateSentence(List<string> names, List<string> places, List<string> verbs, List<string> nouns, List<string> adverbs, List<string> details) {
        return $"{getRandomWord(names)} from {getRandomWord(places)} {getRandomWord(adverbs)} {getRandomWord(verbs)} {getRandomWord(nouns)} {getRandomWord(details)}.";
    }

    static void generateSentences(List<string> names, List<string> places, List<string> verbs, List<string> nouns, List<string> adverbs, List<string> details) {
        Console.WriteLine("Here is your randomly generated sentence:");
        while (true) {
            Console.WriteLine(generateSentence(names, places, verbs, nouns, adverbs, details));
            Console.WriteLine("Press [Enter] to generate another or 'q' to return to the menu.");
            if (Console.ReadLine().ToLower() == "q") break;
        }
    }

    static void processUserAction(List<string> names, List<string> places, List<string> verbs, List<string> nouns, List<string> adverbs, List<string> details) {
        Console.WriteLine("Choose one of the following actions: Add, Insert, or Delete.");
        string action = Console.ReadLine().Trim();

        if (action != "Add" && action != "Insert" && action != "Delete") {
            Console.WriteLine("Invalid action. Please try again.");
            return;
        }

        Console.WriteLine("Choose a category to modify (names, places, verbs, nouns, adverbs, details):");
        string category = Console.ReadLine().Trim().ToLower();

        List<string> listToModify = getCategoryList(category, names, places, verbs, nouns, adverbs, details);
        if (listToModify == null) {
            Console.WriteLine("Invalid category. Please try again.");
            return;
        }

        modifyList(listToModify, action);
    }

    static List<string> getCategoryList(string category, List<string> names, List<string> places, List<string> verbs, List<string> nouns, List<string> adverbs, List<string> details) {
        switch (category) {
            case "names": return names;
            case "places": return places;
            case "verbs": return verbs;
            case "nouns": return nouns;
            case "adverbs": return adverbs;
            case "details": return details;
            default: return null;
        }
    }

    static void modifyList(List<string> list, string action) {
        switch (action) {
            case "Add":
                Console.WriteLine("Enter the element to add:");
                string addElement = Console.ReadLine();
                if (!list.Contains(addElement)) {
                    list.Add(addElement);
                } 
                else {
                    Console.WriteLine("This element already exists.");
                }
            break;

            case "Insert":
                Console.WriteLine("Enter the element to insert:");
                string insertElement = Console.ReadLine();
                Console.WriteLine("Enter the position (0 to {0}):", list.Count);
                int position = int.Parse(Console.ReadLine());
                if (position >= 0 && position <= list.Count) {
                    list.Insert(position, insertElement);
                } 
                else {
                    Console.WriteLine("Invalid position.");
                }
            break;

            case "Delete":
                Console.WriteLine("Enter the element to delete:");
                string deleteElement = Console.ReadLine();
                if (list.Contains(deleteElement)) {
                    list.Remove(deleteElement);
                } 
                else {
                    Console.WriteLine("Element not found.");
                }
            break;
        }
    }
}
