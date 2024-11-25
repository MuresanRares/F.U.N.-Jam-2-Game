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

    public GameObject Player;
    public GameObject CarCamera;
    public GameObject MissionTurnOff;
    public CarStatus carStatus;

    public bool inCar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool inCar = false;
        CarCollider.SetActive(true);
        BrokenText.SetActive(false);
        RepairText.SetActive(false);
        SmallWheels.SetActive(true);
        BigWheels.SetActive(false);
        EnterText.SetActive(false);

        if (carStatus == null)
        {
            carStatus = FindObjectOfType<CarStatus>();
            if (carStatus == null)
            {
                Debug.LogError("CarStatus script is not assigned and could not be found in the scene!");
            }
        }
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
                if (inCar == false)
                {
                    EnterText.SetActive(true);
                }
                if (Input.GetKey(KeyCode.E))
                {
                    Player.SetActive(false);
                    CarCamera.SetActive(true);
                    carStatus.inCar = true;
                    CarCollider.SetActive(false);
                    MissionTurnOff.SetActive(false);
                    EnterText.SetActive(false);
                    bool inCar = true;
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
