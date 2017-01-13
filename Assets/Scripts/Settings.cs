using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhythmicdote
{
    public class Settings
    {
        public static List<Keybind>[] GetAllKeybinds()
        {
            List<Keybind>[] keybinds = new List<Keybind>[3];
            for (int i = 0; i < 3; i++)
                keybinds[i] = new List<Keybind>();
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Up());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Down());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Left());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Right());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Dash());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Dash2());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Swipe());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Ranged());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Casting());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_MoveTo());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Interact());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Swap());
            keybinds[(int)ControlScheme.KBM].Add(GetKBM_Menu());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Horizontal());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Vertical());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_HorizontalSwipe());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_VerticalSwipe());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Dash());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Swipe());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Ranged());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Casting());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Interact());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Swap());
            keybinds[(int)ControlScheme.J1].Add(GetJ1_Menu());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Horizontal());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Vertical());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_HorizontalSwipe());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_VerticalSwipe());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Dash());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Swipe());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Ranged());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Casting());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Interact());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Swap());
            keybinds[(int)ControlScheme.J2].Add(GetJ2_Menu());
            return keybinds;
        }
        public static void SetResX(int ResX)
        {
            PlayerPrefs.SetInt("ResX", ResX);
        }
        public static int GetResX()
        {
            if (Screen.resolutions.Length > 0)
                return PlayerPrefs.GetInt("ResX", Screen.resolutions[Screen.resolutions.Length - 1].width);
            return PlayerPrefs.GetInt("ResX", Screen.width);
        }
        public static void SetResY(int ResY)
        {
            PlayerPrefs.SetInt("ResY", ResY);
        }
        public static int GetResY()
        {
            if (Screen.resolutions.Length > 0)
                return PlayerPrefs.GetInt("ResY", Screen.resolutions[Screen.resolutions.Length - 1].height);
            return PlayerPrefs.GetInt("ResY", Screen.height);
        }
        public static void SetScale(int Scale)
        {
            PlayerPrefs.SetInt("Scale", Scale);
        }
        public static int GetScale()
        {
            int defaultScale = GetResY() / GlobalFunctions.TILE_SIZE;
            if (defaultScale < 1) defaultScale = 1;
            return PlayerPrefs.GetInt("Scale", defaultScale);
        }
        public static void SetControlSchemeP1(ControlScheme ControlSchemeP1)
        {
            PlayerPrefs.SetInt("ControlSchemeP1", (int)ControlSchemeP1);
        }
        public static ControlScheme GetControlSchemeP1()
        {
            return (ControlScheme)PlayerPrefs.GetInt("ControlSchemeP1", Application.isMobilePlatform ? (int)ControlScheme.Touch : (int)ControlScheme.KBM);
        }
        public static void SetControlSchemeP2(ControlScheme ControlSchemeP2)
        {
            PlayerPrefs.SetInt("ControlSchemeP2", (int)ControlSchemeP2);
        }
        public static ControlScheme GetControlSchemeP2()
        {
            return (ControlScheme)PlayerPrefs.GetInt("ControlSchemeP2", (int)ControlScheme.J1);
        }
        // Keyboard + Mouse Methods
        public static void SetKBM_Up(string KBM_Up)
        {
            PlayerPrefs.SetString("KBM_Up", KBM_Up);
        }
        public static Keybind GetKBM_Up()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Up", "w"), ControlScheme.KBM, ControlAction.Up);
        }
        public static void SetKBM_Down(string KBM_Down)
        {
            PlayerPrefs.SetString("KBM_Down", KBM_Down);
        }
        public static Keybind GetKBM_Down()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Down", "s"), ControlScheme.KBM, ControlAction.Down);
        }
        public static void SetKBM_Left(string KBM_Left)
        {
            PlayerPrefs.SetString("KBM_Left", KBM_Left);
        }
        public static Keybind GetKBM_Left()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Left", "a"), ControlScheme.KBM, ControlAction.Left);
        }
        public static void SetKBM_Right(string KBM_Right)
        {
            PlayerPrefs.SetString("KBM_Right", KBM_Right);
        }
        public static Keybind GetKBM_Right()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Right", "d"), ControlScheme.KBM, ControlAction.Right);
        }
        public static void SetKBM_Dash(string KBM_Dash)
        {
            PlayerPrefs.SetString("KBM_Dash", KBM_Dash);
        }
        public static Keybind GetKBM_Dash()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Dash", "space"), ControlScheme.KBM, ControlAction.Dash);
        }
        public static void SetKBM_Dash2(string KBM_Dash2)
        {
            PlayerPrefs.SetString("KBM_Dash2", KBM_Dash2);
        }
        public static Keybind GetKBM_Dash2()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Dash2", "mouse 2"), ControlScheme.KBM, ControlAction.Dash2);
        }
        public static void SetKBM_Swipe(string KBM_Swipe)
        {
            PlayerPrefs.SetString("KBM_Swipe", KBM_Swipe);
        }
        public static Keybind GetKBM_Swipe()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Swipe", "mouse 0"), ControlScheme.KBM, ControlAction.Swipe);
        }
        public static void SetKBM_Ranged(string KBM_Ranged)
        {
            PlayerPrefs.SetString("KBM_Ranged", KBM_Ranged);
        }
        public static Keybind GetKBM_Ranged()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Ranged", "r"), ControlScheme.KBM, ControlAction.Ranged);
        }
        public static void SetKBM_Casting(string KBM_Casting)
        {
            PlayerPrefs.SetString("KBM_Casting", KBM_Casting);
        }
        public static Keybind GetKBM_Casting()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Casting", "c"), ControlScheme.KBM, ControlAction.Casting);
        }
        public static void SetKBM_MoveTo(string KBM_MoveTo)
        {
            PlayerPrefs.SetString("KBM_MoveTo", KBM_MoveTo);
        }
        public static Keybind GetKBM_MoveTo()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_MoveTo", "mouse 1"), ControlScheme.KBM, ControlAction.MoveTo);
        }
        public static void SetKBM_Interact(string KBM_Interact)
        {
            PlayerPrefs.SetString("KBM_Interact", KBM_Interact);
        }
        public static Keybind GetKBM_Interact()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Interact", "f"), ControlScheme.KBM, ControlAction.Interact);
        }
        public static void SetKBM_Swap(string KBM_Swap)
        {
            PlayerPrefs.SetString("KBM_Swap", KBM_Swap);
        }
        public static Keybind GetKBM_Swap()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Swap", "tab"), ControlScheme.KBM, ControlAction.Swap);
        }
        public static void SetKBM_Menu(string KBM_Menu)
        {
            PlayerPrefs.SetString("KBM_Menu", KBM_Menu);
        }
        public static Keybind GetKBM_Menu()
        {
            return new Keybind(PlayerPrefs.GetString("KBM_Menu", "escape"), ControlScheme.KBM, ControlAction.Menu);
        }
        // Joystick 1 Methods
        public static void SetJ1_Horizontal(string J1_Horizontal)
        {
            PlayerPrefs.SetString("J1_Horizontal", J1_Horizontal);
        }
        public static Keybind GetJ1_Horizontal()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Horizontal", "_J1_Axis1"), ControlScheme.J1, ControlAction.Horizontal);
        }
        public static void SetJ1_Vertical(string J1_Vertical)
        {
            PlayerPrefs.SetString("J1_Vertical", J1_Vertical);
        }
        public static Keybind GetJ1_Vertical()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Vertical", "_J1_Axis2"), ControlScheme.J1, ControlAction.Vertical);
        }
        public static void SetJ1_HorizontalSwipe(string J1_HorizontalSwipe)
        {
            PlayerPrefs.SetString("J1_HorizontalSwipe", J1_HorizontalSwipe);
        }
        public static Keybind GetJ1_HorizontalSwipe()
        {
            return new Keybind(PlayerPrefs.GetString("J1_HorizontalSwipe", "_J1_Axis4"), ControlScheme.J1, ControlAction.HorizontalSwipe);
        }
        public static void SetJ1_VerticalSwipe(string J1_VerticalSwipe)
        {
            PlayerPrefs.SetString("J1_VerticalSwipe", J1_VerticalSwipe);
        }
        public static Keybind GetJ1_VerticalSwipe()
        {
            return new Keybind(PlayerPrefs.GetString("J1_VerticalSwipe", "_J1_Axis5"), ControlScheme.J1, ControlAction.VerticalSwipe);
        }
        public static void SetJ1_Dash(string J1_Dash)
        {
            PlayerPrefs.SetString("J1_Dash", J1_Dash);
        }
        public static Keybind GetJ1_Dash()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Dash", "joystick 1 button 4"), ControlScheme.J1, ControlAction.Dash);
        }
        public static void SetJ1_Swipe(string J1_Swipe)
        {
            PlayerPrefs.SetString("J1_Swipe", J1_Swipe);
        }
        public static Keybind GetJ1_Swipe()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Swipe", "_J1_Axis9"), ControlScheme.J1, ControlAction.Swipe);
        }
        public static void SetJ1_Ranged(string J1_Ranged)
        {
            PlayerPrefs.SetString("J1_Ranged", J1_Ranged);
        }
        public static Keybind GetJ1_Ranged()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Ranged", "joystick 1 button 5"), ControlScheme.J1, ControlAction.Ranged);
        }
        public static void SetJ1_Casting(string J1_Casting)
        {
            PlayerPrefs.SetString("J1_Casting", J1_Casting);
        }
        public static Keybind GetJ1_Casting()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Casting", "_J1_Axis10"), ControlScheme.J1, ControlAction.Casting);
        }
        public static void SetJ1_Interact(string J1_Interact)
        {
            PlayerPrefs.SetString("J1_Interact", J1_Interact);
        }
        public static Keybind GetJ1_Interact()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Interact", "joystick 1 button 0"), ControlScheme.J1, ControlAction.Interact);
        }
        public static void SetJ1_Swap(string J1_Swap)
        {
            PlayerPrefs.SetString("J1_Swap", J1_Swap);
        }
        public static Keybind GetJ1_Swap()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Swap", "joystick 1 button 3"), ControlScheme.J1, ControlAction.Swap);
        }
        public static void SetJ1_Menu(string J1_Menu)
        {
            PlayerPrefs.SetString("J1_Menu", J1_Menu);
        }
        public static Keybind GetJ1_Menu()
        {
            return new Keybind(PlayerPrefs.GetString("J1_Menu", "joystick 1 button 7"), ControlScheme.J1, ControlAction.Menu);
        }
        // Joystick 2 Methods
        public static void SetJ2_Horizontal(string J2_Horizontal)
        {
            PlayerPrefs.SetString("J2_Horizontal", J2_Horizontal);
        }
        public static Keybind GetJ2_Horizontal()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Horizontal", "_J2_Axis1"), ControlScheme.J2, ControlAction.Horizontal);
        }
        public static void SetJ2_Vertical(string J2_Vertical)
        {
            PlayerPrefs.SetString("J2_Vertical", J2_Vertical);
        }
        public static Keybind GetJ2_Vertical()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Vertical", "_J2_Axis2"), ControlScheme.J2, ControlAction.Vertical);
        }
        public static void SetJ2_HorizontalSwipe(string J2_HorizontalSwipe)
        {
            PlayerPrefs.SetString("J2_HorizontalSwipe", J2_HorizontalSwipe);
        }
        public static Keybind GetJ2_HorizontalSwipe()
        {
            return new Keybind(PlayerPrefs.GetString("J2_HorizontalSwipe", "_J2_Axis4"), ControlScheme.J2, ControlAction.HorizontalSwipe);
        }
        public static void SetJ2_VerticalSwipe(string J2_VerticalSwipe)
        {
            PlayerPrefs.SetString("J2_VerticalSwipe", J2_VerticalSwipe);
        }
        public static Keybind GetJ2_VerticalSwipe()
        {
            return new Keybind(PlayerPrefs.GetString("J2_VerticalSwipe", "_J2_Axis5"), ControlScheme.J2, ControlAction.VerticalSwipe);
        }
        public static void SetJ2_Dash(string J2_Dash)
        {
            PlayerPrefs.SetString("J2_Dash", J2_Dash);
        }
        public static Keybind GetJ2_Dash()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Dash", "joystick 2 button 4"), ControlScheme.J2, ControlAction.Dash);
        }
        public static void SetJ2_Swipe(string J2_Swipe)
        {
            PlayerPrefs.SetString("J2_Swipe", J2_Swipe);
        }
        public static Keybind GetJ2_Swipe()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Swipe", "_J2_Axis9"), ControlScheme.J2, ControlAction.Swipe);
        }
        public static void SetJ2_Ranged(string J2_Ranged)
        {
            PlayerPrefs.SetString("J2_Ranged", J2_Ranged);
        }
        public static Keybind GetJ2_Ranged()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Ranged", "joystick 2 button 5"), ControlScheme.J2, ControlAction.Ranged);
        }
        public static void SetJ2_Casting(string J2_Casting)
        {
            PlayerPrefs.SetString("J2_Casting", J2_Casting);
        }
        public static Keybind GetJ2_Casting()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Casting", "_J2_Axis10"), ControlScheme.J2, ControlAction.Casting);
        }
        public static void SetJ2_Interact(string J2_Interact)
        {
            PlayerPrefs.SetString("J2_Interact", J2_Interact);
        }
        public static Keybind GetJ2_Interact()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Interact", "joystick 2 button 0"), ControlScheme.J2, ControlAction.Interact);
        }
        public static void SetJ2_Swap(string J2_Swap)
        {
            PlayerPrefs.SetString("J2_Swap", J2_Swap);
        }
        public static Keybind GetJ2_Swap()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Swap", "joystick 2 button 3"), ControlScheme.J2, ControlAction.Swap);
        }
        public static void SetJ2_Menu(string J2_Menu)
        {
            PlayerPrefs.SetString("J2_Menu", J2_Menu);
        }
        public static Keybind GetJ2_Menu()
        {
            return new Keybind(PlayerPrefs.GetString("J2_Menu", "joystick 2 button 7"), ControlScheme.J2, ControlAction.Menu);
        }
    }
}
