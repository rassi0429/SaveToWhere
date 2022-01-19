using HarmonyLib;
using NeosModLoader;
using System;
using System.Reflection;
using FrooxEngine;
using BaseX;
using CloudX.Shared;
using CodeX;
using FrooxEngine.UIX;
using System.Collections.Generic;

namespace SaveToWhere
{
    public class SaveToWhere : NeosMod
    {
        public override string Name => "SaveToWhere";
        public override string Author => "kka429";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/rassi0429/SaveToWhere"; // this line is optional and can be omitted

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("dev.kokoa.savetowhere");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(LocaleHelper), "AsLocaleKey", new Type[] { typeof(string), typeof(bool), typeof(Dictionary<string, object>) })]
        class Patch
        {
            static void Postfix(ref LocaleString __result, string str)
            {
                if(str == "Interaction.SaveToInventory")
                {                 
                    __result = "Save To : \n /" + InventoryBrowser.CurrentUserspaceInventory?.CurrentPath;
                }
            }
        }
    }
}