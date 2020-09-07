using System;
using EscalationVR;
using UnityEngine;

// Token: 0x0200000C RID: 12
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class SteamVR_GameView : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600007A RID: 122 RVA: 0x00005920 File Offset: 0x00003B20
	private void OnEnable()
	{
		bool flag = global::SteamVR_GameView.overlayMaterial == null;
		if (flag)
		{
			global::SteamVR_GameView.overlayMaterial = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_Overlay"));
		}
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00005954 File Offset: 0x00003B54
	private void OnPostRender()
	{
		global::SteamVR instance = global::SteamVR.instance;
		global::UnityEngine.Camera component = base.GetComponent<global::UnityEngine.Camera>();
		float num = this.scale * component.aspect / instance.aspect;
		float num2 = -this.scale;
		float num3 = this.scale;
		float num4 = num;
		float num5 = -num;
		global::UnityEngine.Material blitMaterial = global::SteamVR_Camera.blitMaterial;
		blitMaterial.mainTexture = global::SteamVR_Camera.GetSceneTexture(component.allowHDR);
		global::UnityEngine.GL.PushMatrix();
		global::UnityEngine.GL.LoadOrtho();
		blitMaterial.SetPass(0);
		global::UnityEngine.GL.Begin(7);
		global::UnityEngine.GL.TexCoord2(0f, 0f);
		global::UnityEngine.GL.Vertex3(num2, num4, 0f);
		global::UnityEngine.GL.TexCoord2(1f, 0f);
		global::UnityEngine.GL.Vertex3(num3, num4, 0f);
		global::UnityEngine.GL.TexCoord2(1f, 1f);
		global::UnityEngine.GL.Vertex3(num3, num5, 0f);
		global::UnityEngine.GL.TexCoord2(0f, 1f);
		global::UnityEngine.GL.Vertex3(num2, num5, 0f);
		global::UnityEngine.GL.End();
		global::UnityEngine.GL.PopMatrix();
		global::SteamVR_Overlay instance2 = global::SteamVR_Overlay.instance;
		bool flag = instance2 && instance2.texture && global::SteamVR_GameView.overlayMaterial && this.drawOverlay;
		if (flag)
		{
			global::UnityEngine.Texture texture = instance2.texture;
			global::SteamVR_GameView.overlayMaterial.mainTexture = texture;
			float num6 = 0f;
			float num7 = 1f - (float)global::UnityEngine.Screen.height / (float)texture.height;
			float num8 = (float)global::UnityEngine.Screen.width / (float)texture.width;
			float num9 = 1f;
			global::UnityEngine.GL.PushMatrix();
			global::UnityEngine.GL.LoadOrtho();
			global::SteamVR_GameView.overlayMaterial.SetPass((global::UnityEngine.QualitySettings.activeColorSpace == 1) ? 1 : 0);
			global::UnityEngine.GL.Begin(7);
			global::UnityEngine.GL.TexCoord2(num6, num7);
			global::UnityEngine.GL.Vertex3(-1f, -1f, 0f);
			global::UnityEngine.GL.TexCoord2(num8, num7);
			global::UnityEngine.GL.Vertex3(1f, -1f, 0f);
			global::UnityEngine.GL.TexCoord2(num8, num9);
			global::UnityEngine.GL.Vertex3(1f, 1f, 0f);
			global::UnityEngine.GL.TexCoord2(num6, num9);
			global::UnityEngine.GL.Vertex3(-1f, 1f, 0f);
			global::UnityEngine.GL.End();
			global::UnityEngine.GL.PopMatrix();
		}
	}

	// Token: 0x04000045 RID: 69
	public float scale = 1.5f;

	// Token: 0x04000046 RID: 70
	public bool drawOverlay = true;

	// Token: 0x04000047 RID: 71
	private static global::UnityEngine.Material overlayMaterial;
}
