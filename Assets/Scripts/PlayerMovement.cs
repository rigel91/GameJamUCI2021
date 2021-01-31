﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float speed;

    public string liftDropKey;
    public string readKey;

    private bool carryingBox;

    private carryBox carryableBox;

    public Sprite downFacing;
    public Sprite upFacing;
    public Sprite rightFacing;
    public Sprite leftFacing;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        carryingBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //rotate player sprite based on key input for player movement
        //needs to be updated if we ever switch off of WASD to move
        if (Input.GetKeyDown("w"))
        {
            sr.sprite = upFacing;
        }
        if (Input.GetKeyDown("a"))
        {
            sr.sprite = leftFacing;
        }
        if (Input.GetKeyDown("s"))
        {
            sr.sprite = downFacing;
        }
        if (Input.GetKeyDown("d"))
        {
            sr.sprite = rightFacing;
        }
        */


        //horizontal, vertical directions
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horiz * speed, vert * speed);


        if (carryingBox == false)
        {
            if (rb.velocity.y < 0)
            {
                sr.sprite = downFacing;
            }
            if (rb.velocity.y > 0)
            {
                sr.sprite = upFacing;
            }
            //if moving diagonally, chose to prioritize right/left facing over up/down
            if (rb.velocity.x > 0)
            {
                sr.sprite = rightFacing;
            }
            if (rb.velocity.x < 0)
            {
                sr.sprite = leftFacing;
            }
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
