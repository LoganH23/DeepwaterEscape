using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] GameObject path1;
    [SerializeField] GameObject path2;
    [SerializeField] GameObject path3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(switchPaths());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator switchPaths()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if(path1.GetComponent<FollowPath>().getNode().isChargeNode)
            {
                int randPath = Random.Range(1, 3);

                if(randPath == 1)
                {
                    continue;
                }
                else
                {
                    path1.SetActive(false);
                
                    if(path1.GetComponent<FollowPath>().getNode().gameObject.name == "ChargeNode1")
                    {
                        path3.SetActive(true);
                        yield return new WaitForSeconds(2.5f);
                        path3.GetComponent<FollowPath>().resetNode();
                        path3.SetActive(false);
                        path1.SetActive(true);
                        path1.GetComponent<FollowPath>().setCurrentNode(3);
                    }
                    else if(path1.GetComponent<FollowPath>().getNode().gameObject.name == "ChargeNode2")
                    {
                        path2.SetActive(true);
                        yield return new WaitForSeconds(2.5f);
                        path2.GetComponent<FollowPath>().resetNode();
                        path2.SetActive(false);
                        path1.SetActive(true);
                        path1.GetComponent<FollowPath>().setCurrentNode(2);
                    }
                }

            }
           
            /*int randPath = Random.Range(1, 4);

            yield return new WaitForSeconds(Random.Range(5, 10));
            path1.SetActive(false);
            if(randPath == 1)
            {
                path1.SetActive(true);
            }
            else if(randPath == 2)
            {
                path2.SetActive(true);
            }
            else if(randPath == 3)
            {
                path3.SetActive(true);
            }
            yield return new WaitForSeconds(3);
            path1.SetActive(true);
            if (randPath == 2)
            {
                path2.SetActive(false);
            }
            else if (randPath == 3)
            {
                path3.SetActive(false);
            }*/
        }
    }
}
