using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Utilities
{
    public class SceneLoader : MonoBehaviour
    {
        private static SceneLoader instance;
        [SerializeField] private float delayBeforeTransition = 1f;

        public static SceneLoader Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        public void LoadSceneAsync(string sceneName)
        {
            StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
        }

        private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                yield return null;

                if (asyncOperation.progress >= 0.9f)
                {
                    // Permitir la activación de la escena
                    asyncOperation.allowSceneActivation = true;
                    //break;
                }
                yield return null;
            }
        }
    }
}