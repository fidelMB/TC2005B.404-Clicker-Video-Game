using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject newPanel;
    public GameObject oldPanel1;
    public GameObject oldPanel2;
    public GameObject oldPanel3;
    

    // Update is called once per frame

    public void OpenPanel()
    {
        newPanel.SetActive(true);
        oldPanel1.SetActive(false);
        oldPanel2.SetActive(false);
        oldPanel3.SetActive(false);
    }
}
