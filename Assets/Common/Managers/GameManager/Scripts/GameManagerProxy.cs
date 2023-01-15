using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProxy : MonoBehaviour
{
    public void SaveGame()
    {
        SavingController.instance.SaveGame();
    }

    public void LoadGame()
    {
        SavingController.instance.LoadGame();
    }

    public void NewGame()
    {
        SavingController.instance.NewGame();
    }
}
