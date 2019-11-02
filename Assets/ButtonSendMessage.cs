using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSendMessage : MonoBehaviour
{

    public void SendButtonMessage()
    {
        gameObject.SendMessage("UpdateButtonText", "Test button pressed");
    }
}
