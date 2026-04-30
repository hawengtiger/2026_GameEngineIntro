using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ===| UI °»½Å |===
/// </summary>
public class TitleManager : MonoBehaviour
{
    /// <summary>
    /// public | ==============================
    /// </summary>
    public GameObject helpPanel;
    public GameObject leaderPanel;

    /// <summary>
    /// private | ==============================
    /// </summary>


    /// <summary>
    /// ===| 1´Ü°è ÀÌµ¿ |===
    /// </summary>
    public void GoToLv1()
    {
        SceneManager.LoadScene("PlayScene_Door1");      // Lv1¾ÀÀ¸·Î °¨
    }

    /// <summary>
    /// ===| ¸ÞÀÎ È­¸é ÀÌµ¿ |===
    /// </summary>
    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");   //¸ÞÀÎ¾ÀÀ¸·Î °¨
    }

    /// <summary>
    /// ===| µµ¿ò¸» ÄÑÁü |===
    /// </summary>
    public void OpenHelp()
    {
        helpPanel.SetActive(true);      //µµ¿ò¸» ÆÇ³Ú ÄÑÁü
    }

    /// <summary>
    /// ===| µµ¿ò¸» ²¨Áü |===
    /// </summary>
    public void CloseHelp()
    {
        helpPanel.SetActive(false);      //µµ¿ò¸» ÆÇ³Ú ²¨Áü
    }

    /// <summary>
    /// ===| ¸®´õº¸µå ÄÑÁü |===
    /// </summary>
    public void OpenLeader()
    {
        leaderPanel.SetActive(true);      //¸®´õº¸µå ÆÇ³Ú ÄÑÁü
    }

    /// <summary>
    /// ===| ¸®´õº¸µå ²¨Áü |===
    /// </summary>
    public void CloseLeader()
    {
        leaderPanel.SetActive(false);      //¸®´õº¸µå ÆÇ³Ú ²¨Áü
    }

}
