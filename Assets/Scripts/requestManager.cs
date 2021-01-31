using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class requestManager : MonoBehaviour
{
    private List<GameObject> requestedBoxes = new List<GameObject> { };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void requestBox(List<GameObject> boxes)
    {

        print(selectBoxInfoToRequest(boxes));

    }

    private string selectBoxInfoToRequest(List<GameObject> boxes)
    {
        int maxTrials = 100; //just a fail-safe in case i create an infinte while loop accidentally
        while (maxTrials > 0)
        {
            maxTrials -= 1;

            int boxIndex = Random.Range(0, boxes.Count); ;

            if (!requestedBoxes.Contains(boxes[boxIndex]))
            {
                requestedBoxes.Add(boxes[boxIndex]);

                //replace print with writing to a text box
                return (boxes[boxIndex].GetComponent<boxInfo>().mailBox[Random.Range(0, 2)]);
            }

        }

        return "BOX NOT FOUND";

    }

    public bool checkIfBoxHasBeenRequested(GameObject box)
    {
        //print(requestedBoxes.Contains(box));
        return requestedBoxes.Contains(box);
    }
}
