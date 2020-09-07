using System;
using UnityEngine;
using Valve.VR;

// Token: 0x02000019 RID: 25
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class SteamVR_UpdatePoses : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060000F0 RID: 240 RVA: 0x0000A670 File Offset: 0x00008870
	private void Awake()
	{
		global::UnityEngine.Camera component = base.GetComponent<global::UnityEngine.Camera>();
		component.clearFlags = 4;
		component.useOcclusionCulling = false;
		component.cullingMask = 0;
		component.depth = -9999f;
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x0000A6AC File Offset: 0x000088AC
	private void OnPreCull()
	{
		global::Valve.VR.CVRCompositor compositor = global::Valve.VR.OpenVR.Compositor;
		bool flag = compositor != null;
		if (flag)
		{
			global::SteamVR_Render instance = global::SteamVR_Render.instance;
			compositor.GetLastPoses(instance.poses, instance.gamePoses);
			global::SteamVR_Utils.Event.Send("new_poses", new object[]
			{
				instance.poses
			});
			global::SteamVR_Utils.Event.Send("new_poses_applied", global::System.Array.Empty<object>());
		}
	}
}
