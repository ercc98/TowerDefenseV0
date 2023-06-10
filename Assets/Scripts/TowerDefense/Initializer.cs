using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TowerDefense.Utilities;
public class Initializer : MonoBehaviour
{
    [SerializeField] private float logoDisplayTime = 3f;
    [SerializeField] private string mainMenuSceneName = "MainMenu"; 

    IEnumerator Start()
    {
        Debug.Log("Mostrando el logotipo...");
        yield return new WaitForSeconds(logoDisplayTime);

        // Cargar la escena del MainMenu
        SceneLoader.Instance.LoadSceneAsync(mainMenuSceneName);
    }
}