using System;
using UnityEngine;
using Valve.VR;

// Token: 0x02000014 RID: 20
public class SteamVR_Skybox : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060000D5 RID: 213 RVA: 0x0000990C File Offset: 0x00007B0C
	public void SetTextureByIndex(int i, global::UnityEngine.Texture t)
	{
		switch (i)
		{
		case 0:
			this.front = t;
			break;
		case 1:
			this.back = t;
			break;
		case 2:
			this.left = t;
			break;
		case 3:
			this.right = t;
			break;
		case 4:
			this.top = t;
			break;
		case 5:
			this.bottom = t;
			break;
		}
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00009974 File Offset: 0x00007B74
	public global::UnityEngine.Texture GetTextureByIndex(int i)
	{
		global::UnityEngine.Texture result;
		switch (i)
		{
		case 0:
			result = this.front;
			break;
		case 1:
			result = this.back;
			break;
		case 2:
			result = this.left;
			break;
		case 3:
			result = this.right;
			break;
		case 4:
			result = this.top;
			break;
		case 5:
			result = this.bottom;
			break;
		default:
			result = null;
			break;
		}
		return result;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x000099E4 File Offset: 0x00007BE4
	public static void SetOverride(global::UnityEngine.Texture front = null, global::UnityEngine.Texture back = null, global::UnityEngine.Texture left = null, global::UnityEngine.Texture right = null, global::UnityEngine.Texture top = null, global::UnityEngine.Texture bottom = null)
	{
		global::Valve.VR.CVRCompositor compositor = global::Valve.VR.OpenVR.Compositor;
		bool flag = compositor != null;
		if (flag)
		{
			global::UnityEngine.Texture[] array = new global::UnityEngine.Texture[]
			{
				front,
				back,
				left,
				right,
				top,
				bottom
			};
			global::Valve.VR.Texture_t[] array2 = new global::Valve.VR.Texture_t[6];
			for (int i = 0; i < 6; i++)
			{
				array2[i].handle = ((array[i] != null) ? array[i].GetNativeTexturePtr() : global::System.IntPtr.Zero);
				array2[i].eType = global::SteamVR.instance.graphicsAPI;
				array2[i].eColorSpace = global::Valve.VR.EColorSpace.Auto;
			}
			global::Valve.VR.EVRCompositorError evrcompositorError = compositor.SetSkyboxOverride(array2);
			bool flag2 = evrcompositorError > global::Valve.VR.EVRCompositorError.None;
			if (flag2)
			{
				global::UnityEngine.Debug.LogError("Failed to set skybox override with error: " + evrcompositorError.ToString());
				bool flag3 = evrcompositorError == global::Valve.VR.EVRCompositorError.TextureIsOnWrongDevice;
				if (flag3)
				{
					global::UnityEngine.Debug.Log("Set your graphics driver to use the same video card as the headset is plugged into for Unity.");
				}
				else
				{
					bool flag4 = evrcompositorError == global::Valve.VR.EVRCompositorError.TextureUsesUnsupportedFormat;
					if (flag4)
					{
						global::UnityEngine.Debug.Log("Ensure skybox textures are not compressed and have no mipmaps.");
					}
				}
			}
		}
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00009AF8 File Offset: 0x00007CF8
	public static void ClearOverride()
	{
		global::Valve.VR.CVRCompositor compositor = global::Valve.VR.OpenVR.Compositor;
		bool flag = compositor != null;
		if (flag)
		{
			compositor.ClearSkyboxOverride();
		}
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00009B1B File Offset: 0x00007D1B
	private void OnEnable()
	{
		global::SteamVR_Skybox.SetOverride(this.front, this.back, this.left, this.right, this.top, this.bottom);
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00009B48 File Offset: 0x00007D48
	private void OnDisable()
	{
		global::SteamVR_Skybox.ClearOverride();
	}

	// Token: 0x040000B6 RID: 182
	public global::UnityEngine.Texture front;

	// Token: 0x040000B7 RID: 183
	public global::UnityEngine.Texture back;

	// Token: 0x040000B8 RID: 184
	public global::UnityEngine.Texture left;

	// Token: 0x040000B9 RID: 185
	public global::UnityEngine.Texture right;

	// Token: 0x040000BA RID: 186
	public global::UnityEngine.Texture top;

	// Token: 0x040000BB RID: 187
	public global::UnityEngine.Texture bottom;

	// Token: 0x040000BC RID: 188
	public global::SteamVR_Skybox.CellSize StereoCellSize = global::SteamVR_Skybox.CellSize.x32;

	// Token: 0x040000BD RID: 189
	public float StereoIpdMm = 64f;

	// Token: 0x02000103 RID: 259
	public enum CellSize
	{
		// Token: 0x0400071A RID: 1818
		x1024,
		// Token: 0x0400071B RID: 1819
		x64,
		// Token: 0x0400071C RID: 1820
		x32,
		// Token: 0x0400071D RID: 1821
		x16,
		// Token: 0x0400071E RID: 1822
		x8
	}
}
