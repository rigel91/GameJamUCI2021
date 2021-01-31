using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class carryBox : MonoBehaviour
{
    public bool beingCarried;
    private bool canBeCarried;
    private BoxCollider2D boxcol;

    public BoxCollider2D pickUpRange;

    private Rigidbody2D carrier;
    //private Rigidbody2D carrierRB;
    private PlayerMovement carrierPM;
    private Rigidbody2D boxRB;

    private boxInfo boxData;
    [System.NonSerialized]
    public Canvas boxUI;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textAddressTo;
    public TextMeshProUGUI textAddressFrom;

    public float heightLimit;
    private bool tagShifted;
    public float shiftHeight = 70;

    // Start is called before the first frame update
    void Start()
    {
        beingCarried = false;
        boxRB = this.GetComponent<Rigidbody2D>();
        boxcol = GetComponent<BoxCollider2D>();

        boxData = GetComponent<boxInfo>();

        //gets the canvas from the boxes child
        boxUI = GetComponentInChildren<Canvas>();
        boxUI.enabled = false;

        tagShifted = false;
    }

    public void Set()
    {
        //boxUI.enabled = true;
        textName.text = boxData.GetName();
        textAddressTo.text = boxData.GetTo();
        textAddressFrom.text = boxData.GetFrom();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.T))
        {
            textName.text = boxData.CreateRandomName();
        }

        if (beingCarried)
        {
            if (!carrierPM.isPlayerStopped())
            {
                boxRB.velocity = carrier.velocity;
            }
            else
            {
                boxRB.velocity = new Vector2(0, 0);
            }

            shiftTagUI();
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

    public void CarryBox(Rigidbody2D player, PlayerMovement playerPM)
    {
        beingCarried = true;
        carrier = player;
        carrierPM = playerPM;
    }

    public void PutDownBox()
    {
        beingCarried = false;
        carrier = null;
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

    private void shiftTagUI()
    {
        //shifts tag UI's height to below the box when the box is above a certain height, or back up if there is room again
        if(boxRB.position.y > heightLimit)
        {
            if (!tagShifted)
            {
                boxUI.GetComponent<Transform>().position = new Vector3(boxUI.GetComponent<Transform>().position.x, boxUI.GetComponent<Transform>().position.y - shiftHeight, boxUI.GetComponent<Transform>().position.z);
                tagShifted = true;
            }
            
        }
        if (boxRB.position.y < heightLimit)
        {
            if (tagShifted)
            {
                boxUI.GetComponent<Transform>().position = new Vector3(boxUI.GetComponent<Transform>().position.x, boxUI.GetComponent<Transform>().position.y + shiftHeight, boxUI.GetComponent<Transform>().position.z);
                tagShifted = false;
            }
        }
        


    }
}
