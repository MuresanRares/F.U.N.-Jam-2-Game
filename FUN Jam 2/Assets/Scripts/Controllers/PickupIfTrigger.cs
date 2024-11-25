using UnityEngine;

public class PickupIfTrigger : MonoBehaviour
{
    public GameObject UseItemText;
    public GameObject MissingItemText;
    public GameObject Stick;
    public GameObject BigHedgehog;
    public GameObject FalledHedgehog;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UseItemText.SetActive(false);
        MissingItemText.SetActive(false);
        BigHedgehog.SetActive(true);
        FalledHedgehog.SetActive(false);
    }
    void OnTriggerStay()
    {
        if (Stick.activeInHierarchy == true)
        {
            MissingItemText.SetActive(true);
        }
        if (Stick.activeInHierarchy == false && BigHedgehog.activeInHierarchy == true)
        {
            UseItemText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                BigHedgehog.SetActive(false);

                FalledHedgehog.SetActive(true);

                UseItemText.SetActive(false);
            }
        }    
    }

    private void OnTriggerExit()
    {
        UseItemText.SetActive(false);
        MissingItemText.SetActive(false);
    }
}
