using UnityEngine;

public class RepairCar : MonoBehaviour
{
    public GameObject BrokenText;
    public GameObject RepairText;
    public GameObject EnterText;
    public GameObject MissingWheel;
    public GameObject HasWheel;
    public GameObject CarCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BrokenText.SetActive(false);
        RepairText.SetActive(false);
        MissingWheel.SetActive(false);
        EnterText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (HasWheel.activeInHierarchy == false)
            {
                RepairText.SetActive(true);

                if (Input.GetKey(KeyCode.F))
                {
                    MissingWheel.SetActive(true);
                    HasWheel.SetActive(true);
                    RepairText.SetActive(false);
                }
            }
            if (HasWheel.activeInHierarchy == true && MissingWheel.activeInHierarchy == false)
            {
                BrokenText.SetActive(true);
            }
            if (MissingWheel.activeInHierarchy == true)
            {
                EnterText.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    // add something like if press e then you enter car
                    // then is this
                    CarCollider.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit()
    {
        RepairText.SetActive(false);
        EnterText.SetActive(false);
        BrokenText.SetActive(false);
    }

}
