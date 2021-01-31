using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class displayOpenRequests : MonoBehaviour
{
    //public requestManager rm;

    private List<string> openRequestsList = new List<string> { };
    private List<GameObject> openTextBoxesList = new List<GameObject> { };

    public float textBoxDisplaySpawnX;
    public float baseTextBoxDisplaySpawnY;

    public GameObject requestTextBoxPrefab;
    private Canvas requestCanvas;

    public float heightGapBetweenRequests = 30f;


    // Start is called before the first frame update
    void Start()
    {
        requestCanvas = GameObject.FindGameObjectWithTag("requestCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openRequest(string req)
    {
        print("new request");
        if (!checkRequestIsOpen(req))
        {
            print("test");
            GameObject newReqTextBox = Instantiate(requestTextBoxPrefab);
            newReqTextBox.transform.SetParent(requestCanvas.transform, false);

            openRequestsList.Add(req);
            openTextBoxesList.Add(newReqTextBox);

            updateDisplay();
        }
    }

    public void closeRequest(string req)
    {
        
        GameObject objectToDestroy = null;

        if (checkRequestIsOpen(req))
        {
            print("test that closeRequest is called");

            //find which req is being closed
            foreach (GameObject g in openTextBoxesList)
            {
                if (req == g.GetComponent<TextMeshProUGUI>().text)
                {
                    objectToDestroy = g;
                    break;
                }
            }

            openTextBoxesList.Remove(objectToDestroy);
            openRequestsList.Remove(objectToDestroy.GetComponent<TextMeshProUGUI>().text);

            Destroy(objectToDestroy);
            
            updateDisplay();
        }
    }

    private bool checkRequestIsOpen(string req)
    {
        //return openRequestsList.Contains(req);

        foreach (string existingReq in openRequestsList)
        {
            if (existingReq == req)
            {
                return true;
            }
        }

        return false;
    }

    private void updateDisplay()
    {
        int reqIndex = 0;
        foreach (GameObject tmpbox in openTextBoxesList)
        {
            //places the textBoxes in the list, aligned horizontally and spaced out vertically
            tmpbox.GetComponent<Transform>().position = new Vector2(textBoxDisplaySpawnX, baseTextBoxDisplaySpawnY - (heightGapBetweenRequests * reqIndex));
            tmpbox.GetComponent<TextMeshProUGUI>().text = openRequestsList[reqIndex];

            reqIndex += 1;
        }
    }
}
