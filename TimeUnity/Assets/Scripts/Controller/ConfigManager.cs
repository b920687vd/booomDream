using System.Collections.Generic;
using System;
using TimeUnity.Utils;
using TimeUnity.Model;

namespace TimeUnity.Controller
{
    public class ConfigManager
    {
        //...
        private static ConfigManager _instance;
        public static ConfigManager Instance
        {
            get
            {
                if (ConfigManager._instance == null)
                {
                    ConfigManager._instance = new ConfigManager();
                }
                return ConfigManager._instance;
            }
        }

        public Dictionary<string, RoomItemData> configRoomItemData;

        public void Init()
        {
            LoadRoomItemData();
        }

        protected void LoadRoomItemData()
        {
            configRoomItemData = new Dictionary<string, RoomItemData>();
            CSVReader reader = new CSVReader();
            reader.ReadFile("Resources/Config/roomItems.csv");
            for (int i = reader.Length; i >= 0; i--)
            {
                RoomItemData item = new RoomItemData()
                {
                    ///
                    id = reader.GetValue("id", i),
                    canUse = reader.GetValue("canUse", i) == "true",
                    status = RoomItemStatus.idle,
                    needWaiting = reader.GetValue("needWaiting", i) == "true",
                    isSwitch = reader.GetValue("isSwitch", i) == "true",
                    timeUsing = int.Parse(reader.GetValue("timeUsing", i)),
                    timeActive = 0,
                    timeError = int.Parse(reader.GetValue("timeError", i)),
                    keyUse = reader.GetValue("keyUse", i),
                    descUse = reader.GetValue("descUse", i),
                    descClose = reader.GetValue("descClose", i),
                    descComplete = reader.GetValue("descComplete", i)
                };
                configRoomItemData.Add(item.id, item);
            }
        }

        public RoomItemData GetRoomItemConfig(string configId)
        {
            if (!configRoomItemData.ContainsKey(configId))
                return null;
            return configRoomItemData[configId].cloneConfig();
        }
    }
}