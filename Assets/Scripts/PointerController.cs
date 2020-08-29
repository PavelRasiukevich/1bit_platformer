using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PointerController
{


    public class PointerController : MonoBehaviour
    {
        public Image[] pointers;
        public int index;

        private void Start()
        {
            pointers[index].gameObject.SetActive(true);
        }

        private void Update()
        {
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

            //Confirm selected option
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
            {
                switch (index)
                {
                    case 0:
                        SceneManager.LoadScene(1);
                        break;
                    case 1:
                        break;
                    case 2:
                        Application.Quit();
                        break;
                    default:
                        Debug.Log("Something gone wrong.");
                        break;
                }
            }
        }

        public static void TestMethod()
        {

        }
    }
}
