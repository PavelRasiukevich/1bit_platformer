using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestNameSpace
{



    public class UIController : MonoBehaviour
    {
        public GameObject restartAfterDeath;

        public Image[] pointers;
        private int index;
        private bool isMenuOpened;


        private void Start()
        {
            pointers[index].gameObject.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isMenuOpened)
                {
                    Time.timeScale = 0;
                    restartAfterDeath.SetActive(true);
                    isMenuOpened = !isMenuOpened;
                }
                else
                {

                    Time.timeScale = 1;
                    isMenuOpened = !isMenuOpened;
                    restartAfterDeath.SetActive(false);
                }
            }

            if (!HeroController.instance.isAlive)
            {
                Time.timeScale = 0;
                restartAfterDeath.SetActive(true);
            }


            #region SELECT AMONG OPTIONS

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (index < pointers.Length - 1)
                {
                    pointers[index].gameObject.SetActive(false);
                    pointers[index + 1].gameObject.SetActive(true);
                    index++;
                }
                else
                {
                    pointers[index].gameObject.SetActive(false);
                    index = 0;
                    pointers[index].gameObject.SetActive(true);
                }

            }

            //Select option
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (index > 0)
                {
                    pointers[index].gameObject.SetActive(false);
                    pointers[index - 1].gameObject.SetActive(true);
                    index--;

                }
                else
                {
                    pointers[index].gameObject.SetActive(false);
                    index = pointers.Length - 1;
                    pointers[index].gameObject.SetActive(true);
                }

            }
            #endregion

            if (restartAfterDeath.activeSelf)
            {
                //Confirm selected option
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    switch (index)
                    {
                        case 0:
                            Time.timeScale = 1;
                            SceneManager.LoadScene(1);
                            break;
                        case 2:
                            Time.timeScale = 1;
                            Application.Quit();
                            break;
                        case 1:
                            Time.timeScale = 1;
                            restartAfterDeath.SetActive(false);
                            break;
                        default:
                            Debug.Log("Something gone wrong.");
                            break;
                    }
                }
            }

        }


        #region RestartAfterDeadthWindow

        public void RestartScene()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitSceneToMenu()
        {
            SceneManager.LoadScene(0);
        }

        #endregion
    }
}
