using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Node[] PathNode;
    public GameObject enemy;
    public float moveSpeed;
    float timer;
    int currentNode;
    static Vector3 currentPositionHolder;

    // Start is called before the first frame update
    void Start()
    {
        PathNode = GetComponentsInChildren<Node>();
        CheckNode();
    }

    void CheckNode()
    {
        timer = 0;
        currentPositionHolder = PathNode[currentNode].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentNode);
        timer += Time.deltaTime * moveSpeed;
        if (enemy.transform.position != currentPositionHolder)
        {
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, currentPositionHolder, timer);
        }
        else
        {
            if(currentNode < PathNode.Length - 1)
            {
                currentNode++;
                CheckNode();
            }
            else if(currentNode == PathNode.Length - 1)
            {
                currentNode = 0;
            }
        }
    }
}
