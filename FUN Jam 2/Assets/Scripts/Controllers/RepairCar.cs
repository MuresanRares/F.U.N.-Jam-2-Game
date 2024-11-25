using UnityEngine;

public class RepairCar : MonoBehaviour
{
    public GameObject BrokenText;
    public GameObject RepairText;
    public GameObject EnterText;
    public GameObject MissingWheel;
    public GameObject HasWheel;
    public GameObject CarCollider;

    public GameObject Player;
    public GameObject CarCamera;
    public GameObject MissionTurnOff;
    public CarStatus carStatus;

    public bool inCar;

    void Start()
    {
        BrokenText.SetActive(false);
        RepairText.SetActive(false);
        MissingWheel.SetActive(false);
        EnterText.SetActive(false);
        bool inCar = false;

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
            else if (MissingWheel.activeInHierarchy == true)
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
                    MissionTurnOff.SetActive(false);
                    bool inCar = true;
                    EnterText.SetActive(false);
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
