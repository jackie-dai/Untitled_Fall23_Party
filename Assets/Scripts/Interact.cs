using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    private PlayerController player;

    void Awake()
    {
        player = transform.parent.GetComponent<PlayerController>();
        if (player == null)
        {
            Debug.Log("Unable to find player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /* ADD NEW IF STATEMENT FOR EACH NEW INTERACTABLE ITEM */
        Debug.Log("start interact  with " + other.tag);
        if (other.tag == "Lever")
        {
            Debug.Log("is Lever");
            Lever obj = other.gameObject.GetComponent<Lever>();
            Debug.Log("lever position: " + obj.transform.position);
            obj.Activate();
        }

        if (other.tag == "Cannon")
        {
            Debug.Log("Yes, this is a cannon kind sir");
            Cannon obj = other.gameObject.GetComponent<Cannon>();
            obj.Activate();
            if (player.InCannonMode())
            {
                player.CannonModeOff();
            } else
            {
                player.CannonModeOn();
            }
        }
        if (other.tag == "NPC")
        {
            other.gameObject.GetComponent<Cat>().Activate();
            Debug.Log("Start dialogue with NPC");
        }
        if (other.tag == "Newspaper")
        {
            Newspaper obj = other.gameObject.GetComponent<Newspaper>();
            obj.Activate();
        }
        if (other.tag == "ClawBooth")
        {
            if (player.ReturnCoinAmount() > 0)
            {
                SceneManager.LoadScene("ClawMachine");
            }
            else
            {
                Debug.Log("Sorry it appears you are poor asf");
            }
            Debug.Log("Coin amount: " + player.ReturnCoinAmount());
        }

        if (other.tag == "Hangman")
        {
            SceneManager.LoadScene("Hangman");
        } 
        
            if (other.tag == "BalloonBooth")
        {
            SceneManager.LoadScene("Balloons");
        }
    }

   public void SwitchToRight()
    {
        transform.localPosition = new Vector3(1.0f, transform.localPosition.y, 0);
    }

    public void SwitchToLeft()
    {
        transform.localPosition = new Vector3(-1.0f, transform.localPosition.y, 0);
    }

    public void SwitchToForward()
    {
        transform.localPosition = new Vector3(0, transform.localPosition.y, -0.5f);
    }

    public void SwitchToBack()
    {
        transform.localPosition = new Vector3(0, transform.localPosition.y, 0.5f);
    }
}
