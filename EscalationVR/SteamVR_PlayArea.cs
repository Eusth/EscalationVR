using System;
using System.Collections;
using UnityEngine;
using Valve.VR;

// Token: 0x02000011 RID: 17
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshRenderer), typeof(global::UnityEngine.MeshFilter))]
public class SteamVR_PlayArea : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060000A1 RID: 161 RVA: 0x00007990 File Offset: 0x00005B90
	public static bool GetBounds(global::SteamVR_PlayArea.Size size, ref global::Valve.VR.HmdQuad_t pRect)
	{
		bool flag = size == global::SteamVR_PlayArea.Size.Calibrated;
		bool result;
		if (flag)
		{
			bool flag2 = !global::SteamVR.active && !global::SteamVR.usingNativeSupport;
			bool flag3 = flag2;
			if (flag3)
			{
				global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
				global::Valve.VR.OpenVR.Init(ref evrinitError, global::Valve.VR.EVRApplicationType.VRApplication_Other);
			}
			global::Valve.VR.CVRChaperone chaperone = global::Valve.VR.OpenVR.Chaperone;
			bool flag4 = chaperone != null && chaperone.GetPlayAreaRect(ref pRect);
			bool flag5 = !flag4;
			if (flag5)
			{
				global::UnityEngine.Debug.LogWarning("Failed to get Calibrated Play Area bounds!  Make sure you have tracking first, and that your space is calibrated.");
			}
			bool flag6 = flag2;
			if (flag6)
			{
				global::Valve.VR.OpenVR.Shutdown();
			}
			result = flag4;
		}
		else
		{
			try
			{
				string text = size.ToString().Substring(1);
				string[] array = text.Split(new char[]
				{
					'x'
				}, 2);
				float num = float.Parse(array[0]) / 200f;
				float num2 = float.Parse(array[1]) / 200f;
				pRect.vCorners0.v0 = num;
				pRect.vCorners0.v1 = 0f;
				pRect.vCorners0.v2 = num2;
				pRect.vCorners1.v0 = num;
				pRect.vCorners1.v1 = 0f;
				pRect.vCorners1.v2 = -num2;
				pRect.vCorners2.v0 = -num;
				pRect.vCorners2.v1 = 0f;
				pRect.vCorners2.v2 = -num2;
				pRect.vCorners3.v0 = -num;
				pRect.vCorners3.v1 = 0f;
				pRect.vCorners3.v2 = num2;
				return true;
			}
			catch
			{
			}
			result = false;
		}
		return result;
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00007B2C File Offset: 0x00005D2C
	public void BuildMesh()
	{
		global::Valve.VR.HmdQuad_t hmdQuad_t = default(global::Valve.VR.HmdQuad_t);
		bool flag = !global::SteamVR_PlayArea.GetBounds(this.size, ref hmdQuad_t);
		if (!flag)
		{
			global::Valve.VR.HmdVector3_t[] array = new global::Valve.VR.HmdVector3_t[]
			{
				hmdQuad_t.vCorners0,
				hmdQuad_t.vCorners1,
				hmdQuad_t.vCorners2,
				hmdQuad_t.vCorners3
			};
			this.vertices = new global::UnityEngine.Vector3[array.Length * 2];
			for (int i = 0; i < array.Length; i++)
			{
				global::Valve.VR.HmdVector3_t hmdVector3_t = array[i];
				this.vertices[i] = new global::UnityEngine.Vector3(hmdVector3_t.v0, 0.01f, hmdVector3_t.v2);
			}
			bool flag2 = this.borderThickness == 0f;
			if (flag2)
			{
				base.GetComponent<global::UnityEngine.MeshFilter>().mesh = null;
			}
			else
			{
				for (int j = 0; j < array.Length; j++)
				{
					int num = (j + 1) % array.Length;
					int num2 = (j + array.Length - 1) % array.Length;
					global::UnityEngine.Vector3 normalized = (this.vertices[num] - this.vertices[j]).normalized;
					global::UnityEngine.Vector3 normalized2 = (this.vertices[num2] - this.vertices[j]).normalized;
					global::UnityEngine.Vector3 vector = this.vertices[j];
					vector += global::UnityEngine.Vector3.Cross(normalized, global::UnityEngine.Vector3.up) * this.borderThickness;
					vector += global::UnityEngine.Vector3.Cross(normalized2, global::UnityEngine.Vector3.down) * this.borderThickness;
					this.vertices[array.Length + j] = vector;
				}
				int[] triangles = new int[]
				{
					0,
					1,
					4,
					1,
					5,
					4,
					1,
					2,
					5,
					2,
					6,
					5,
					2,
					3,
					6,
					3,
					7,
					6,
					3,
					0,
					7,
					0,
					4,
					7
				};
				global::UnityEngine.Vector2[] uv = new global::UnityEngine.Vector2[]
				{
					new global::UnityEngine.Vector2(0f, 0f),
					new global::UnityEngine.Vector2(1f, 0f),
					new global::UnityEngine.Vector2(0f, 0f),
					new global::UnityEngine.Vector2(1f, 0f),
					new global::UnityEngine.Vector2(0f, 1f),
					new global::UnityEngine.Vector2(1f, 1f),
					new global::UnityEngine.Vector2(0f, 1f),
					new global::UnityEngine.Vector2(1f, 1f)
				};
				global::UnityEngine.Color[] colors = new global::UnityEngine.Color[]
				{
					this.color,
					this.color,
					this.color,
					this.color,
					new global::UnityEngine.Color(this.color.r, this.color.g, this.color.b, 0f),
					new global::UnityEngine.Color(this.color.r, this.color.g, this.color.b, 0f),
					new global::UnityEngine.Color(this.color.r, this.color.g, this.color.b, 0f),
					new global::UnityEngine.Color(this.color.r, this.color.g, this.color.b, 0f)
				};
				global::UnityEngine.Mesh mesh = new global::UnityEngine.Mesh();
				base.GetComponent<global::UnityEngine.MeshFilter>().mesh = mesh;
				mesh.vertices = this.vertices;
				mesh.uv = uv;
				mesh.colors = colors;
				mesh.triangles = triangles;
				global::UnityEngine.MeshRenderer component = base.GetComponent<global::UnityEngine.MeshRenderer>();
				component.material = global::UnityEngine.Resources.GetBuiltinResource<global::UnityEngine.Material>("Sprites-Default.mat");
				component.reflectionProbeUsage = 0;
				component.shadowCastingMode = 0;
				component.receiveShadows = false;
				component.useLightProbes = false;
			}
		}
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00007F50 File Offset: 0x00006150
	private void OnDrawGizmos()
	{
		bool flag = !this.drawWireframeWhenSelectedOnly;
		if (flag)
		{
			this.DrawWireframe();
		}
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00007F74 File Offset: 0x00006174
	private void OnDrawGizmosSelected()
	{
		bool flag = this.drawWireframeWhenSelectedOnly;
		if (flag)
		{
			this.DrawWireframe();
		}
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00007F94 File Offset: 0x00006194
	public void DrawWireframe()
	{
		bool flag = this.vertices == null || this.vertices.Length == 0;
		if (!flag)
		{
			global::UnityEngine.Vector3 vector = base.transform.TransformVector(global::UnityEngine.Vector3.up * this.wireframeHeight);
			for (int i = 0; i < 4; i++)
			{
				int num = (i + 1) % 4;
				global::UnityEngine.Vector3 vector2 = base.transform.TransformPoint(this.vertices[i]);
				global::UnityEngine.Vector3 vector3 = vector2 + vector;
				global::UnityEngine.Vector3 vector4 = base.transform.TransformPoint(this.vertices[num]);
				global::UnityEngine.Vector3 vector5 = vector4 + vector;
				global::UnityEngine.Gizmos.DrawLine(vector2, vector3);
				global::UnityEngine.Gizmos.DrawLine(vector2, vector4);
				global::UnityEngine.Gizmos.DrawLine(vector3, vector5);
			}
		}
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x0000805C File Offset: 0x0000625C
	public void OnEnable()
	{
		bool isPlaying = global::UnityEngine.Application.isPlaying;
		if (isPlaying)
		{
			base.GetComponent<global::UnityEngine.MeshRenderer>().enabled = this.drawInGame;
			base.enabled = false;
			bool flag = this.drawInGame && this.size == global::SteamVR_PlayArea.Size.Calibrated;
			if (flag)
			{
				base.StartCoroutine("UpdateBounds");
			}
		}
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x000080B3 File Offset: 0x000062B3
	private global::System.Collections.IEnumerator UpdateBounds()
	{
		base.GetComponent<global::UnityEngine.MeshFilter>().mesh = null;
		global::Valve.VR.CVRChaperone chaperone = global::Valve.VR.OpenVR.Chaperone;
		bool flag = chaperone == null;
		if (flag)
		{
			yield break;
		}
		while (chaperone.GetCalibrationState() != global::Valve.VR.ChaperoneCalibrationState.OK)
		{
			yield return null;
		}
		this.BuildMesh();
		yield break;
	}

	// Token: 0x04000093 RID: 147
	public float borderThickness = 0.15f;

	// Token: 0x04000094 RID: 148
	public float wireframeHeight = 2f;

	// Token: 0x04000095 RID: 149
	public bool drawWireframeWhenSelectedOnly = false;

	// Token: 0x04000096 RID: 150
	public bool drawInGame = true;

	// Token: 0x04000097 RID: 151
	public global::SteamVR_PlayArea.Size size;

	// Token: 0x04000098 RID: 152
	public global::UnityEngine.Color color = global::UnityEngine.Color.cyan;

	// Token: 0x04000099 RID: 153
	[global::UnityEngine.HideInInspector]
	public global::UnityEngine.Vector3[] vertices;

	// Token: 0x020000FC RID: 252
	public enum Size
	{
		// Token: 0x040006E4 RID: 1764
		Calibrated,
		// Token: 0x040006E5 RID: 1765
		_400x300,
		// Token: 0x040006E6 RID: 1766
		_300x225,
		// Token: 0x040006E7 RID: 1767
		_200x150
	}
}
