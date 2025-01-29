using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
     public Vector3 offset = new Vector3(1, 0, 0); // Distancia entre duplicados (1 unidad en el eje X)


    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            DuplicateObject();
        }
    }
    void DuplicateObject()
    {
        GameObject duplicate = Instantiate(gameObject); // Duplica el objeto
        duplicate.transform.position = transform.position + offset; // Coloca el duplicado con el offset
        duplicate.name = gameObject.name + "_Copy"; // Renombra el duplicado (opcional)
    }
}
