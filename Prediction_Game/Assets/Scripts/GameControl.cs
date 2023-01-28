using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{ 
    private int minNumber = 1;

    private int maxNumber = 100;

    private int predictionNumber;

    private bool GameStarted = false;

    private bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        print("Do you want to play with me? (Y/N)");
    }

    // Update is called once per frame
    void Update()
    {
        #region Starting of the Game
        
        if (!GameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Y)) { print("Great! Pick a number between 1 and 100, type it and press enter!"); }
            else if (Input.GetKeyDown(KeyCode.N)) { print("Whatever you say.."); }

            if (Input.GetKeyDown(KeyCode.Return)) // User presses enter, game starts..
            {
                Control();
                GameStarted = true;
            }
        }
        
        #endregion
        
        #region Game

        else if (!gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) // If prediction is greater than user's pick
            {
                minNumber = predictionNumber;
                Control();
            }else if (Input.GetKeyDown(KeyCode.DownArrow)) // If prediction is lower than user's pick
            {
                maxNumber = predictionNumber;
                Control();
            }else if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Yahoo! I found it! :)");
                gameEnded = true;
            }
        }

        #endregion
        
    }

    void Control()
    {
        predictionNumber = (minNumber + maxNumber) / 2;
        print("Is this the number you picked -> " + predictionNumber + "? If it is greater than your number press up if not press down, if true press space!");
    }
}
