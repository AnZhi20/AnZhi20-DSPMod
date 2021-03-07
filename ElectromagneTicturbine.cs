using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xiaoye97;
using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using BepInEx.Configuration;

namespace ElectromagneTicturbineProject
{
    [BepInDependency("me.xiaoye97.plugin.Dyson.LDBTool", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("AnZhi.DSP.plugin.ElectromagneTicturbine", "ElectromagneTicturbine", "1.2.0")]
    public class ElectromagneTicturbine : BaseUnityPlugin
    {
        private Sprite icon;



        void Start()
        {
            var ab = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("ElectromagneTicturbineProject.electromagneticturbine"));
            icon = ab.LoadAsset<Sprite>("electromagneticturbinepng");

            LDBTool.PreAddDataAction += AddElectromagneTicturbine;
            LDBTool.PreAddDataAction += AddLang;
        }



        void AddElectromagneTicturbine()
        {
            var oriElectromagneTicturbineReciproto = LDB.recipes.Select(98);
            var newElectromagneTicturbineReciproto = oriElectromagneTicturbineReciproto.Copy();


            newElectromagneTicturbineReciproto.ID = 602;
            newElectromagneTicturbineReciproto.Name = "电磁涡轮（高效）";
            newElectromagneTicturbineReciproto.name = "电磁涡轮（高效）".Translate();
            newElectromagneTicturbineReciproto.Description = "用金伯利亚矿石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石减轻电磁涡轮的生产负担。再也不必为了生产电磁涡轮而感到苦恼。";
            newElectromagneTicturbineReciproto.description = "用金伯利亚矿石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石减轻电磁涡轮的生产负担。再也不必为了生产电磁涡轮而感到苦恼。".Translate();
            newElectromagneTicturbineReciproto.Items = new int[] { 1001, 1002, 1012, 1120 };
            newElectromagneTicturbineReciproto.Results = new int[] { 1204 };
            newElectromagneTicturbineReciproto.ItemCounts = new int[] { 4, 4, 2, 10 };
            newElectromagneTicturbineReciproto.ResultCounts = new int[] { 1 };
            newElectromagneTicturbineReciproto.Explicit = true;
            newElectromagneTicturbineReciproto.preTech = LDB.techs.Select(1702);
            newElectromagneTicturbineReciproto.TimeSpend = 300;
            newElectromagneTicturbineReciproto.GridIndex = 1611;
            newElectromagneTicturbineReciproto.SID = "1611";
            newElectromagneTicturbineReciproto.sid = "1611".Translate();
            Traverse.Create(newElectromagneTicturbineReciproto).Field("_iconSprite").SetValue(icon);

            var oriElectromagneticturbine = LDB.items.Select(1204);
            oriElectromagneticturbine.recipes.Add(newElectromagneTicturbineReciproto);

            LDBTool.PostAddProto(ProtoType.Recipe, newElectromagneTicturbineReciproto);
        }



        void AddLang()
        {
            StringProto name = new StringProto();
            StringProto desc = new StringProto();

            name.ID = 52001;
            name.Name = "电磁涡轮（高效）";
            name.name = "电磁涡轮（高效）";
            name.ZHCN = "电磁涡轮（高效）";
            name.ENUS = "Electromagnetic turbine (high efficiency)";

            desc.ID = 52002;
            desc.Name = "用金伯利亚矿石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石减轻电磁涡轮的生产负担。再也不必为了生产电磁涡轮而感到苦恼。";
            desc.name = "用金伯利亚矿石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石减轻电磁涡轮的生产负担。再也不必为了生产电磁涡轮而感到苦恼。"; ;
            desc.ZHCN = "用金伯利亚矿石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石减轻电磁涡轮的生产负担。再也不必为了生产电磁涡轮而感到苦恼。";
            desc.ENUS = "Using kimberlite can shorten your production line, which can reduce the production burden of electromagnetic turbine by using idle or even less useful kimberlite. No longer have to worry about making electromagnetic turbines.";

        }
    }
}
