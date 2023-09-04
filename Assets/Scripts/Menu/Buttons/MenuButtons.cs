using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject UIMenu;
    [SerializeField] private GameObject UISettings;
    //[SerializeField] private Transform TransformCard;
    [SerializeField] private Transform TransformSettings;


    public void onClick()
    {
        string tag = this.tag;
        switch (tag)
        {
            case "Menu-Play":
                SceneManager.LoadScene("Shop");
                break;

            case "Menu-Settings":
                UIMenu.SetActive(false);
                UISettings.SetActive(true);
                break;

            case "Menu-Quit":
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
                break;

            case "Menu-Back":
                Transform thisWindowTransform = transform.root;
                if(thisWindowTransform == TransformSettings)
                {
                    UISettings.SetActive(false);
                    UIMenu.SetActive(true);
                }
                break;

            default:
                print("Somethind went wrong in switch");
                break;
        }
    }
}
