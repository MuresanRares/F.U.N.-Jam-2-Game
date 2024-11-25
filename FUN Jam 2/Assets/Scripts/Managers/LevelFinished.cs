using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    [SerializeField] private GameObject objectToTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToTrigger)
        {
            Debug.Log(objectToTrigger.name + " entered trigger. Loading next scene...");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}