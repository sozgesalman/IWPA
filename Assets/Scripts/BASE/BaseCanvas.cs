namespace IWPAGamesProject.UserInterface
{
    using Devkit.Base.Component;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    [RequireComponent(typeof(Canvas))] //TODO: Learn mean

    public class BaseCanvas : MonoBehaviour
    {
        public delegate void ReturnToMainMenuDelegate();
        public event ReturnToMainMenuDelegate ReturnToMainMenu;
    
        //TODO: Continue here
    }
}

