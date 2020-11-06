using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    bool doorOpen;
    public GameObject Tooltip;
    public bool IsDoorOpen => doorOpen;

    private void Start()
    {
        Tooltip.SetActive(false);
        doorOpen = false;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Tooltip.SetActive(true);
            StartCoroutine(CheckCo());
        }
        else if (coll.gameObject.tag == "Agent")
        {
            doorOpen = true;
            Doors("Open");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        Tooltip.SetActive(false);
        if (doorOpen)
        {
            doorOpen = false;
            Doors("Close");
        }
    }

    void Doors(string direction)
    {
        animator.SetTrigger(direction);
    }

    IEnumerator CheckCo() 
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                doorOpen = true;
                Doors("Open");
                break;
            }
            yield return null;
        }
    }

}
