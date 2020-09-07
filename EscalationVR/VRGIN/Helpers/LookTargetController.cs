using System;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Helpers
{
	// Token: 0x020000D9 RID: 217
	public class LookTargetController : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0001B3F2 File Offset: 0x000195F2
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x0001B3FA File Offset: 0x000195FA
		public global::UnityEngine.Transform Target { get; private set; }

		// Token: 0x06000577 RID: 1399 RVA: 0x0001B404 File Offset: 0x00019604
		public static global::VRGIN.Helpers.LookTargetController AttachTo(global::VRGIN.Core.IActor actor, global::UnityEngine.GameObject gameObject)
		{
			return gameObject.AddComponent<global::VRGIN.Helpers.LookTargetController>();
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0001B41E File Offset: 0x0001961E
		protected override void OnAwake()
		{
			base.OnAwake();
			this.CreateTarget();
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0001B42F File Offset: 0x0001962F
		private void CreateTarget()
		{
			this.Target = new global::UnityEngine.GameObject("VRGIN_LookTarget").transform;
			global::UnityEngine.Object.DontDestroyOnLoad(this.Target.gameObject);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0001B45C File Offset: 0x0001965C
		protected override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._RootNode && global::VRGIN.Core.VR.Camera.SteamCam.head.transform;
			if (flag)
			{
				global::UnityEngine.Transform transform = global::VRGIN.Core.VR.Camera.SteamCam.head.transform;
				global::UnityEngine.Vector3 normalized = (transform.position - this._RootNode.position).normalized;
				this.Target.transform.position = transform.position + normalized * this.Offset;
			}
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0001B4FC File Offset: 0x000196FC
		private void OnDestroy()
		{
			global::UnityEngine.Object.Destroy(this.Target.gameObject);
		}

		// Token: 0x04000669 RID: 1641
		private global::UnityEngine.Transform _RootNode;

		// Token: 0x0400066A RID: 1642
		public float Offset = 0.5f;
	}
}
