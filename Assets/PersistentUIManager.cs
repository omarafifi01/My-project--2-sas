using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentUIManager : MonoBehaviour
{
    private static PersistentUIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }
    }

    public void ToggleScene()
    {
        string current = SceneManager.GetActiveScene().name;
        if (current == "Marker less") 
            SceneManager.LoadScene("Markerbased1"); 
            SceneManager.LoadScene("ShowroomScene");
    }
}
