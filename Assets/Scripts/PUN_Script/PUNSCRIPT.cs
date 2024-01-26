using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections.Generic;

namespace BEFOOL.PhotonTest
{
    public class PUNSCRIPT : MonoBehaviourPunCallbacks
    {
        private GameObject button;
        public GameObject Torus;
        public GameObject Torus2;
        [SerializeField]
        List<string> joinedMembersText = new List<string>();

        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("PUNSTART");
            Torus = GameObject.Find("Torus");
            Torus2 = GameObject.Find("Torus2");
            //     button = GameObject.Find("CreateTV_button");

        }
        public override void OnConnectedToMaster()
        {
            RoomOptions options = new RoomOptions();
            options.PublishUserId = true;
            options.MaxPlayers = 4;
            PhotonNetwork.NickName = "Hololens2";
            PhotonNetwork.JoinOrCreateRoom("Room", options, TypedLobby.Default);
            Debug.Log("PUNCONNECT");
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("PUNJOINED");

           
           // PhotonNetwork.Instantiate("Torus", Vector3.zero, Quaternion.identity);
            Torus.SetActive(false);
            //    Torus2.SetActive(false);




            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                PhotonNetwork.LocalPlayer.NickName = "My name is 1";
                Debug.Log("プレイヤー名" + PhotonNetwork.LocalPlayer.NickName);

            }
            else if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                PhotonNetwork.LocalPlayer.NickName = "My name is 2";

                PhotonNetwork.Instantiate("Player2", Vector3.zero, Quaternion.identity);

                Debug.Log("プレイヤー名" + PhotonNetwork.LocalPlayer.NickName);
            }
            else
            {
                joinedMembersText.Clear();

                foreach (var p in PhotonNetwork.PlayerList)
                {

                    joinedMembersText.Add(p.NickName);
                }


                if (joinedMembersText.Contains("My name is 1") == false)
                {
                    PhotonNetwork.LocalPlayer.NickName = "My name is 1";

                }
                else if (joinedMembersText.Contains("My name is 2") == false)
                {
                    PhotonNetwork.Instantiate("Player2", Vector3.zero, Quaternion.identity);
                    PhotonNetwork.LocalPlayer.NickName = "My name is 2";
                }
                else
                {
                    PhotonNetwork.LocalPlayer.NickName = "My name is 3";
                }

                Debug.Log("プレイヤー名" + PhotonNetwork.LocalPlayer.NickName);
            }
        

        }

        private void Update()
        {
            if (PhotonNetwork.PlayerList.Length == 1)
            {
              Torus.SetActive(true);
          //    Torus2.SetActive(false);

            }
            else if (PhotonNetwork.PlayerList.Length > 1)
            {
                Torus.SetActive(true);
         //       Torus2.SetActive(true);

            }

            /*
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {

                button.SetActive(true);
            }
            else
            {
                button.SetActive(false);
            }

            */

        }



    }
}
