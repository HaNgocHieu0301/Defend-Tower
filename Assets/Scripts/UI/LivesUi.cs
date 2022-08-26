using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LivesUi : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStates.lives + " Lives";
    }
}
