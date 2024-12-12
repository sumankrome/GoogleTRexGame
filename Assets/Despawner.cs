using UnityEngine;

public class Despawner : MonoBehaviour
{
    public Spawner spawner;

    private void OnTriggerExit2D(Collider2D collision){
        spawner.instantiatedObjects.RemoveAt(0);
        Destroy(collision.gameObject.transform.parent.gameObject);
    }
}
