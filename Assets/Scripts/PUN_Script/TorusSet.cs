using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class TorusSet : MonoBehaviourPunCallbacks
{
    GameObject targetObject;
    GameObject Child;
    GameObject Torus;
    public GameObject targetprefab;
    Vector3 ChildLocalPos;
    Vector3[] Position_List = new Vector3[4];
    Vector3 KeepPos;
    private PhotonView photonview = null;
    private int nextTorsId = 0;
    int frame;
    MeshRenderer mr;
    private GameObject[] Player = new GameObject[0];
    private int nextTursId = 0;
    private int JoinCount = 0;

    private bool isAvailable;
    string Myname;

    [SerializeField] private MeshRenderer _avatarObjectMeshRenderer;
    [SerializeField] private Material[] _playerMaterials;
  
    // アイテムが取得可能かどうか
    //public float tag = 1;
    // Start is called before the first frame update

    /*
    public enum EEventType : byte
    {
        Coller = 1,
    }
    public void Awake()
    {
        PhotonNetwork.OnEventCall += OnRaiseEvent;
       // Player[0] = GameObject.Find("player1");
    }
    public void Hello()
    {
        var option = new RaiseEventOptions()
        {
            TargetActors = new int[] { 2 },
            Receivers = ReceiverGroup.Others,
        };
        PhotonNetwork.RaiseEvent((byte)EEventType.Coller, "Hello!",true,  option);
    }

    private void OnRaiseEvent(byte i_eventcode, object i_content, int i_senderid)
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.color = new Color32(255, 0, 0, 255);
    }
    */

    void Start()
    {
        frame = 0;
        targetObject = Camera.main.gameObject;
        Myname = PhotonNetwork.LocalPlayer.NickName;

        mr = GetComponent<MeshRenderer>();
        photonview = GetComponent<PhotonView>();
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber );
        isAvailable = true;

        /*
        GameObject obj = (GameObject)Resources.Load("Torus 1");
        Object.Instantiate(obj, Vector3.zero, Quaternion.identity);
        GameObject obj2 = (GameObject)Resources.Load("Torus");
        Object.Instantiate(obj2, Vector3.zero, Quaternion.identity);
        Child = GameObject.Find("Torus(Clone)");
        Child.transform.parent = this.transform;
        
        */
        
    }



    // Update is called once per frame
    void Update()
    {

      //  frame++;
      //  if (frame % 20 == 0)
        {        

            Myname = PhotonNetwork.LocalPlayer.NickName;
            photonview.RPC("UserColor", RpcTarget.Others, Myname);
       
            photonview.RPC("TorusSync", RpcTarget.Others, this.transform.parent.InverseTransformPoint(targetObject.transform.position), this.transform.parent.InverseTransformDirection(targetObject.transform.forward), this.transform.parent.InverseTransformDirection(targetObject.transform.up));

        }
    }



    [PunRPC]
    public void UserColor(string Myname ,PhotonMessageInfo info)
    {
        if (isAvailable)
        {
            isAvailable = false;

            if (Myname == "My name is 1")
            {
                mr.material.color = new Color32(255, 0, 0, 255);
            }
            else if (Myname == "My name is 2")
            {
                mr.material.color = new Color32(0, 255, 0, 255);
            }
            else if(Myname == "My name is 3")
            {
                mr.material.color = new Color32(0, 0, 255, 255);
            }
        }
    }
 

    [PunRPC]
    public void TorusSync(Vector3 pos, Vector3 dirforward, Vector3 dirup, PhotonMessageInfo info)
    {

        //Debug.Log(this.transform.position);

        this.transform.localPosition = pos;
        this.transform.forward = this.transform.parent.TransformDirection(dirforward);
        dirforward = this.transform.forward;
        this.transform.up = this.transform.parent.TransformDirection(dirup);
        dirup = this.transform.up;
        this.transform.rotation = Quaternion.LookRotation(dirforward, dirup);
        KeepPos = this.transform.position;
        KeepPos.y += 0.3f;
        this.transform.position = KeepPos;
    }
}
