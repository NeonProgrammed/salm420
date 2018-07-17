using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Changes to the creation scene on create game
    public void CreateCampaign()
    {
        SceneManager.LoadScene(1);
    }
}
