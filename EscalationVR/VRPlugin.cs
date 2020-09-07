using System;
using System.Reflection;
using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRGIN.Core;
using VRGIN.Helpers;

namespace EscalationVR
{
	// Token: 0x020000F3 RID: 243
	[global::BepInEx.BepInPlugin("ch.zomg.vr", "Escalation VR", "1.0.0.0")]
	public class VRPlugin : global::BepInEx.BaseUnityPlugin
	{
		// Token: 0x06000635 RID: 1589 RVA: 0x0001E09C File Offset: 0x0001C29C
		private void Awake()
		{
			global::EscalationVR.EscalationVRContext context = new global::EscalationVR.EscalationVRContext();
			global::VRGIN.Core.VRManager.Create<global::EscalationVR.EscalationInterpreter>(context);
			global::VRGIN.Core.VR.Manager.SetMode<global::EscalationVR.MasoMode>();
			global::UnityEngine.SceneManagement.SceneManager.activeSceneChanged += delegate(global::UnityEngine.SceneManagement.Scene current, global::UnityEngine.SceneManagement.Scene next)
			{
				global::UnityChanLipSync lipSync = global::UnityEngine.Object.FindObjectOfType<global::UnityChanLipSync>();
				global::FlagActivator_Skanojo flagActivator_Skanojo = global::UnityEngine.Object.FindObjectOfType<global::FlagActivator_Skanojo>();
				bool flag = lipSync;
				if (flag)
				{
					bool flag2 = !lipSync.audio_.spatialize;
					if (flag2)
					{
						global::UnityEngine.Debug.Log("SPATIALIZE");
						global::UnityEngine.Transform transform = flagActivator_Skanojo.transform.FindDescendant("Head");
						global::UnityEngine.AudioSource audioSource = global::VRGIN.Helpers.UnityHelper.CopyComponent<global::UnityEngine.AudioSource>(lipSync.audio_, transform.gameObject);
						global::System.Reflection.MethodInfo onAudioFilterRead = typeof(global::LipSyncCore).GetMethod("OnAudioFilterRead", 36);
						object[] parameterArray = new object[2];
						audioSource.gameObject.AddComponent<global::EscalationVR.ForwardAudioEvent>().AudioFilterRead = delegate(float[] p1, int p2)
						{
							parameterArray[0] = p1;
							parameterArray[1] = p2;
							onAudioFilterRead.Invoke(lipSync, parameterArray);
						};
						lipSync.audio_ = audioSource;
						lipSync.audio_.spatialize = true;
						lipSync.audio_.spatialBlend = 1f;
					}
				}
			};
		}
	}
}
