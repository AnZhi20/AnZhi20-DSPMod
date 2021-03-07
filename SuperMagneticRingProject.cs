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

namespace SuperMagneticRingProject
{
    [BepInDependency("me.xiaoye97.plugin.Dyson.LDBTool", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("AnZhi.DSP.plugin.SuperMagneticRing", "SuperMagneticRing", "1.0.0")]
    public class SuperMagneticRing : BaseUnityPlugin
    {
        private Sprite icon;



        void Start()
        {
            var ab = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("SuperMagneticRingProject.supermagneticring"));
            icon = ab.LoadAsset<Sprite>("supermagneticring");

            LDBTool.PreAddDataAction += AddSuperMagneticRing;
            LDBTool.PreAddDataAction += AddLang;
        }



        void AddSuperMagneticRing()
        {
            var oriSuperMagneticRingReciproto = LDB.recipes.Select(103);
            var newSuperMagneticRingReciproto = oriSuperMagneticRingReciproto.Copy();


            newSuperMagneticRingReciproto.ID = 601;
            newSuperMagneticRingReciproto.Name = "超级磁场环（高效）";
            newSuperMagneticRingReciproto.name = "超级磁场环（高效）".Translate();
            newSuperMagneticRingReciproto.Description = "用金伯利亚矿石和分型硅石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石和分型硅石减轻超级磁场环的生产负担。再也不必为了生产超级磁场环而感到苦恼。";
            newSuperMagneticRingReciproto.description = "用金伯利亚矿石和分型硅石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石和分型硅石减轻超级磁场环的生产负担。再也不必为了生产超级磁场环而感到苦恼。".Translate();
            newSuperMagneticRingReciproto.Items = new int[] { 1012,1013,1121 };
            newSuperMagneticRingReciproto.Results = new int[] { 1205 };
            newSuperMagneticRingReciproto.ItemCounts = new int[] { 2,4,6 };
            newSuperMagneticRingReciproto.ResultCounts = new int[] { 1 };
            newSuperMagneticRingReciproto.Explicit = true;
            newSuperMagneticRingReciproto.preTech = LDB.techs.Select(1711);
            newSuperMagneticRingReciproto.TimeSpend = 420;
            newSuperMagneticRingReciproto.GridIndex = 1612;
            newSuperMagneticRingReciproto.SID = "1612";
            newSuperMagneticRingReciproto.sid = "1612".Translate();
            Traverse.Create(newSuperMagneticRingReciproto).Field("_iconSprite").SetValue(icon);

            var oriSupermagneticring = LDB.items.Select(1205);
            oriSupermagneticring.recipes.Add(newSuperMagneticRingReciproto);

            LDBTool.PostAddProto(ProtoType.Recipe, newSuperMagneticRingReciproto);
        }



        void AddLang()
        {
            StringProto name = new StringProto();
            StringProto desc = new StringProto();

            name.ID = 52003;
            name.Name = "超级磁场环（高效）";
            name.name = "超级磁场环（高效）";
            name.ZHCN = "超级磁场环（高效）";
            name.ENUS = "Super magnetic field ring (high efficiency)";

            desc.ID = 52004;
            desc.Name = "用金伯利亚矿石和分型硅石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石和分型硅石减轻超级磁场环的生产负担。再也不必为了生产超级磁场环而感到苦恼。";
            desc.name = "用金伯利亚矿石和分型硅石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石和分型硅石减轻超级磁场环的生产负担。再也不必为了生产超级磁场环而感到苦恼。"; ;
            desc.ZHCN = "用金伯利亚矿石和分型硅石可以缩短你的生产线，这样可以利用闲置的甚至说用处不太大的金伯利亚矿石和分型硅石减轻超级磁场环的生产负担。再也不必为了生产超级磁场环而感到苦恼。";
            desc.ENUS = "Using kimberlite and classification silica can shorten your production line, so that you can use idle or even less useful kimberlite and classification silica to reduce the production burden of super magnetic ring. No longer have to worry about producing super magnetic rings.";

        }
    }
}
