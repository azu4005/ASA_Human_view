using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class PUNCHILD : MonoBehaviourPunCallbacks
{
    GameObject targetObject;
    Vector3[] Position_List = new Vector3[4];
    private PhotonView photonview = null;
    private int flame = 0;
    void Awake()
    {
        targetObject = Camera.main.gameObject;
        photonview = GetComponent<PhotonView>();
        GameObject Parent = GameObject.Find("ParentAnchor");
        Debug.Log(Parent.transform);
        this.transform.parent = Parent.transform;
        Debug.Log(this.transform.parent);
        int A = 0;
    }

    private void Update()
    {
      flame = flame+1;
      if(flame%10 == 0){
        var Dir = this.transform.parent.transform.position - targetObject.transform.position;
        var PreRote = Quaternion.LookRotation(Dir);
        var Rote = targetObject.transform.rotation;
        //photonview.RPC("SyncPosition", RpcTarget.All,this.transform.parent.InverseTransformPoint(targetObject.transform.position));
        //photonview.RPC("SyncPosition", RpcTarget.All,this.transform.parent.InverseTransformPoint(targetObject.transform.position),Quaternion.Inverse(PreRote));
        //photonview.RPC("SyncPosition", RpcTarget.All, this.transform.parent.InverseTransformPoint(targetObject.transform.position), this.transform.parent.InverseTransformDirection(targetObject.transform.forward));
        flame = 0;
        //Debug.Log(this.transform.position - targetObject.transform.position);
      }
    }
    [PunRPC]
    public void SyncPosition(Vector3 pos,Vector3 dir, PhotonMessageInfo info)
    {
        this.transform.localPosition = pos;
        //Debug.Log(info.Sender.ActorNumber);
        Vector3 ThisPos = this.transform.position;
        ThisPos.y += 0.5f;
        this.transform.position = ThisPos;
        this.transform.forward = this.transform.parent.TransformDirection(dir);
        //Debug.Log(this.transform.rotation);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) {
      Debug.Log("Player_Enter");
      Debug.Log(newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer) {
      Debug.Log("Player_Left");
      Debug.Log(otherPlayer.NickName);
    }
}
