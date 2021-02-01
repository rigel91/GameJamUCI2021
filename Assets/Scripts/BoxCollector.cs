using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    private PlayerMovement player;

    public requestManager rg;

    public int boxCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
        rg = GameObject.FindGameObjectWithTag("requestGenerator").GetComponent<requestManager>();

        boxCount = 0;
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
            if (rg.checkIfBoxHasBeenRequested(collision.gameObject))
            {
                closeRequestForBox(collision.gameObject);
                DestroyBox(collision);
            }
            else
            {
                ScoreManager.instance.DeductPoints();
            }
        }
    }


    public void DestroyBox(Collider2D collision)
    {
        boxCount++;
        if (player.isCarryingBox())
        {
            player.forceDrop();
        }

        ScoreManager.instance.AddPoint();
        Destroy(collision.gameObject, 0.5f);
    }

    private void closeRequestForBox(GameObject box)
    {
        rg.closeRequest(box);
    }
}
