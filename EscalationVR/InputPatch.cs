using System;
using HarmonyLib;
using UnityEngine;

namespace EscalationVR
{
	// Token: 0x020000ED RID: 237
	public class InputPatch
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x0001D4C4 File Offset: 0x0001B6C4
		[global::HarmonyLib.HarmonyPatch(typeof(global::WindowManager), "GetClicked")]
		[global::HarmonyLib.HarmonyPostfix]
		public static void GetClickedPost(global::WindowManager __instance)
		{
			bool keyDown = global::UnityEngine.Input.GetKeyDown(13);
			if (keyDown)
			{
				__instance.GetType().GetField("Clicked", 36).SetValue(__instance, true);
				__instance.GetType().GetField("Click_cnt", 36).SetValue(__instance, 1);
			}
			bool keyDown2 = global::UnityEngine.Input.GetKeyDown(32);
			if (keyDown2)
			{
				__instance.GetType().GetField("RightClicked", 36).SetValue(__instance, true);
				__instance.GetType().GetField("RightClick_cnt", 36).SetValue(__instance, 1);
			}
		}
	}
}
