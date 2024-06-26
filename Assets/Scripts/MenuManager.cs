using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Variables para los paneles de tienda, avatar, ranking y cursos
    public GameObject newPanel1;
    public GameObject newPanel2;
    public GameObject oldPanel1;
    public GameObject oldPanel2;
    public GameObject oldPanel3;

    // Dentro de unity, se asigna a cada bot�n de la barra de navegaci�n el panel que se quiere abrir
    // como newPanel y los otros tres paneles como oldPanel1, oldPanel2 y oldPanel3
    public void OpenPanel()
    {
        Debug.Log("OpenPanel called");
        if (newPanel1 != null) newPanel1.SetActive(true);
        if (newPanel2 != null) newPanel2.SetActive(true);
        if (oldPanel1 != null) oldPanel1.SetActive(false); // Check if the object is not null before setting active state
        if (oldPanel2 != null) oldPanel2.SetActive(false);
        if (oldPanel3 != null) oldPanel3.SetActive(false);
    }

}
