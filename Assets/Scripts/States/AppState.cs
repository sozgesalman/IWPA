namespace IWPAGamesProject.State
{
    using Devkit.SM;
    using Devkit.Base.Component;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AppState : StateMachine
    {
        private MainState mainState;
        private GameState gameState;

        public AppState(ComponentContainer componentContainer)
        {
            mainState = new MainState(componentContainer);
            gameState = new GameState(componentContainer);

            this.AddSubStates(mainState);
            this.AddSubStates(gameState);

            this.AddTransition(mainState,gameState,(int)StateTriggers.START_GAME_REQUEST);
            this.AddTransition(gameState,mainState,(int)StateTriggers.GO_TO_MAIN_MENU_REQUEST);

        }

        protected override void OnEnter()
        {

        }

        protected override void OnUpdate()
        {

        }

        protected override void OnExit()
        {
            
        }
         
    }   
}

