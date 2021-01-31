using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
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
        if (player.isCarryingBox())
        {
            player.forceDrop();
        }

        ScoreManager.instance.AddPoint();
        Destroy(collision.gameObject, 0.5f);
    }
}
