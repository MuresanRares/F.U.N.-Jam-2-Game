using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    public GameObject EnterText;
    public GameObject HasWheel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnterText.SetActive(false);
    }

    void OnTriggerStay()
    {
        if (HasWheel.activeInHierarchy == true)
        {
            EnterText.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit()
    {
        EnterText.SetActive(false);
    }
}
