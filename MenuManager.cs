using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private DifficultyManager dm;

    void Start()
    {
        if (DifficultyManager.Instance == null)
        {
            GameObject obj = new GameObject("DifficultyManager");
            obj.AddComponent<DifficultyManager>();
        }
        dm = DifficultyManager.Instance;
    }
//Depending on the difficulty selected it sets the game speed, speed increase rate, and spawn times for obstacles and then loads the game scene
    public void PlayEasy()
{
    dm.SetEasy();
    SceneManager.LoadScene("Game");
}

public void PlayMedium()
{
    dm.SetMedium();
    SceneManager.LoadScene("Game");
}

public void PlayHard()
{
    dm.SetHard();
    SceneManager.LoadScene("Game");
}
}