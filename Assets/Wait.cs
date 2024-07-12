using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wait : MonoBehaviour
{
    //public float waitingTime = 3f;
    private Image introImage;

    // Start is called before the first frame update
    void Start()
    {
        introImage = GetComponentInChildren<Image>();
        StartCoroutine(WaitForIntro());
    }

    IEnumerator WaitForIntro()
    {
        //yield return new WaitForSeconds(waitingTime);

        ////SceneManager.LoadScene(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        for (float i = 0; i <= 3; i += Time.deltaTime)
        {
            // set color with i as alpha
            Image img = gameObject.GetComponentInChildren<Image>();
            img.color = new Color(img.color.r, img.color.g, img.color.b, i);
            //gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i);
            introImage.color = new Color(1, 1, 1, i);

            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
