using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carryBox : MonoBehaviour
{
    private bool beingCarried;
    private bool canBeCarried;
    private BoxCollider2D boxcol;

    public BoxCollider2D pickUpRange;

    private Rigidbody2D carrierRB;
    private PlayerMovement carrierPM;
    private Rigidbody2D boxRB;

    // Start is called before the first frame update
    void Start()
    {
        beingCarried = false;

        boxRB = this.GetComponent<Rigidbody2D>();
        boxcol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beingCarried)
        {
            if (!carrierPM.isPlayerStopped())
            {
                boxRB.velocity = carrierRB.velocity;
            }
            else
            {
                boxRB.velocity = new Vector2(0, 0);
            }
        }
    }

    public Rigidbody2D getRB()
    {
        return boxRB;
    }

    public BoxCollider2D getBoxcol()
    {
        return boxcol;
    }

    public void CarryBox(Rigidbody2D playerRB, PlayerMovement playerPM)
    {
        beingCarried = true;
        carrierRB = playerRB;
        carrierPM = playerPM;
    }

    public void PutDownBox()
    {
        beingCarried = false;
        carrierRB = null;
        boxRB.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //carrier = collision.GetComponent<Rigidbody2D>();
        //canBeCarried = true;

        if (collision.GetComponent<PlayerMovement>() != null)
        {
            collision.GetComponent<PlayerMovement>().canCarryBox(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //carrier = null;
        //canBeCarried = false;
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            collision.GetComponent<PlayerMovement>().cannotCarryBox(this);
        }
    }

    public bool checkIfBeingCarried()
    {
        return beingCarried;
    }

    public void activateBoxMovement()
    {
        boxRB.bodyType = RigidbodyType2D.Dynamic;
        boxRB.drag = 0;
    }
    public void deactivateBoxMovement()
    {
        boxRB.bodyType = RigidbodyType2D.Static;
    }
}
