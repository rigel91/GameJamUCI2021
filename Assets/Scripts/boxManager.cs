using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxManager : MonoBehaviour
{
    public GameObject box;
    private Transform t;

    public string[] citiesList;
    public string[] streetsList;
    public string[] firstNamesList;
    public string[] lastNamesList;

    public Sprite[] boxSprites;

    [System.NonSerialized]
    public List<GameObject> boxList = new List<GameObject> { };

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

        GameObject newBox = (GameObject)Instantiate(box, t.position, Quaternion.identity);

        boxList.Add(newBox);
    }
 
}
