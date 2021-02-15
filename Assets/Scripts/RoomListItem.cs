using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text1;

    public RoomInfo info;
   public void SetUp(RoomInfo _info)
   {
        info = _info;
        text1.text = _info.Name;
   }

    public void OnClick()
    {
        NetworkControlling.Instance.JoinRoom(info);
    }
}
 