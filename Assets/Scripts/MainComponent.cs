namespace IWPAGamesProject
{
    using Devkit.Base.Component;
    using IWPAGamesProject.Component;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MainComponent : MonoBehaviour
    {
        private ComponentContainer componentContainer;
        private UIComponent uiComponent;
        private GamePlayComponent gamePlayComponent;


        private void Awake()
        {
            componentContainer = new ComponentContainer();
        }

        private void Start()
        {
            CreateUIComponent();
            CreateGamePlayComponent();

            InitializeComponents();

        }

        private void CreateUIComponent()
        {
            uiComponent = FindObjectOfType<UIComponent>();
            componentContainer.AddComponent("UIComponent", uiComponent);
        }
        private void CreateGamePlayComponent()
        {
            gamePlayComponent = FindObjectOfType<GamePlayComponent>();
            componentContainer.AddComponent("GamePlayComponent", gamePlayComponent);
        }

        private void InitializeComponents()
        {
            uiComponent.Initialize(componentContainer);
            gamePlayComponent.Initialize(componentContainer);
        }

    }
}

