using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TursID : MonoBehaviour
{


    private Vector3 velocity;

    // Turs��ID��Ԃ��v���p�e�B
    public int Id { get; private set; }
    // Turs��ݒu���������v���C���[��ID��Ԃ��v���p�e�B
    public int OwnerId { get; private set; }
    // �������ǂ�����ID�Ŕ��肷�郁�\�b�h
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
