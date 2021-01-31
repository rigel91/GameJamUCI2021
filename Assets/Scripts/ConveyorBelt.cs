using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            if (collision.GetComponent<carryBox>() != null)
            {
                collision.GetComponent<carryBox>().activateBoxMovement();
            }
            collision.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<carryBox>() != null)
        {
            if (collision.GetComponent<carryBox>().checkIfBeingCarried() == false)
            {
                if (collision.GetComponent<carryBox>() != null)
                {
                    collision.GetComponent<carryBox>().deactivateBoxMovement();
                }
                collision.GetComponent<carryBox>().PutDownBox();
            }
        }

    }
}
