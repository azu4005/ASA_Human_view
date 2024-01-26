
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BirdSet : MonoBehaviourPunCallbacks
{
    GameObject targetObject;
    GameObject Bard;
    Vector3 ChildLocalPos;
    Vector3[] Position_List = new Vector3[4];
    Vector3 KeepPos;
    private PhotonView photonview = null;
    int frame;
    MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
        targetObject = GameObject.Find("bird"); 
        int value = Random.Range(1, 255);
        int value2 = Random.Range(1, 255);
        int value3 = Random.Range(1, 255);
        GetComponent<Renderer>().material.color = new Color32((byte)value, (byte)value2, (byte)value3, 1);
        photonview = GetComponent<PhotonView>();
        /*
        GameObject obj = (GameObject)Resources.Load("Torus 1");
        Object.Instantiate(obj, Vector3.zero, Quaternion.identity);
        GameObject obj2 = (GameObject)Resources.Load("Torus");
        Object.Instantiate(obj2, Vector3.zero, Quaternion.identity);
        Child = GameObject.Find("Torus(Clone)");
        //Child.transform.parent = this.transform;
        */
        mr = GetComponent<MeshRenderer>();
        mr.material.color = mr.material.color - new Color32(0, 0, 0, 255);

    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        if (frame % 20 == 0)
        {
            photonview.RPC("BardSync", RpcTarget.Others, this.transform.parent.InverseTransformPoint(targetObject.transform.position), this.transform.parent.InverseTransformDirection(targetObject.transform.forward), this.transform.parent.InverseTransformDirection(targetObject.transform.up));
            //Debug.Log("RPC");
            
        }

    }
        [PunRPC]
        public void BardSync(Vector3 pos, Vector3 dirforward, Vector3 dirup, PhotonMessageInfo info)
        {
            //Debug.Log(this.transform.position);
            //Debug.Log("Get world position:" +pos);
            this.transform.localPosition = pos;
            this.transform.forward = this.transform.parent.TransformDirection(dirforward);
            dirforward = this.transform.forward;
            this.transform.up = this.transform.parent.TransformDirection(dirup);
            dirup = this.transform.up;
            this.transform.rotation = Quaternion.LookRotation(dirforward, dirup);
            KeepPos = this.transform.position;
            this.transform.position = KeepPos;
        }
    }
