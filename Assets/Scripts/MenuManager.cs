using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Variables para los paneles de tienda, avatar, ranking y cursos
    public GameObject newPanel1;
    public GameObject newPanel2;
    public GameObject newPanel3;
    public GameObject newPanel4;
    public GameObject newPanel5;
    public GameObject newPanel6;
    public GameObject oldPanel1;
    public GameObject oldPanel2;
    public GameObject oldPanel3;
    public GameObject oldPanel4;
    public GameObject oldPanel5;
    public GameObject oldPanel6;
    public GameObject oldPanel7;

    // Dentro de unity, se asigna a cada botón de la barra de navegación el panel que se quiere abrir
    // como newPanel y los otros tres paneles como oldPanel1, oldPanel2 y oldPanel3
    public void OpenPanel()
    {
        Debug.Log("OpenPanel called");
        if (newPanel1 != null) newPanel1.SetActive(true);
        if (newPanel2 != null) newPanel2.SetActive(true);
        if (newPanel3 != null) newPanel3.SetActive(true);
        if (newPanel4 != null) newPanel4.SetActive(true);
        if (newPanel5 != null) newPanel5.SetActive(true);
        if (newPanel6 != null) newPanel6.SetActive(true);
        if (oldPanel1 != null) oldPanel1.SetActive(false); // Check if the object is not null before setting active state
        if (oldPanel2 != null) oldPanel2.SetActive(false);
        if (oldPanel3 != null) oldPanel3.SetActive(false);
        if (oldPanel4 != null) oldPanel4.SetActive(false);
        if (oldPanel5 != null) oldPanel5.SetActive(false);
        if (oldPanel6 != null) oldPanel6.SetActive(false);
        if (oldPanel7 != null) oldPanel7.SetActive(false);
    }

}
