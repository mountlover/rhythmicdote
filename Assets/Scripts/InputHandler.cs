using UnityEngine;
using System.Collections.Generic;

namespace Rhythmicdote
{
    public class InputHandler
    {
        List<Keybind>[] bindings;
        Keybind p2Start;
        public InputHandler()
        {
            ReloadBindings();
        }
        public void ReloadBindings()
        {
            bindings = Settings.GetAllKeybinds();
            if (Settings.GetControlSchemeP2() == ControlScheme.Touch) { }
            // Ionno yet
            else p2Start = bindings[(int)Settings.GetControlSchemeP2()].Find(k => k.Action == ControlAction.Menu);
        }
        public List<GameInput> GetInputs(KeySet relevantKeys)
        {
            List<Keybind> ret = new List<Keybind>();
            ControlScheme scheme;
            if (relevantKeys == KeySet.All)
            {
                for (int i = 0; i < bindings.Length; i++)
                {
                    ret.AddRange(bindings[i]);
                }
            }
            else
            {
                scheme = Settings.GetControlSchemeP1();
                if (scheme == ControlScheme.Touch)
                {
                    ret = null;
                    // TODO figure out how this works
                }
                else ret.AddRange(bindings[(int)Settings.GetControlSchemeP1()]);
                if (relevantKeys == KeySet.OnePlayer)
                    ret.Add(p2Start);
                else if (relevantKeys == KeySet.TwoPlayers)
                {
                    scheme = Settings.GetControlSchemeP2();
                    if (scheme == ControlScheme.Touch)
                    {
                        ret = null;
                        // TODO figure out how this works
                    }
                    else ret.AddRange(bindings[(int)scheme]);
                }
            }
            return ReadInputs(ret);
        }
        public List<GameInput> ReadInputs(List<Keybind> keys)
        {
            List<GameInput> inputVals = new List<GameInput>();
            foreach(Keybind key in keys)
            {
                if (key.Binding[0] == '_') // This is the convention I'm using for naming axes
                {
                    inputVals.Add(new AnalogGameInput(key, Input.GetAxis(key.Binding)));
                }
                else if (key.Scheme != ControlScheme.Touch)
                {
                    inputVals.Add(new GameInput(key, Input.GetKey(key.Binding)));
                }
                else // TODO figure out how to handle touch stuff
                {

                }
            }
            return inputVals;
        }
    }
    public class Keybind
    {
        public string Binding { get; private set; }
        public ControlScheme Scheme { get; private set; }
        public ControlAction Action { get; private set; }
        public Keybind(string binding, ControlScheme scheme, ControlAction action)
        {
            Binding = binding;
            Scheme = scheme;
            Action = action;
        }
    }
    public class GameInput
    {
        public bool IsPressed { get; protected set; }
        public Keybind Descriptor { get; protected set; }
        public GameInput(Keybind descriptor, bool val)
        {
            IsPressed = val;
            Descriptor = descriptor;
        }
        protected GameInput() { }
    }
    public class AnalogGameInput : GameInput
    {
        public float AnalogValue { get; private set; }
        public new bool IsPressed { get { return (AnalogValue != 0); } private set { } }
        public AnalogGameInput(Keybind descriptor, float val)
        {
            AnalogValue = val;
            Descriptor = descriptor;
        }
    }
    public class TouchGameInput : GameInput
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public TouchGameInput(Keybind descriptor, float horizontal, float vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            IsPressed = true;
            Descriptor = descriptor;
        }
        public TouchGameInput(Keybind descriptor)
        {
            IsPressed = false;
        }
    }
    public enum ControlScheme
    {
        KBM=0, J1=1, J2=2, Touch=3
    }
    public enum ControlAction
    {
        Up, Down, Left, Right, Dash, Dash2, Swipe, Ranged, Casting, MoveTo, Interact, Swap, Menu, Horizontal, Vertical, HorizontalSwipe, VerticalSwipe, Touch1, Touch2
    }
    public enum KeySet
    {
        OnePlayerX, OnePlayer, TwoPlayers, All
    }
}
