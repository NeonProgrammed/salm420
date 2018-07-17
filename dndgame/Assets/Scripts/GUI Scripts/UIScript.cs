using UnityEngine;
//using UnityEngine.UI;

/*I'm still learning the elements to a ui system, but I will try to explain this the best I can.
  When we go to create the canvases in Unity, we actually need to keep them enabled, so it will
  look weird until we actually start the game and the proper scripts runs that control them. */

public class UIScript : MonoBehaviour {
    public Canvas mainUI;
    public Canvas playUI;
    public Canvas optionsUI;

    void Awake() //the Awake function is written in Unity to run before the Start() function
    {
        playUI.enabled = false; //Upon starting the game, we set the play ui to false,
        mainUI.enabled = true; //we set the mainui to true,
        optionsUI.enabled = false; //and we don't want the options canvas on at all yet.
    }

    public void PlayOn() //When we hit play, the canvases will swap
    {
        playUI.enabled = true; //turns on the playUI canvas
        mainUI.enabled = false; //turns off the mainUi canvas
    }

    public void OptionsOn()
    {
        mainUI.enabled = false;
        optionsUI.enabled = true;
    }

    public void PlayReturn() //When we go back to the main menu, we want the canvases to swap back
    {
        playUI.enabled = false;
        mainUI.enabled = true;
    }

    public void OptionsReturn()
    {
        mainUI.enabled = true;
        optionsUI.enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
