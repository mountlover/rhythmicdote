using System;
using UnityEngine;

namespace Rhythmicdote
{
    public class GameState
    {
        public float Horizontal_Coord { get; private set; }
        public float Vertical_Coord { get; private set; }
        public long Time { get; private set; }
        private GameState()
        {

        }
        public static void SaveGameState(GameState s, bool p2)
        {
            PlayerPrefs.SetFloat((p2 ? "P2_" : "") + "Horizonal_Coord", s.Horizontal_Coord);
            PlayerPrefs.SetFloat((p2 ? "P2_" : "") + "Vertical_Coord", s.Vertical_Coord);
            PlayerPrefs.SetString("Time", "" + s.Time);
        }
        public static GameState LoadGameState(bool p2)
        {
            GameState s = new GameState();
            s.Horizontal_Coord = PlayerPrefs.GetFloat((p2 ? "P2_" : "") + "Horizonal_Coord", 0);
            s.Vertical_Coord = PlayerPrefs.GetFloat((p2 ? "P2_" : "") + "Vertical_Coord", 0);
            s.Time = Convert.ToInt64(PlayerPrefs.GetString("Time", "0"));
            return s;
        }
        public void Tick()
        {
            Time++;
        }
        public void Move(double speed, double angleRad)
        {
            Horizontal_Coord += GlobalFunctions.Snap(Math.Sin(angleRad) * (speed / GlobalFunctions.PIXELS_PER_UNIT));
            Vertical_Coord += GlobalFunctions.Snap(Math.Cos(angleRad) * (speed / GlobalFunctions.PIXELS_PER_UNIT));
        }
        public void Move(double speed, double horizontal, double vertical)
        {
            if(horizontal == 0)
            {
                if(vertical > 0) Vertical_Coord += GlobalFunctions.Snap((speed / GlobalFunctions.PIXELS_PER_UNIT));
                if(vertical < 0) Vertical_Coord -= GlobalFunctions.Snap((speed / GlobalFunctions.PIXELS_PER_UNIT));
            }
            else if(vertical == 0)
            {
                if(horizontal > 0) Horizontal_Coord += GlobalFunctions.Snap((speed / GlobalFunctions.PIXELS_PER_UNIT));
                if(horizontal < 0) Horizontal_Coord -= GlobalFunctions.Snap((speed / GlobalFunctions.PIXELS_PER_UNIT));
            }
            else
            {
                Move(speed, Math.Atan2(vertical, horizontal));
            }
        }
    }
}
