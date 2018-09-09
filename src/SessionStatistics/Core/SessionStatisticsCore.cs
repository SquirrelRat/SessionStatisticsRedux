using System;
using System.Collections.Generic;
using System.Linq;

using PoeHUD.Plugins;
using PoeHUD.Models;
using PoeHUD.Poe.Components;
using PoeHUD.Framework;

using SessionStatistics.Classes;

namespace SessionStatistics
{
    public class SessionStatisticsCore : BaseSettingsPlugin<Core.SessionStatisticsSettings>
    {
        //Booleans
       
        public static Core.SessionStatisticsSettings SettingsInstance;
        public static String WorkingDirectory;
        public static Session Session;

        public override void Initialise()
        {
            SettingsInstance = Settings;
            PluginName = "Session Statistics ReDUX";
            GameController.Area.OnAreaChange += Event_OnAreaChange;
            WorkingDirectory = LocalPluginDirectory;
            Session = Session.Instance;
        }

        private void Event_OnAreaChange(PoeHUD.Controllers.AreaController obj)
        {
            Session.Instance.ResetArea();
        }

        public override void Render()
        {
           
            if (this.GameController.InGame)
            {
                
                
                if (Settings.EnableTopBar)
                {
                    Visuals.TopBar.Instance.Draw();
                }
                
                if (!this.GameController.Area.CurrentArea.IsHideout && !this.GameController.Area.CurrentArea.IsTown)
                {
                    Session.Instance.CurrentArea.Update();
                }
            }
            base.Render();
        }
       
        
    }
}
