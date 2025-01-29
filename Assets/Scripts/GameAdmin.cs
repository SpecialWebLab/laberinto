using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour
{
    public static GameAdmin Instance;
    
    private void Awake(){
        // Asegurarse de que solo exista un GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantén este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }
   // Método público para reiniciar el juego
    public void RestartGame(float delay)
    {
        StartCoroutine(RestartGameCoroutine(delay));
    }

    private IEnumerator RestartGameCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay); // Espera el tiempo especificado
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
    }
}
