using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json;
using System;

public class ApiManager : MonoBehaviour
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Usuario
    {
        public string nombre_usuario { get; set; }
        public int neo_coins { get; set; }
        public int neo_stars { get; set; }
        public int puntuacion { get; set; }
    }

    public GameObject fila_usuario_leaderboard;
    public GameObject leaderboard;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void GetLeaderboard()
    {
        StartCoroutine(GetLeaderboard("http://localhost:5000/leaderboard"));
    }
    
    IEnumerator GetLeaderboard(String uri)
    {
        RectTransform rt_leaderboard = leaderboard.GetComponent<RectTransform>();
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Error al obtener leadeboard: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);
                    List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(webRequest.downloadHandler.text);
                    foreach (Usuario usuario in usuarios)
                    {
                        GameObject nueva_fila = Instantiate(fila_usuario_leaderboard, transform);
                        nueva_fila.transform.SetParent(GameObject.FindGameObjectWithTag("Filas Leaderboard").transform, false);

                        TMP_Text[] textos = nueva_fila.GetComponentsInChildren<TMP_Text>();

                        textos[0].text = usuario.nombre_usuario;
                        textos[1].text = usuario.neo_coins.ToString();
                        textos[2].text = usuario.neo_stars.ToString();
                        textos[3].text = usuario.puntuacion.ToString();
                    }
                    break;
            }
        }
    }
}
