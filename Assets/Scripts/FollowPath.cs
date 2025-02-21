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
    static Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        PathNode = GetComponentsInChildren<Node>();
        CheckNode();

        for(int i = 0; i < PathNode.Length - 1; i++)
        {
            PathNode[i].NodeIndex = i;
        }
    }

    void CheckNode()
    {
        timer = 0;
        currentPositionHolder = PathNode[currentNode].transform.position;
        startPosition = enemy.transform.position;
    }

    public Node getNode()
    {
        return PathNode[currentNode];
    }

    public void resetNode()
    {
        currentNode = 0;
    }

    public void setCurrentNode(int path)
    {
        if(path == 3)
        {
            currentNode = GameObject.Find("ChargeEndNode1").GetComponent<Node>().NodeIndex;
        }
        if(path == 2)
        {
            currentNode = GameObject.Find("ChargeEndNode2").GetComponent<Node>().NodeIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentNode);
        timer += Time.deltaTime * moveSpeed;
        if (enemy.transform.position != currentPositionHolder)
        {
            enemy.transform.position = Vector3.Lerp(startPosition, currentPositionHolder, timer);
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
