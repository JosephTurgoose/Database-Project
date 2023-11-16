using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Protobuf;

class Program
{

    // Set up dictionary
    static Dictionary<string, string> tasks = new Dictionary<string, string>();
    static int taskNumber = 1;

    static void Main(string[] args)
    {
        // Set up Firebase
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\21jtu\Desktop\My Stuff\School\CSE 310\Github\csharp_firebase_creds.json");
        var firebaseCredentials = GoogleCredential.FromFile(@"C:\Users\21jtu\Desktop\My Stuff\School\CSE 310\Github\csharp_firebase_creds.json");
        FirebaseApp.Create(new AppOptions{Credential = firebaseCredentials,});


        // Set up actions
        var input = "";
        while (input != "3")
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 - Add to To-Do list; 2 - Take away from To-Do list; 3 - Cancel");
            input = Console.ReadLine();

            if (input == "1")
            {
                AddToList();
                AddToFirebase();
                Console.WriteLine("Completed.");
            }
            else if (input == "2")
            {
                TakeFromList();
                AddToFirebase();
                Console.WriteLine("Completed.");
            }

        }
    }

    static void AddToList()
    {
        string answer = "0";
        Console.WriteLine("Type something to add to your To-Do List");
        Console.WriteLine("Type nothing to complete the list.");
        while (answer != "")
        {
            answer = Console.ReadLine().ToString();
            if (answer != "")
            {
                tasks.Add($"{taskNumber}", answer);
                taskNumber++;
            }
        }
    }

    static void TakeFromList()
    {
        Console.WriteLine("Which task would you like to remove from your To-Do list?");
        Console.WriteLine($"(Type a number from 1 through {taskNumber}).");
        int answer = int.Parse(Console.ReadLine());
        if (answer > 0 & answer <= taskNumber)
        {
            tasks.Remove($"{answer}"); // Remove selected item
        }
        taskNumber--;

        for (var i=0; i<tasks.Count; i++)
        {
            int updatedKey = int.Parse(tasks.ElementAt(i).Key) - 1;
            string ogValue = tasks.ElementAt(i).Value;
            if (int.Parse(tasks.ElementAt(i).Key) > answer)
            {
                tasks.Remove(tasks.ElementAt(i).Key);
                tasks.Add($"{updatedKey}", ogValue);
            }

        }
        
    }


    static void AddToFirebase()
    {
        // Reference to the firebase project
        FirestoreDb db = FirestoreDb.Create("database-project-62b1e");
        // Reference to the To-Do List collection
        CollectionReference collection = db.Collection("To-Do List");
        // Reference to the To-Do document
        DocumentReference document = collection.Document("To-Do");

        // Update the document with the dictionary data
        document.SetAsync(tasks).Wait();
    }
}