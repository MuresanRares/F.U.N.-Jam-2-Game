using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    public GameObject PickUpText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickUpText.SetActive(false);
    }
    void OnTriggerStay()
    {
        PickUpText.SetActive(true);

        if (Input.GetKey(KeyCode.E))
        {
            this.gameObject.SetActive(false);

            PickUpText.SetActive(false);
        }
    }

    private void OnTriggerExit()
    {
        PickUpText.SetActive(false);
    }
}
