using System;
using EscalationVR;
using UnityEngine;
using Valve.VR;

// Token: 0x0200000A RID: 10
public class SteamVR_Fade : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600006D RID: 109 RVA: 0x00004FB7 File Offset: 0x000031B7
	public static void Start(global::UnityEngine.Color newColor, float duration, bool fadeOverlay = false)
	{
		global::SteamVR_Utils.Event.Send("fade", new object[]
		{
			newColor,
			duration,
			fadeOverlay
		});
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00004FE8 File Offset: 0x000031E8
	public static void View(global::UnityEngine.Color newColor, float duration)
	{
		global::Valve.VR.CVRCompositor compositor = global::Valve.VR.OpenVR.Compositor;
		bool flag = compositor != null;
		if (flag)
		{
			compositor.FadeToColor(duration, newColor.r, newColor.g, newColor.b, newColor.a, false);
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00005028 File Offset: 0x00003228
	public void OnStartFade(params object[] args)
	{
		global::UnityEngine.Color color = (global::UnityEngine.Color)args[0];
		float num = (float)args[1];
		this.fadeOverlay = (args.Length > 2 && (bool)args[2]);
		bool flag = num > 0f;
		if (flag)
		{
			this.targetColor = color;
			this.deltaColor = (this.targetColor - this.currentColor) / num;
		}
		else
		{
			this.currentColor = color;
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x0000509C File Offset: 0x0000329C
	private void OnEnable()
	{
		bool flag = global::SteamVR_Fade.fadeMaterial == null;
		if (flag)
		{
			global::SteamVR_Fade.fadeMaterial = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_Fade"));
		}
		global::SteamVR_Utils.Event.Listen("fade", new global::SteamVR_Utils.Event.Handler(this.OnStartFade));
		global::SteamVR_Utils.Event.Send("fade_ready", global::System.Array.Empty<object>());
	}

	// Token: 0x06000071 RID: 113 RVA: 0x000050F6 File Offset: 0x000032F6
	private void OnDisable()
	{
		global::SteamVR_Utils.Event.Remove("fade", new global::SteamVR_Utils.Event.Handler(this.OnStartFade));
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00005110 File Offset: 0x00003310
	private void OnPostRender()
	{
		bool flag = this.currentColor != this.targetColor;
		if (flag)
		{
			bool flag2 = global::UnityEngine.Mathf.Abs(this.currentColor.a - this.targetColor.a) < global::UnityEngine.Mathf.Abs(this.deltaColor.a) * global::UnityEngine.Time.deltaTime;
			if (flag2)
			{
				this.currentColor = this.targetColor;
				this.deltaColor = new global::UnityEngine.Color(0f, 0f, 0f, 0f);
			}
			else
			{
				this.currentColor += this.deltaColor * global::UnityEngine.Time.deltaTime;
			}
			bool flag3 = this.fadeOverlay;
			if (flag3)
			{
				global::SteamVR_Overlay instance = global::SteamVR_Overlay.instance;
				bool flag4 = instance != null;
				if (flag4)
				{
					instance.alpha = 1f - this.currentColor.a;
				}
			}
		}
		bool flag5 = this.currentColor.a > 0f && global::SteamVR_Fade.fadeMaterial;
		if (flag5)
		{
			global::UnityEngine.GL.PushMatrix();
			global::UnityEngine.GL.LoadOrtho();
			global::SteamVR_Fade.fadeMaterial.SetPass(0);
			global::UnityEngine.GL.Begin(7);
			global::UnityEngine.GL.Color(this.currentColor);
			global::UnityEngine.GL.Vertex3(0f, 0f, 0f);
			global::UnityEngine.GL.Vertex3(1f, 0f, 0f);
			global::UnityEngine.GL.Vertex3(1f, 1f, 0f);
			global::UnityEngine.GL.Vertex3(0f, 1f, 0f);
			global::UnityEngine.GL.End();
			global::UnityEngine.GL.PopMatrix();
		}
	}

	// Token: 0x04000039 RID: 57
	private global::UnityEngine.Color currentColor = new global::UnityEngine.Color(0f, 0f, 0f, 0f);

	// Token: 0x0400003A RID: 58
	private global::UnityEngine.Color targetColor = new global::UnityEngine.Color(0f, 0f, 0f, 0f);

	// Token: 0x0400003B RID: 59
	private global::UnityEngine.Color deltaColor = new global::UnityEngine.Color(0f, 0f, 0f, 0f);

	// Token: 0x0400003C RID: 60
	private bool fadeOverlay = false;

	// Token: 0x0400003D RID: 61
	private static global::UnityEngine.Material fadeMaterial = null;
}
