using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBack : MonoBehaviour
{
    string lastScene;
    public void ButtonClicked()
    {
        SceneScript.GoScene(SceneScript.lastScene);
    }
}
