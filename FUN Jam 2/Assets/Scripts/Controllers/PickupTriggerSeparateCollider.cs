using UnityEngine;

public class PickupTriggerSeparateCollider : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject Item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickUpText.SetActive(false);
        Item.SetActive(true);
    }
    void OnTriggerStay()
    {
        PickUpText.SetActive(true);

        if (Input.GetKey(KeyCode.E))
        {
            this.gameObject.SetActive(false);
            Item.SetActive(false);

            PickUpText.SetActive(false);
        }
    }

    private void OnTriggerExit()
    {
        PickUpText.SetActive(false);
    }
}
