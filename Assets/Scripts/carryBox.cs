using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class carryBox : MonoBehaviour
{
    private bool beingCarried;
    private bool canBeCarried;

    public BoxCollider2D pickUpRange;

    private Rigidbody2D carrier;
    private Rigidbody2D boxRB;

    private boxInfo boxData;
    [System.NonSerialized]
    public Canvas boxUI;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textAddressTo;
    public TextMeshProUGUI textAddressFrom;

    // Start is called before the first frame update
    void Start()
    {
        beingCarried = false;
        boxRB = this.GetComponent<Rigidbody2D>();

        boxData = GetComponent<boxInfo>();

        //gets the canvas from the boxes child
        boxUI = GetComponentInChildren<Canvas>();
        boxUI.enabled = false;
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
            boxRB.velocity = carrier.velocity;
        }
    }

    public void CarryBox(Rigidbody2D player)
    {
        beingCarried = true;
        carrier = player;
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
}
