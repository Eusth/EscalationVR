using System;
using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EscalationVR
{
	// Token: 0x02000002 RID: 2
	[global::BepInEx.BepInPlugin("ch.zomg.escalation.uncensor", "Escalation uncensor", "1.0.0.0")]
	public class UncensorPlugin : global::BepInEx.BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			foreach (global::UnityEngine.Material material in global::UnityEngine.Resources.LoadAll<global::UnityEngine.Material>(""))
			{
				material.SetFloat("_BlockSize", 1f);
			}
			global::UnityEngine.SceneManagement.SceneManager.activeSceneChanged += delegate(global::UnityEngine.SceneManagement.Scene arg0, global::UnityEngine.SceneManagement.Scene scene)
			{
				this.Uncensor();
			};
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020A4 File Offset: 0x000002A4
		private void Uncensor()
		{
			foreach (global::UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer in global::UnityEngine.Object.FindObjectsOfType<global::UnityEngine.SkinnedMeshRenderer>())
			{
				skinnedMeshRenderer.sharedMaterial.SetFloat("_BlockSize", 1f);
			}
		}
	}
}
