using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importar SceneManager

public class WinTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if (collision.collider.CompareTag("Player")){
            gameObject.SetActive(false);
            Debug.Log("Ganaste");

            // Llamar al GameManager para reiniciar el juego
            GameAdmin.Instance.RestartGame(2.0f); // Reinicia en 2 segundos
             
        }
    }

}
