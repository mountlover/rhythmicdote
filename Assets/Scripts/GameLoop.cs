using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Rhythmicdote
{
    public class GameLoop : MonoBehaviour
    {
        CardinalGrid grid = null;
        Text debugText = null;
        InputHandler inputHandler = null;
        List<GameInput> inputs = null;
        GameState player1 = null;
        bool loaded = false;
        // Use this for initialization
        void Start()
        {
            player1 = GameState.LoadGameState(false);
            grid = new CardinalGrid(player1);
            inputHandler = new InputHandler();
            GameObject textObj = GameObject.Find("UI Text 1");
            debugText = (Text)textObj.GetComponent(typeof(Text));
            loaded = true;
        }
        // Update is called once per frame
        void Update()
        {
            if (!loaded) return;
            loaded = false;
            inputs = inputHandler.GetInputs(KeySet.All);
            double horizontal = 0, vertical = 0;
            foreach (GameInput i in inputs)
            {
                if (i is AnalogGameInput)
                {
                    AnalogGameInput ai = (AnalogGameInput)i;
                    if(ai.IsPressed) switch (ai.Descriptor.Action)
                    {
                        case ControlAction.Horizontal:
                            horizontal = ai.AnalogValue;
                            break;
                        case ControlAction.Vertical:
                            vertical = ai.AnalogValue;
                            break;
                    }
                }
                else if(i.IsPressed)
                {
                    switch(i.Descriptor.Action)
                    {
                        case ControlAction.Up:
                            vertical += 1;
                            break;
                        case ControlAction.Down:
                            vertical -= 1;
                            break;
                        case ControlAction.Left:
                            horizontal -= 1;
                            break;
                        case ControlAction.Right:
                            horizontal += 1;
                            break;
                    }
                }
            }
            if(horizontal != 0 || vertical != 0)
            {
                player1.Move(1, horizontal, vertical);
                grid.Update(player1);
            }
            debugText.text = ("Y res set to: " + Settings.GetResY() + "\nCurrent Position: (" + player1.Horizontal_Coord + "," + player1.Vertical_Coord + ")\nCurrent Grid Index: (" + grid.IndexHorizontal + ", " + grid.IndexVertical + ")\n" + grid.Display());
            loaded = true;
        }
    }
}
