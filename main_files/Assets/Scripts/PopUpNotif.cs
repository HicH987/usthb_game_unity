using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpNotif : MonoBehaviour
{

    public GameObject PopUp1Image;
    public GameObject PopUp2Image;
    public GameObject PopUp3Image;
    // Start is called before the first frame update
    void Start()
    {
        PopUp1Image.SetActive(true);
        Invoke("PopUp2Msg", 6f);
    }

    // Update is called once per frame
    void PopUp2Msg()
    {
        // UnityEngine.Debug.Log("fct 2");
        PopUp1Image.SetActive(false);
        PopUp2Image.SetActive(true);
        Invoke("PopUp3Msg", 2f);
    }

    void PopUp3Msg()
    {
        PopUp3Image.SetActive(true);
    }
}
