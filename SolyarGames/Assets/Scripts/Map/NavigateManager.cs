using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class NavigateManager : MonoBehaviour {
    private NavMeshSurface surface;
    private static NavigateManager manager;
    private void Awake()
    {
        manager = this;
        surface = GetComponent<NavMeshSurface>();
    }
    public static void UpdateNavMesh()
    {
         manager.surface.UpdateNavMesh(manager.surface.navMeshData);
    }
}
