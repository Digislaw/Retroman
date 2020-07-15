using UnityEngine;

public class MainMenuBoot : MonoBehaviour
{
    public void StartGame()
    {
        // pierwszy level musi byc odblokowany
        if(!PlayerPrefs.HasKey("Level1_Unlocked"))
        {
            PlayerPrefs.SetInt("Level1_Unlocked", 1);
        }

        // domyslny start na mapie
        if(!PlayerPrefs.HasKey("Last_Waypoint"))
        {
            PlayerPrefs.SetString("Last_Waypoint", "Waypoint_0");
            PlayerPrefs.SetFloat("Avatar_X", -7.5f);
            PlayerPrefs.SetFloat("Avatar_Y", -3.5f);
        }

        PlayerPrefs.Save();
        SceneController.Instance.ChangeLevel("Level Selection");
    }
}
