using UnityEngine;

public class BigWheelChange : MonoBehaviour
{
    public GameObject BrokenText;
    public GameObject RepairText;
    public GameObject EnterText;
    public GameObject SmallWheels;
    public GameObject BigWheels;
    public GameObject HasWheel;
    public GameObject CarCollider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CarCollider.SetActive(true);
        BrokenText.SetActive(false);
        RepairText.SetActive(false);
        SmallWheels.SetActive(true);
        BigWheels.SetActive(false);
        EnterText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SmallWheels.activeInHierarchy == true && HasWheel.activeInHierarchy == true)
            {
                BrokenText.SetActive(true);
            }
            if (HasWheel.activeInHierarchy == false)
            {
                RepairText.SetActive(true);

                if (Input.GetKey(KeyCode.F))
                {
                    SmallWheels.SetActive(false);
                    BigWheels.SetActive(true);
                    HasWheel.SetActive(true);
                    RepairText.SetActive(false);
                }
            }
            if (BigWheels.activeInHierarchy == true)
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
