using System;
using EscalationVR;
using UnityEngine;

// Token: 0x02000015 RID: 21
[global::UnityEngine.ExecuteInEditMode]
public class SteamVR_SphericalProjection : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060000DC RID: 220 RVA: 0x00009B6C File Offset: 0x00007D6C
	public void Set(global::UnityEngine.Vector3 N, float phi0, float phi1, float theta0, float theta1, global::UnityEngine.Vector3 uAxis, global::UnityEngine.Vector3 uOrigin, float uScale, global::UnityEngine.Vector3 vAxis, global::UnityEngine.Vector3 vOrigin, float vScale)
	{
		bool flag = global::SteamVR_SphericalProjection.material == null;
		if (flag)
		{
			global::SteamVR_SphericalProjection.material = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_SphericalProjection"));
		}
		global::SteamVR_SphericalProjection.material.SetVector("_N", new global::UnityEngine.Vector4(N.x, N.y, N.z));
		global::SteamVR_SphericalProjection.material.SetFloat("_Phi0", phi0 * 0.0174532924f);
		global::SteamVR_SphericalProjection.material.SetFloat("_Phi1", phi1 * 0.0174532924f);
		global::SteamVR_SphericalProjection.material.SetFloat("_Theta0", theta0 * 0.0174532924f + 1.57079637f);
		global::SteamVR_SphericalProjection.material.SetFloat("_Theta1", theta1 * 0.0174532924f + 1.57079637f);
		global::SteamVR_SphericalProjection.material.SetVector("_UAxis", uAxis);
		global::SteamVR_SphericalProjection.material.SetVector("_VAxis", vAxis);
		global::SteamVR_SphericalProjection.material.SetVector("_UOrigin", uOrigin);
		global::SteamVR_SphericalProjection.material.SetVector("_VOrigin", vOrigin);
		global::SteamVR_SphericalProjection.material.SetFloat("_UScale", uScale);
		global::SteamVR_SphericalProjection.material.SetFloat("_VScale", vScale);
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00009CAE File Offset: 0x00007EAE
	private void OnRenderImage(global::UnityEngine.RenderTexture src, global::UnityEngine.RenderTexture dest)
	{
		global::UnityEngine.Graphics.Blit(src, dest, global::SteamVR_SphericalProjection.material);
	}

	// Token: 0x040000BE RID: 190
	private static global::UnityEngine.Material material;
}
