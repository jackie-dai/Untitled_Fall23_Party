using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("start interact  with " + other.tag);
        if (other.tag == "Lever")
        {
            Debug.Log("is Lever");
            Lever obj = other.gameObject.GetComponent<Lever>();
            Debug.Log("lever position: " + obj.transform.position);
            obj.Activate();
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