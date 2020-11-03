using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    bool doorOpen;

    public GameObject Tooltip;

    private void Start()
    {
        Tooltip.SetActive(false);
        doorOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorOpen = true;
            Doors("Open");
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Tooltip.SetActive(true);
            Update();
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



}
