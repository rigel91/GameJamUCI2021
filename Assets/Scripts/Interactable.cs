using UnityEngine.UI;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f; //Distance of interaction
    bool isFocus = false;
    public Transform player;
    public GameObject boxTag;
    

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= radius)
            OnFocused();
        else
            OnDefocused();

        if (isFocus)
        {
            //Debug.Log("INTERACT");
            //Any animation pop-ups or some sort of interaction queue happens here (use tags).
            boxTag.SetActive(true);
        }
        else
            boxTag.SetActive(false); //Defocused.
        
       
        
    }
    //Visual representation of interaction radius
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    public void OnFocused ()
    {
         isFocus = true;
    }

    public void OnDefocused()
    {
         isFocus = false;
    }
}
