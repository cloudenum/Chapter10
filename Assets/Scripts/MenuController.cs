using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button BtnProblem1;
    public Button BtnProblem2;
    public Button BtnProblem3;
    public Button BtnProblem4;
    public Button BtnProblem5;
    public Button BtnProblem6;
    public Button BtnProblem7;
    public Button BtnProblem8;
    public Button BtnProblem9;
    // public GameObject AlertPanel;
    // public Text AlertMessageText;
    // public Button BtnCloseAlert;

    void Start()
    {
        // AlertPanel.SetActive(false);
        // BtnCloseAlert.onClick.AddListener(() =>
        // {
        //     AlertPanel.SetActive(false);
        // });

        BtnProblem1.onClick.AddListener(() =>
        {
            LaunchOtherBuild(1);
        });
        BtnProblem2.onClick.AddListener(() =>
        {
            LaunchOtherBuild(2);
        });
        BtnProblem3.onClick.AddListener(() =>
        {
            LaunchOtherBuild(3);
        });
        BtnProblem4.onClick.AddListener(() =>
        {
            LaunchOtherBuild(4);
        });
        BtnProblem5.onClick.AddListener(() =>
        {
            LaunchOtherBuild(5);
        });
        BtnProblem6.onClick.AddListener(() =>
        {
            LaunchOtherBuild(6);
        });
        BtnProblem7.onClick.AddListener(() =>
        {
            LaunchOtherBuild(7);
        });
        BtnProblem8.onClick.AddListener(() =>
        {
            LaunchOtherBuild(8);
        });
        BtnProblem9.onClick.AddListener(() =>
        {
            LaunchOtherBuild(9);
        });
    }

    void LaunchOtherBuild(int buildNumber)
    {
        string dataPath = System.IO.Directory.GetCurrentDirectory();
        try
        {
            if (buildNumber == 9)
            {
                SceneManager.LoadScene("Gameplay");
            }
            else
            {
                Process.Start($"{dataPath}/bin/Problem-{buildNumber.ToString()}/Chapter10.exe");
            }
        }
        catch (System.Exception e)
        {
            // AlertMessageText.text = e.Message;
            // AlertPanel.SetActive(true);
            UnityEngine.Debug.LogException(e);
        }
    }
}
