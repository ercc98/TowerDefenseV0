using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TowerDefense.Utilities;
using TowerDefense.Data;

namespace TowerDefense.UI
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private List<Data.LevelData> levelList;
        private Data.LevelData levelSelected;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void StartLevel(int level)
        {
            
            //Para evitar que entre a una escena que no existe por si se equivocan al ponerlo arriba
            if(level == 1)
            {
                levelSelected = levelList[0];
            }
            else if(level == 2)
            {
                levelSelected = levelList[1];
            }
            else  if(level == 3)
            {
                levelSelected = levelList[2];
            }
            else 
            {
                Debug.Log("No existe");
            }

            GameState.Instance.SelectLevel(levelSelected);
            SceneLoader.Instance.LoadSceneAsync(levelSelected.Slug);

        }
    }
}
