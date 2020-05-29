using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private string greeting = "I am Sauron.";
    int level;  //  Game state
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;


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
    }

    private void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":
                level = 1;
                StartGame();
                break;

            case "2":
                level = 2;
                StartGame();
                break;

            case "3":
                level = 3;
                StartGame();
                break;            

            default:
                Terminal.WriteLine("If you don't know where to go, time to die!");
                ShowMainMenu(greeting);
                break;
        }
    }

    private void StartGame()
    {        
        currentScreen = Screen.Password;
        Terminal.WriteLine("Please enter the password: ");
    }
}
