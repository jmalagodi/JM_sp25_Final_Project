using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject title;
    public GameObject button;
    public GameObject panel;
    public GameObject text;
    void Start()
    {
        
        button.SetActive(true);
        title.SetActive(true);
        panel.SetActive(true);
        text.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void PlayGame()
    {
        Time.timeScale = 1;
        button.SetActive(false);
        title.SetActive(false);
        panel.SetActive(false);
        text.SetActive(true);
    }
}
