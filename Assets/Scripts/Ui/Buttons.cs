using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ui.Game;
using Game;
using Game.Events.PlayerEvents;

public class Buttons : MonoBehaviour
{
    public int maxCountCards = 8;
    public void StartGame(int mode)
    {
        PlayerPrefs.SetInt("game_mode", mode);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewCard()
    {
        if (CardsContainer.Singleton.listCardBase.Count >= maxCountCards)
        {
            return;
        }
        CardsContainer.Singleton.SpawnCard();
        VillageController.Singleton.ProcessEventOrCard(new BuyCardEvent());
    }
}
