using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] GameObject path1;
    [SerializeField] GameObject path2;

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
        yield return new WaitForSeconds(Random.Range(5, 10));
        path1.SetActive(false);
        path2.SetActive(true);
        yield return new WaitForSeconds(3);
        path1.SetActive(true);
        path2.SetActive(false);
    }
}
