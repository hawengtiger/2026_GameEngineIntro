using UnityEngine;

public class HighScore : MonoBehaviour
{
    private static string key = "HighScore";

    public static int Load(int stage)
    {
        return PlayerPrefs.GetInt(key + "_" + stage, 0);
    }

    public static void TrySet(int stage, int newScore)
    {
        if (newScore <= Load(stage))
        {
            return;
        }

        PlayerPrefs.SetInt(key + "_" + stage, newScore);
        PlayerPrefs.Save();
    }
}
