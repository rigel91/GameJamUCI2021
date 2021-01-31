using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float speed;
    public float maximumCarryReachDistance;

    public string liftDropKey;
    public string readKey;

    private bool carryingBox;
    

    private carryBox carryableBox;
    private BoxCollider2D carryableCollider;

    public Sprite downFacing;
    public Sprite upFacing;
    public Sprite rightFacing;
    public Sprite leftFacing;

    private bool playerIsStopped;
    private Vector2 previousPlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        previousPlayerPosition = rb.position;

        carryingBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal, vertical directions
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horiz * speed, vert * speed);

        if (carryingBox)
        {
            checkMaximumCarryReach();
        }
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
        if (carryingBox == false)
        {
            if (rb.velocity.y > 0)
            {
                sr.sprite = upFacing;
            }
            if (rb.velocity.y < 0)
            {
                sr.sprite = downFacing;
            }
            //if moving diagonally, prioritize right/left facing over up/down
            if (rb.velocity.x > 0)
            {
                sr.sprite = rightFacing;
            }
            if (rb.velocity.x < 0)
            {
                sr.sprite = leftFacing;
            }
        }
        

        if (Input.GetKeyDown(readKey))
        {
            readBox();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != carryableCollider)
        {
            playerIsStopped = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != carryableCollider)
        {
            playerIsStopped = false;
        }
    }

    public bool isPlayerStopped()
    {
        return playerIsStopped;
    }

    void FixedUpdate()
    {
        
    }

    private void pickUp()
    {
        if (carryableBox != null)
        {
            carryableBox.CarryBox(rb, this);
            carryingBox = true;
            carryableBox.activateBoxMovement();
        }
    }

    private void putDown()
    {
        if (carryingBox == true)
        {
            carryableBox.PutDownBox();
            carryingBox = false;
            carryableBox.deactivateBoxMovement();
        }
    }

    private void readBox()
    {
        if (carryableBox != null)
        {
            carryableBox.Set();
            if (carryableBox.boxUI.enabled == true)
            {
                carryableBox.boxUI.enabled = false;
            }
            else
            {
                carryableBox.boxUI.enabled = true;
            }
        }
        
    }

    private void checkMaximumCarryReach()
    {
        if (Mathf.Sqrt(Mathf.Pow(rb.position.x - carryableBox.getRB().position.x, 2) + Mathf.Pow(rb.position.y - carryableBox.getRB().position.y, 2)) > maximumCarryReachDistance)
        {
            putDown();
        }
    }

    public void canCarryBox(carryBox box)
    {
        if (!carryingBox)
        {
            carryableBox = box;
            carryableCollider = box.getBoxcol();
        }
    }

    public void cannotCarryBox(carryBox box)
    {
        if (carryingBox == false)
        {
            if (carryableBox == box)
            {
                carryableBox = null;
                carryableCollider = null;
            }
        }
    }

    public bool isCarryingBox()
    {
        return carryingBox;
    }

    public void forceDrop()
    {
        putDown();
    }
}
