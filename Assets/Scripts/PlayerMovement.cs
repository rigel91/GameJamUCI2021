using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    public string liftDropKey;
    public string readKey;

    private bool carryingBox;

    private carryBox carryableBox;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        carryingBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal, vertical directions
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horiz * speed, vert * speed);

        if (Input.GetKeyDown(liftDropKey))
        {
            if (carryingBox)
            {
                putDown();
            }
            else
            {
                pickUp();
            }
        }

        if (Input.GetKeyDown(readKey))
        {
            readBox();
        }
    }

    void FixedUpdate()
    {
        
    }

    private void pickUp()
    {
        if (carryableBox != null)
        {
            carryableBox.CarryBox(rb);
            carryingBox = true;
        }
    }

    private void putDown()
    {
        if (carryingBox == true)
        {
            carryableBox.PutDownBox();
            carryableBox = null;
            carryingBox = false;
        }
    }

    private void readBox()
    {
        print("read");
    }

    public void canCarryBox(carryBox box)
    {
        carryableBox = box;
    }

    public void cannotCarryBox(carryBox box)
    {
        if (carryingBox == false)
        {
            if (carryableBox == box)
            {
                carryableBox = null;
            }
        }
    }
}
