using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            Debug.Log("Box!");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            DestroyBox(collision);
        }
    }

    public void DestroyBox(Collider2D collision)
    {
            ScoreManager.instance.AddPoint();
            Destroy(collision.gameObject, 0.5f);
    }
}
