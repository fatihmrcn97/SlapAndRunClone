using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private GameObject wayPoint;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 6.0f;

    public bool shouldFollow;

    private float makeItSlower=.75f;

    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("Player");
        shouldFollow = false;
    }

    void Update()
    {
        if (!LevelManager.instance.gameFlow)
            return;
        if (!shouldFollow)
            return;
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime*makeItSlower);

    }
    
    public IEnumerator waitForFollow()
    {
        yield return new WaitForSeconds(2);
        shouldFollow = true;
    }


}
