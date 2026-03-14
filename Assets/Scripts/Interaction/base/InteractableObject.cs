using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public string interactText;
    [SerializeField] TextMeshProUGUI uiText;
    public PlayerInput playerControls;

    public void Start()
    {
        playerControls = FindObjectOfType<PlayerInput>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerInteraction>().interactionTrigger.AddListener(Interact);
            other.GetComponent<PlayerInteraction>().RemoveEatListener();
            uiText.text = interactText;
        }
    }

        void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerInteraction>().interactionTrigger.RemoveListener(Interact);
            other.GetComponent<PlayerInteraction>().AddEatListener();
            uiText.text = "EAT";
        }
    }

    virtual public void Interact()
    {

    }

    public void UpdateInteractText()
    {
        uiText.text = interactText;
    }
}
