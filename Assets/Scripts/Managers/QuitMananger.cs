using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class QuitMananger : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }
    
}
