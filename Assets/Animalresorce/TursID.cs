using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TursID : MonoBehaviour
{


    private Vector3 velocity;

    // TursのIDを返すプロパティ
    public int Id { get; private set; }
    // Tursを設置したしたプレイヤーのIDを返すプロパティ
    public int OwnerId { get; private set; }
    // 同じかどうかをIDで判定するメソッド
    public bool Equals(int id, int ownerId) => id == Id && ownerId == OwnerId;

    public void Init(int id, int ownerId, Vector3 origin, float angle)
    {
        Id = id;
        OwnerId = ownerId;
        transform.position = origin;
        velocity = 9f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
    }


    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
