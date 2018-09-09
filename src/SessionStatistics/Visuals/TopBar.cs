using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;

using SessionStatistics.Classes;

namespace SessionStatistics.Visuals
{
    class TopBar
    {
        #region Instance-Specific
        private static TopBar _instance;
        public static TopBar Instance { get { return _instance ?? (_instance = new TopBar(new SharpDX.Vector2())); } }
        #endregion

        private List<ContentBox> Boxes = new List<ContentBox>();
        private float NeededSpace { get { float result = 0.0f; Boxes.ForEach(Box => result += Box.BoxSize.Width + 5); return result; } }

        private SharpDX.Color EndBoxesColor = new SharpDX.Color() { R = 0, G = 80, B = 255, A = 127 };
        private SharpDX.Color MiddleBoxesColor = new SharpDX.Color() { R = 0, G = 140, B = 255, A = 127 };
        private Int32 TextSize { get { return SessionStatisticsCore.SettingsInstance.TextSize; } }
        public TopBar(SharpDX.Vector2 Position)
        {
            Boxes.Add(new ContentBox());
            Boxes.Add(new ContentBox(Color.Black));
            Boxes.Add(new ContentBox());
            Boxes.Add(new ContentBox(Color.Black));
          //  Boxes.Add(new ContentBox(Color.Black));
        }
        private void Update()
        {
            var _windowRect = SessionStatisticsCore.API.GameController.Window.GetWindowRectangle();
            var _posfrompercent = (SessionStatisticsCore.SettingsInstance.TopBarXPos);
            var _posfrompercent2 = (SessionStatisticsCore.SettingsInstance.TopBarYPos);
            var _position = (float)_posfrompercent - (NeededSpace / 2);
            var _position2 = (float)_posfrompercent2;
            var _levelPlusFive = Math.Ceiling((Player.Level + 1) / 5.0) * 5;

            Boxes[0].BoxColor = new Color() { R = 0, G = 0, B = 0, A = 170 };
            Boxes[1].BoxColor = new Color() { R = 255, G = 255, B = 255, A = 170 };
            Boxes[2].BoxColor = new Color() { R = 0, G = 0, B = 0, A = 170 };
            Boxes[3].BoxColor = new Color() { R = 255, G = 255, B = 255, A = 170 };
            Boxes[0].TextToDraw = Player.Level.ToString("Current Level: #");
            Boxes[1].TextToDraw = String.Format("Time To Level: {1} / {2} Runs", (Player.Level + 1).ToString(), Player.TimeToLevel(Player.Level + 1).ToString("hh\\:mm\\:ss"), Player.RunsToLevel((Int32)Player.Level + 1));
            Boxes[2].TextToDraw = String.Format("Area: {0}", (Player.Area.DisplayName).ToString(), Session.Instance.AreaStatistic.GetPlaytime());
            Boxes[3].TextToDraw = String.Format("Area Timer: {0}", Session.Instance.AreaStatistic.GetPlaytime());

            foreach (ContentBox Box in Boxes)
            {
                Box.Update();
                Box.BoxPositon.X = _position;
                _position += Box.BoxSize.Width + 10;
                Box.BoxPositon.Y = _position2;
                _position2 = Box.BoxPositon.Y;
                
            }
        }
        public void Draw()
        {
            Update();
            Boxes.ForEach(box => box.Draw());
        }
        
    }
}
