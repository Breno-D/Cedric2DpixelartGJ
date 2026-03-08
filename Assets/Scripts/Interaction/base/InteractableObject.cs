using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerInteraction>().interactionTrigger.AddListener(Interact);
        }
    }

        void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerInteraction>().interactionTrigger.RemoveListener(Interact);
        }
    }

    virtual public void Interact()
    {
        Debug.Log("Teste não override");
    }
}
