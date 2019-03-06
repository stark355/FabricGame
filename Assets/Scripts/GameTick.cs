using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTick
{
    IUpdate[] updates;
    Core testEngine;

    public GameTick()
    {
        testEngine = Core.Instance;
    }

    public IEnumerator Calc()
    {
        //blablablah calculate here - new targets to trucks and update money and stocks amount

        updates = testEngine.trucks;
        float time1 = Time.time;
        for (int i = 0; i < updates.Length; i++)
        {
            updates[i].ItemUpdate();
        }

        testEngine.truckControllerCoroutine = testEngine.truckController.MoveAllTrucks();
        testEngine.truckController.StartCoroutine(testEngine.truckControllerCoroutine);

        float time2 = Time.time;
        //Debug.Log(time2 - time1);
        //передавать в параметр updateItem разницу с прошлого кадра
        yield return new WaitForSeconds(1 - Time.deltaTime);
        if (testEngine.truckControllerCoroutine != null)
        {
            testEngine.truckController.StopCoroutine(testEngine.truckControllerCoroutine);
        }
        testEngine.IncrScore();
    }

}
