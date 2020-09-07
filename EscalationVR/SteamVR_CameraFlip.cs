using System;
using EscalationVR;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class SteamVR_CameraFlip : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000048 RID: 72 RVA: 0x00003908 File Offset: 0x00001B08
	private void OnEnable()
	{
		bool flag = global::SteamVR_CameraFlip.blitMaterial == null;
		if (flag)
		{
			global::SteamVR_CameraFlip.blitMaterial = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_BlitFlip"));
		}
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00003939 File Offset: 0x00001B39
	private void OnRenderImage(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dest)
	{
		global::UnityEngine.Graphics.Blit(src, dest, global::SteamVR_CameraFlip.blitMaterial);
	}

	// Token: 0x0400001E RID: 30
	private static global::UnityEngine.Material blitMaterial;
}
