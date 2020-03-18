using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataInit : MonoBehaviour
{
    public GameDatabase gamedatabase;
    public GameDatabase gamedatabaseInGame;

    public GameDatabase gameDataInitial;

    // Start is called before the first frame update
    void Start()
    {
        InitGameDataBase();
    }

    private void InitGameDataBase()
    {
        //gamedatabase.playersInGame.Add()

        gamedatabaseInGame = Instantiate(gamedatabase);
        //FillData();
    }

    //private void FillData()
    //{
    //    foreach (Player player in gameDataInitial.playersInGame)
    //    {
    //        gamedatabaseInGame.playersInGame.Add(player);
    //    }

    //    foreach (Team team in gameDataInitial.teamsInGame)
    //    {
    //        gamedatabaseInGame.teamsInGame.Add(team);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
