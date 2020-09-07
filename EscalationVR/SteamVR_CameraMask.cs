using System;
using EscalationVR;
using UnityEngine;
using Valve.VR;

// Token: 0x02000005 RID: 5
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshFilter), typeof(global::UnityEngine.MeshRenderer))]
public class SteamVR_CameraMask : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600004B RID: 75 RVA: 0x00003954 File Offset: 0x00001B54
	private void Awake()
	{
		this.meshFilter = base.GetComponent<global::UnityEngine.MeshFilter>();
		bool flag = global::SteamVR_CameraMask.material == null;
		if (flag)
		{
			global::SteamVR_CameraMask.material = new global::UnityEngine.Material(global::EscalationVR.UnityHelper.GetShader("Custom/SteamVR_HiddenArea"));
		}
		global::UnityEngine.MeshRenderer component = base.GetComponent<global::UnityEngine.MeshRenderer>();
		component.material = global::SteamVR_CameraMask.material;
		component.shadowCastingMode = 0;
		component.receiveShadows = false;
		component.useLightProbes = false;
		component.reflectionProbeUsage = 0;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000039C4 File Offset: 0x00001BC4
	public void Set(global::SteamVR vr, global::Valve.VR.EVREye eye)
	{
		bool flag = global::SteamVR_CameraMask.hiddenAreaMeshes[(int)eye] == null;
		if (flag)
		{
			global::SteamVR_CameraMask.hiddenAreaMeshes[(int)eye] = global::SteamVR_Utils.CreateHiddenAreaMesh(vr.hmd.GetHiddenAreaMesh(eye), vr.textureBounds[(int)eye]);
		}
		this.meshFilter.mesh = global::SteamVR_CameraMask.hiddenAreaMeshes[(int)eye];
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00003A1C File Offset: 0x00001C1C
	public void Clear()
	{
		this.meshFilter.mesh = null;
	}

	// Token: 0x0400001F RID: 31
	private static global::UnityEngine.Material material;

	// Token: 0x04000020 RID: 32
	private static global::UnityEngine.Mesh[] hiddenAreaMeshes = new global::UnityEngine.Mesh[2];

	// Token: 0x04000021 RID: 33
	private global::UnityEngine.MeshFilter meshFilter;
}
