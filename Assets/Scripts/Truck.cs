using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour, IUpdate
{
    Vector3 startPosition;
    Vector3 endPosition;
    [SerializeField]
    GameObject waypoint;
    public float speed = 10f;
    int capacity = 10;
    int currentCapacity = 20;

    [HideInInspector]
    public Vector3 to;
    [HideInInspector]
    public Vector3 from;

    // Start is called before the first frame update
    void Start()
    {

        //   startposition don't have to be transform.position, but have to be A (to B)
        startPosition = transform.position;
        endPosition = waypoint.transform.position;
    }

    bool tempFlag;

    void IUpdate.ItemUpdate()
    {
        //построить путь, если уже есть - то проверить валиден ли он
        if (!tempFlag)
        {
            from = startPosition;
            to = endPosition;
        }
        else
        {
            from = endPosition;
            to = startPosition;
        }
        transform.LookAt(to);
        tempFlag = !tempFlag;

        
    }

    [HideInInspector]
    public Vector3 velocity = Vector3.zero;
}
