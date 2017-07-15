using UnityEngine;

public class Creature : MonoBehaviour
{
    private const string PrefabPath = "Creature";

    public int Health { get; private set; }
    public bool PlayerController { get; private set; }

    public static void Spawn()
    {
        GameObject creature_obj = GameObject.Instantiate(QuickLoad.Load<GameObject>(PrefabPath));
        // TODO: give it a good position in the scene.
    }

    public void OnDrawGizmos()
    {
        // No sprite attached at the moment, so just draw a gizmo on our position.
        Gizmos.DrawWireSphere(this.transform.position, 1f);
    }
}
