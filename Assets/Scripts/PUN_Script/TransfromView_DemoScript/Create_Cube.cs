using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Create_Cube : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private float m_randomCircle = 4.0f;

    public void CreateCube()
    {
        PhotonNetwork.Instantiate("Cube", GetRandomPosition(), Quaternion.identity, 0);
    }

    private Vector3 GetRandomPosition()
    {

        var rand = new Vector3(Random.Range(-0.5f,0.5f), Random.Range(-0.5f, 0.5f),  1.2f);

        return rand;
    }
}
