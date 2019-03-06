using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public static TruckController Instance { get; private set; }
    Core testEngine;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        testEngine = Core.Instance;
        //StartCoroutine(MoveAllTrucks());
    }

    public IEnumerator MoveAllTrucks()
    {
        Debug.Log("in MoveAllTrucks");
        while (true)
        {
            //Debug.Log("m");
            for (int i = 0; i < testEngine.trucks.Length; i++)
            {
                //testEngine.trucks[i].transform.position = Vector3.SmoothDamp(testEngine.trucks[i].transform.position, testEngine.trucks[i].to, ref testEngine.trucks[i].velocity, 1f);
                
                if (Vector3.Distance(testEngine.trucks[i].transform.position, testEngine.trucks[i].to) > testEngine.trucks[i].speed * Time.deltaTime)
                {
                    testEngine.trucks[i].transform.position = Vector3.MoveTowards(testEngine.trucks[i].transform.position, testEngine.trucks[i].to, testEngine.trucks[i].speed * Time.deltaTime);
                }
            }
            yield return null;
        }
    }
}
