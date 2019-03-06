using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public static Core Instance { get; private set; }
    /*[SerializeField]
    GameObject[] trucksObjects;*/
    [SerializeField]
    GameObject waypoint;
    int score;
    [HideInInspector]
    public TruckController truckController;
    public IEnumerator truckControllerCoroutine;

    [SerializeField]
    public Truck[] trucks;

    GameTick gameTick;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        truckController = TruckController.Instance;
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        yield return StartCoroutine(InitGame());
        yield return StartCoroutine(PlayGame());
        yield return StartCoroutine(ExitGame());
    }

    IEnumerator InitGame()
    {
        /*trucks = new Truck[trucksObjects.Length];
        for (int i = 0; i < trucksObjects.Length; i++)
        {
            trucks[i] = trucksObjects[i].GetComponentInChildren<Truck>();
        }*/
        Debug.Log("init'ed");
        yield return null;
    }

    IEnumerator PlayGame()
    {
        gameTick = new GameTick();

        //---
        while (score != 10)
        {
            Debug.Log(score);
            //   simple invoke without return?? and all drawing here??
            yield return StartCoroutine(gameTick.Calc());
            //yield return null;
        }
    }

    IEnumerator ExitGame()
    {
        Debug.Log("exit'ed");
        yield return null;
    }

    public void IncrScore()
    {
        score++;
    }
}
