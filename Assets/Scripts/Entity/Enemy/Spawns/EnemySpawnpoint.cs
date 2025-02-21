using UnityEngine;
using Photon.Pun;

public class EnemySpawnpoint : MonoBehaviour {

    public string prefab;
    public GameObject currentEntity;
    /*
    public void Start() {
        GameObject go = new GameObject("Preview");
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        SpriteRenderer enemySR = Resources.Load(prefab).getComponent<SpriteRenderer>();

        if (enemySR != null)
        {
            renderer.sprite = enemySR.sprite;
        }
    }
    */
    public virtual bool AttemptSpawning() {
        if (currentEntity)
            return false;

        foreach (var hit in Physics2D.OverlapCircleAll(transform.position, 1.5f)) {
            if (hit.gameObject.CompareTag("Player"))
                //cant spawn here
                return false;
        }

        currentEntity = PhotonNetwork.InstantiateRoomObject(prefab, transform.position, transform.rotation);
        return true;
    }
}