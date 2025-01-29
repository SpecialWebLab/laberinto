using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MazePainter))]
public class MazePainterEditor : Editor
{
    private MazePainter mazePainter;

    private void OnEnable()
    {
        mazePainter = (MazePainter)target;
    }

    void OnSceneGUI()
    {
        // Detectar el evento del mouse
        Event e = Event.current;

        if (e.type == EventType.MouseDown && e.button == 0) // Clic izquierdo
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            RaycastHit hit;

            // Detectar colisión con el PaintLayer
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mazePainter.paintLayer))
            {
                // Posición de la cuadrícula
                Vector3 gridPosition = new Vector3(
                    Mathf.Round(hit.point.x / mazePainter.gridSize) * mazePainter.gridSize,
                    Mathf.Round(hit.point.y / mazePainter.gridSize) * mazePainter.gridSize,
                    Mathf.Round(hit.point.z / mazePainter.gridSize) * mazePainter.gridSize
                );

                // Instanciar el prefab en la escena
                Undo.RegisterCompleteObjectUndo(mazePainter, "Paint Wall"); // Permite deshacer
                Instantiate(mazePainter.wallPrefab, gridPosition, Quaternion.identity, mazePainter.transform);
            }
        }
    }
}
