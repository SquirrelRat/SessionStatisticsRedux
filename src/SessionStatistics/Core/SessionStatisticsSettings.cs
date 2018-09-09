using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Plugins;
using PoeHUD.Hud.Settings;

namespace SessionStatistics.Core
{
    public class SessionStatisticsSettings : SettingsBase
    {
        #region Settings-Menu
        [Menu("Settings", 200)]
        public EmptyNode SettingsMenuNode { get; set; }
        [Menu("Textsize", 201, 200)]
        public RangeNode<Int32> TextSize { get; set; }
        [Menu("Experience Bar", 202, 200)]
        public ToggleNode EnableTopBar { get; set; }
        [Menu("Position X", 300, 202)]
        public RangeNode<float> TopBarXPos { get; set; }
        [Menu("Position Y", 301, 202)]
        public RangeNode<float> TopBarYPos { get; set; }

        


    #endregion
    public SessionStatisticsSettings()
        {
            Enable = true;

            

            SettingsMenuNode = new EmptyNode();
            TextSize = new RangeNode<int>(18, 12, 36);
            EnableTopBar = new ToggleNode(true);
            TopBarXPos = new RangeNode<float>(0,0, SessionStatisticsCore.API.GameController.Window.GetWindowRectangle().BottomRight.X);
            TopBarYPos = new RangeNode<float>(0,0, SessionStatisticsCore.API.GameController.Window.GetWindowRectangle().BottomRight.Y);
           

    }
    }
}
