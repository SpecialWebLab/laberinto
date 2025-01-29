using UnityEngine;

public class MazePainter : MonoBehaviour
{
    public GameObject wallPrefab; // Prefab del muro
    public LayerMask paintLayer; // Capa donde se pueden pintar los muros
    public float gridSize = 1f; // Tamaño de la cuadrícula

    void Update()
    {
        if (Input.GetMouseButton(0)) // Botón izquierdo del mouse
        {
            PaintWall();
        }
    }

    void PaintWall()
    {
        // Obtener posición del mouse en el mundo
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, paintLayer))
        {
            // Ajustar posición al tamaño de la cuadrícula
            Vector3 position = hit.point;
            position.x = Mathf.Round(position.x / gridSize) * gridSize;
            position.y = Mathf.Round(position.y / gridSize) * gridSize;
            position.z = Mathf.Round(position.z / gridSize) * gridSize;

            // Verificar si ya hay un muro en esa posición
            Collider[] colliders = Physics.OverlapSphere(position, gridSize / 2f);
            if (colliders.Length == 0)
            {
                Instantiate(wallPrefab, position, Quaternion.identity); // Crear el muro
            }
        }
    }
}
