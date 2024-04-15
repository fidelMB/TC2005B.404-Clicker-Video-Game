using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Variables para los paneles de tienda, avatar, ranking y cursos
    public GameObject newPanel;
    public GameObject oldPanel1;
    public GameObject oldPanel2;
    public GameObject oldPanel3;
    
    // Dentro de unity, se asigna a cada botón de la barra de navegación el panel que se quiere abrir
    // como newPanel y los otros tres paneles como oldPanel1, oldPanel2 y oldPanel3
    public void OpenPanel()
    {
        newPanel.SetActive(true);
        oldPanel1.SetActive(false);
        oldPanel2.SetActive(false);
        oldPanel3.SetActive(false);
    }
}
