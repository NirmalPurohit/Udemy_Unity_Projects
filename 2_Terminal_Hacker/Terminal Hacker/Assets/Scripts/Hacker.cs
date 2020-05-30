using System;
using UnityEditor;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "You may type 'menu' at any time";
    string greeting = "I am Sauron.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "cops", "criminal", "uniform", "witness", "interogation" };
    string[] level3Passwords = { "space", "rocket", "astronaut", "fuel", "nasa", "orbit", "galaxy" };

    //  Game state
    private int level;
    private enum Screen { MainMenu, Password, Win };
    private Screen currentScreen;
    private string password;


    // Start is called before the first frame update
    void Start()
    {        
        ShowMainMenu(greeting);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Initial Menu on the terminal. The menu will give the player the option to choose difficulty level.
    /// </summary>
    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where is the Green Lantern Ring?");
        Terminal.WriteLine("1: Local Library\n2: Police Station\n3: NASA\n");
        Terminal.WriteLine("*Remember, not every place has the same level of Firewall protetion!\n");
        Terminal.WriteLine("So, where to now? ");        
       
    }
    
    /// <summary>
    /// The method will only handle the input, but will not run it.
    /// </summary>
    /// <param name="input">It will capture the characters ending with '\n'</param>
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu(greeting);
        }
        else if (input == "quit" || input == "close")
        {
            Terminal.WriteLine("If on the web, close the tab.")
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }      

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("If you don't know where to go, time to die!");
            Terminal.WriteLine("Or... " + menuHint);
        }       
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        SetRandomPassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter the password, hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;

            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;

            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;

            default:
                Debug.LogError("Invalid level entered, somehow!");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ________
   /       //
  /       //
 /______ //                
(_______(/
                ");
                break;

            case 2:
                Terminal.WriteLine("This is the evidence...");
                Terminal.WriteLine(@"
   _____
 _/ 008 \________
 |              |---
 |              | /
 |______________|/
                ");
                break;

            case 3:
                Terminal.WriteLine("Loading the rocket blueprint.....");
                Terminal.WriteLine(@"
   / \
 _/ N \_
/_| A |_\ 
 _| S |_
/ | A | \
| |___| |
|/-----\|
                ");
                break;

            default:
                Debug.LogError("Invalid level reached, somehow!");
                break;
        }
    }
}
