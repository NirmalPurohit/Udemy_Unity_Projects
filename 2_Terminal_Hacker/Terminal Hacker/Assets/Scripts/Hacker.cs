using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private string greeting = "I am Sauron.";

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
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where is the Green Lantern Ring?");
        Terminal.WriteLine("1: Local Library\n2: Police Station\n3: NASA\n");
        Terminal.WriteLine("*Remember, not every place has the same level of Firewall protetion!\n");
        Terminal.WriteLine("So, where to now? ");        
       
    }
    
    /// <summary>
    /// Prints the the characters entered by the user on the terminal after hitting return.
    /// </summary>
    /// <param name="input">It will capture the characters ending with '\n'</param>
    void OnUserInput(string input)
    {        
        switch(input)
        {
            case "1":
                Terminal.WriteLine(input);
                break;

            case "2":
                Terminal.WriteLine(input);
                break;

            case "3":
                Terminal.WriteLine(input);
                break;

            case "menu":
                ShowMainMenu(greeting);
                break;

            default:
                Terminal.WriteLine("If you don't know where to go, time to die!");
                ShowMainMenu(greeting);
                break;
        }
    }
}
