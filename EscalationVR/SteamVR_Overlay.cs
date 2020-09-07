using System;
using System.Runtime.InteropServices;
using UnityEngine;
using Valve.VR;

// Token: 0x02000010 RID: 16
public class SteamVR_Overlay : global::UnityEngine.MonoBehaviour
{
	// Token: 0x17000021 RID: 33
	// (get) Token: 0x06000098 RID: 152 RVA: 0x000072F0 File Offset: 0x000054F0
	// (set) Token: 0x06000099 RID: 153 RVA: 0x000072F7 File Offset: 0x000054F7
	public static global::SteamVR_Overlay instance { get; private set; }

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x0600009A RID: 154 RVA: 0x00007300 File Offset: 0x00005500
	public static string key
	{
		get
		{
			return "unity:" + global::UnityEngine.Application.companyName + "." + global::UnityEngine.Application.productName;
		}
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000732C File Offset: 0x0000552C
	private void OnEnable()
	{
		global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
		bool flag = overlay != null;
		if (flag)
		{
			global::Valve.VR.EVROverlayError evroverlayError = overlay.CreateOverlay(global::SteamVR_Overlay.key, base.gameObject.name, ref this.handle);
			bool flag2 = evroverlayError > global::Valve.VR.EVROverlayError.None;
			if (flag2)
			{
				global::UnityEngine.Debug.Log(overlay.GetOverlayErrorNameFromEnum(evroverlayError));
				base.enabled = false;
				return;
			}
		}
		global::SteamVR_Overlay.instance = this;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00007390 File Offset: 0x00005590
	private void OnDisable()
	{
		bool flag = this.handle > 0UL;
		if (flag)
		{
			global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
			bool flag2 = overlay != null;
			if (flag2)
			{
				overlay.DestroyOverlay(this.handle);
			}
			this.handle = 0UL;
		}
		global::SteamVR_Overlay.instance = null;
	}

	// Token: 0x0600009D RID: 157 RVA: 0x000073DC File Offset: 0x000055DC
	public void UpdateOverlay()
	{
		global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
		bool flag = overlay == null;
		if (!flag)
		{
			bool flag2 = this.texture != null;
			if (flag2)
			{
				global::Valve.VR.EVROverlayError evroverlayError = overlay.ShowOverlay(this.handle);
				bool flag3 = evroverlayError == global::Valve.VR.EVROverlayError.InvalidHandle || evroverlayError == global::Valve.VR.EVROverlayError.UnknownOverlay;
				if (flag3)
				{
					bool flag4 = overlay.FindOverlay(global::SteamVR_Overlay.key, ref this.handle) > global::Valve.VR.EVROverlayError.None;
					if (flag4)
					{
						return;
					}
				}
				global::Valve.VR.Texture_t texture_t = default(global::Valve.VR.Texture_t);
				texture_t.handle = this.texture.GetNativeTexturePtr();
				texture_t.eType = global::SteamVR.instance.graphicsAPI;
				texture_t.eColorSpace = global::Valve.VR.EColorSpace.Auto;
				overlay.SetOverlayTexture(this.handle, ref texture_t);
				overlay.SetOverlayAlpha(this.handle, this.alpha);
				overlay.SetOverlayWidthInMeters(this.handle, this.scale);
				overlay.SetOverlayAutoCurveDistanceRangeInMeters(this.handle, this.curvedRange.x, this.curvedRange.y);
				global::Valve.VR.VRTextureBounds_t vrtextureBounds_t = default(global::Valve.VR.VRTextureBounds_t);
				vrtextureBounds_t.uMin = (0f + this.uvOffset.x) * this.uvOffset.z;
				vrtextureBounds_t.vMin = (1f + this.uvOffset.y) * this.uvOffset.w;
				vrtextureBounds_t.uMax = (1f + this.uvOffset.x) * this.uvOffset.z;
				vrtextureBounds_t.vMax = (0f + this.uvOffset.y) * this.uvOffset.w;
				overlay.SetOverlayTextureBounds(this.handle, ref vrtextureBounds_t);
				global::Valve.VR.HmdVector2_t hmdVector2_t = default(global::Valve.VR.HmdVector2_t);
				hmdVector2_t.v0 = this.mouseScale.x;
				hmdVector2_t.v1 = this.mouseScale.y;
				overlay.SetOverlayMouseScale(this.handle, ref hmdVector2_t);
				global::SteamVR_Camera steamVR_Camera = global::SteamVR_Render.Top();
				bool flag5 = steamVR_Camera != null && steamVR_Camera.origin != null;
				if (flag5)
				{
					global::SteamVR_Utils.RigidTransform rigidTransform = new global::SteamVR_Utils.RigidTransform(steamVR_Camera.origin, base.transform);
					rigidTransform.pos.x = rigidTransform.pos.x / steamVR_Camera.origin.localScale.x;
					rigidTransform.pos.y = rigidTransform.pos.y / steamVR_Camera.origin.localScale.y;
					rigidTransform.pos.z = rigidTransform.pos.z / steamVR_Camera.origin.localScale.z;
					rigidTransform.pos.z = rigidTransform.pos.z + this.distance;
					global::Valve.VR.HmdMatrix34_t hmdMatrix34_t = rigidTransform.ToHmdMatrix34();
					overlay.SetOverlayTransformAbsolute(this.handle, global::SteamVR_Render.instance.trackingSpace, ref hmdMatrix34_t);
				}
				overlay.SetOverlayInputMethod(this.handle, this.inputMethod);
				bool flag6 = this.curved || this.antialias;
				if (flag6)
				{
					this.highquality = true;
				}
				bool flag7 = this.highquality;
				if (flag7)
				{
					overlay.SetHighQualityOverlay(this.handle);
					overlay.SetOverlayFlag(this.handle, global::Valve.VR.VROverlayFlags.Curved, this.curved);
					overlay.SetOverlayFlag(this.handle, global::Valve.VR.VROverlayFlags.RGSS4X, this.antialias);
				}
				else
				{
					bool flag8 = overlay.GetHighQualityOverlay() == this.handle;
					if (flag8)
					{
						overlay.SetHighQualityOverlay(0UL);
					}
				}
			}
			else
			{
				overlay.HideOverlay(this.handle);
			}
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00007744 File Offset: 0x00005944
	public bool PollNextEvent(ref global::Valve.VR.VREvent_t pEvent)
	{
		global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
		bool flag = overlay == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			uint uncbVREvent = (uint)global::System.Runtime.InteropServices.Marshal.SizeOf(typeof(global::Valve.VR.VREvent_t));
			result = overlay.PollNextOverlayEvent(this.handle, ref pEvent, uncbVREvent);
		}
		return result;
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00007788 File Offset: 0x00005988
	public bool ComputeIntersection(global::UnityEngine.Vector3 source, global::UnityEngine.Vector3 direction, ref global::SteamVR_Overlay.IntersectionResults results)
	{
		global::Valve.VR.CVROverlay overlay = global::Valve.VR.OpenVR.Overlay;
		bool flag = overlay == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			global::Valve.VR.VROverlayIntersectionParams_t vroverlayIntersectionParams_t = default(global::Valve.VR.VROverlayIntersectionParams_t);
			vroverlayIntersectionParams_t.eOrigin = global::SteamVR_Render.instance.trackingSpace;
			vroverlayIntersectionParams_t.vSource.v0 = source.x;
			vroverlayIntersectionParams_t.vSource.v1 = source.y;
			vroverlayIntersectionParams_t.vSource.v2 = -source.z;
			vroverlayIntersectionParams_t.vDirection.v0 = direction.x;
			vroverlayIntersectionParams_t.vDirection.v1 = direction.y;
			vroverlayIntersectionParams_t.vDirection.v2 = -direction.z;
			global::Valve.VR.VROverlayIntersectionResults_t vroverlayIntersectionResults_t = default(global::Valve.VR.VROverlayIntersectionResults_t);
			bool flag2 = !overlay.ComputeOverlayIntersection(this.handle, ref vroverlayIntersectionParams_t, ref vroverlayIntersectionResults_t);
			if (flag2)
			{
				result = false;
			}
			else
			{
				results.point = new global::UnityEngine.Vector3(vroverlayIntersectionResults_t.vPoint.v0, vroverlayIntersectionResults_t.vPoint.v1, -vroverlayIntersectionResults_t.vPoint.v2);
				results.normal = new global::UnityEngine.Vector3(vroverlayIntersectionResults_t.vNormal.v0, vroverlayIntersectionResults_t.vNormal.v1, -vroverlayIntersectionResults_t.vNormal.v2);
				results.UVs = new global::UnityEngine.Vector2(vroverlayIntersectionResults_t.vUVs.v0, vroverlayIntersectionResults_t.vUVs.v1);
				results.distance = vroverlayIntersectionResults_t.fDistance;
				result = true;
			}
		}
		return result;
	}

	// Token: 0x04000086 RID: 134
	public global::UnityEngine.Texture texture;

	// Token: 0x04000087 RID: 135
	public bool curved = true;

	// Token: 0x04000088 RID: 136
	public bool antialias = true;

	// Token: 0x04000089 RID: 137
	public bool highquality = true;

	// Token: 0x0400008A RID: 138
	public float scale = 3f;

	// Token: 0x0400008B RID: 139
	public float distance = 1.25f;

	// Token: 0x0400008C RID: 140
	public float alpha = 1f;

	// Token: 0x0400008D RID: 141
	public global::UnityEngine.Vector4 uvOffset = new global::UnityEngine.Vector4(0f, 0f, 1f, 1f);

	// Token: 0x0400008E RID: 142
	public global::UnityEngine.Vector2 mouseScale = new global::UnityEngine.Vector2(1f, 1f);

	// Token: 0x0400008F RID: 143
	public global::UnityEngine.Vector2 curvedRange = new global::UnityEngine.Vector2(1f, 2f);

	// Token: 0x04000090 RID: 144
	public global::Valve.VR.VROverlayInputMethod inputMethod = global::Valve.VR.VROverlayInputMethod.None;

	// Token: 0x04000092 RID: 146
	private ulong handle = 0UL;

	// Token: 0x020000FB RID: 251
	public struct IntersectionResults
	{
		// Token: 0x040006DF RID: 1759
		public global::UnityEngine.Vector3 point;

		// Token: 0x040006E0 RID: 1760
		public global::UnityEngine.Vector3 normal;

		// Token: 0x040006E1 RID: 1761
		public global::UnityEngine.Vector2 UVs;

		// Token: 0x040006E2 RID: 1762
		public float distance;
	}
}
