using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] private Transform teleportDestination;
    [SerializeField] private GameObject objectToTeleport;

    private CharacterController controller;

    private void Start()
    {
        controller = objectToTeleport.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToTeleport)
        {
            Debug.Log(objectToTeleport.name + " detected at trigger, teleporting to " + teleportDestination.position);
            
            TeleportPlayer();

            Debug.Log(objectToTeleport.name + " teleported to " + teleportDestination.position);
        }
    }

    private void TeleportPlayer()
    {
        if (controller != null)
        {
            controller.enabled = false;
            objectToTeleport.transform.position = teleportDestination.position;
            controller.enabled = true;
        }
        else
        {
            objectToTeleport.transform.position = teleportDestination.position;
        }
    }
}