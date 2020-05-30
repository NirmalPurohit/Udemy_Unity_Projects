using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    private string greeting = "I am Sauron.";
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "cops", "criminal", "uniform", "witness", "interogation" };
    string[] level3Passwords = { "space", "rocket", "atronaut", "fuel", "nasa", "orbit", "galaxy" };

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
            StartGame();
        }
        else
        {
            Terminal.WriteLine("If you don't know where to go, time to die!");            
        }       
    }

    void StartGame()
    {        
        currentScreen = Screen.Password;        
        switch (level)
        {
            case 1:
                password = level1Passwords[3];  //  TODO: make random                
                break;

            case 2:
                password = level2Passwords[4];  //  TODO: make random                
                break;

            case 3:
                password = level3Passwords[1];  //  TODO: make random                
                break;

            default:
                Debug.LogError("Invalid level entered, somehow!");                
                break;
        }
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter the password: ");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            Terminal.WriteLine("Oops, wrong password");
        }
    }

    void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.WriteLine("You won!");
    }
}
