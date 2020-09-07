using System;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000A4 RID: 164
	public class PlayArea
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000311 RID: 785 RVA: 0x00011476 File Offset: 0x0000F676
		// (set) Token: 0x06000312 RID: 786 RVA: 0x0001147E File Offset: 0x0000F67E
		public float Scale { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000313 RID: 787 RVA: 0x00011487 File Offset: 0x0000F687
		// (set) Token: 0x06000314 RID: 788 RVA: 0x0001148F File Offset: 0x0000F68F
		public global::UnityEngine.Vector3 Position { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00011498 File Offset: 0x0000F698
		// (set) Token: 0x06000316 RID: 790 RVA: 0x000114A0 File Offset: 0x0000F6A0
		public float Rotation { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000317 RID: 791 RVA: 0x000114AC File Offset: 0x0000F6AC
		// (set) Token: 0x06000318 RID: 792 RVA: 0x000114C9 File Offset: 0x0000F6C9
		public float Height
		{
			get
			{
				return this.Position.y;
			}
			set
			{
				this.Position = new global::UnityEngine.Vector3(this.Position.x, value, this.Position.z);
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000114EF File Offset: 0x0000F6EF
		public PlayArea()
		{
			this.Scale = 1f;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00011508 File Offset: 0x0000F708
		public void Apply()
		{
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(0f, this.Rotation, 0f);
			global::SteamVR_Camera steamCam = global::VRGIN.Core.VR.Camera.SteamCam;
			steamCam.origin.position = this.Position - quaternion * new global::UnityEngine.Vector3(steamCam.head.transform.localPosition.x, 0f, steamCam.head.transform.localPosition.z) * this.Scale;
			steamCam.origin.rotation = quaternion;
			global::VRGIN.Core.VR.Settings.IPDScale = this.Scale;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000115B4 File Offset: 0x0000F7B4
		public void Reset()
		{
			this.Position = new global::UnityEngine.Vector3(global::VRGIN.Core.VR.Camera.Head.position.x, global::VRGIN.Core.VR.Camera.Origin.position.y, global::VRGIN.Core.VR.Camera.Head.position.z);
			this.Scale = global::VRGIN.Core.VR.Settings.IPDScale;
			this.Rotation = global::VRGIN.Core.VR.Camera.Origin.rotation.eulerAngles.y;
		}
	}
}
