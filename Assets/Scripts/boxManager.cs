using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxManager : MonoBehaviour
{
    public GameObject box;

    private Transform t;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBox()
    {
        print("spawn box");

        Instantiate(box, t.position, Quaternion.identity);



    }
}
