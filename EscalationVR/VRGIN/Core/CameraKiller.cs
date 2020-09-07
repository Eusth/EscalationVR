using System;
using System.Linq;
using UnityEngine;
using VRGIN.Helpers;

namespace VRGIN.Core
{
	// Token: 0x020000AC RID: 172
	public class CameraKiller : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x06000348 RID: 840 RVA: 0x00011AD8 File Offset: 0x0000FCD8
		protected override void OnStart()
		{
			base.OnStart();
			this._CameraEffects = global::System.Linq.Enumerable.ToArray<global::UnityEngine.MonoBehaviour>(base.gameObject.GetCameraEffects());
			this._Camera = base.GetComponent<global::UnityEngine.Camera>();
			this._Camera.cullingMask = 0;
			this._Camera.depth = -9999f;
			this._Camera.useOcclusionCulling = false;
			this._Camera.clearFlags = 4;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00011B47 File Offset: 0x0000FD47
		public void OnPreCull()
		{
			this._Camera.enabled = false;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00011B58 File Offset: 0x0000FD58
		public void OnGUI()
		{
			bool flag = global::UnityEngine.Event.current.type == 7;
			if (flag)
			{
				this._Camera.enabled = true;
			}
		}

		// Token: 0x04000575 RID: 1397
		private global::UnityEngine.MonoBehaviour[] _CameraEffects = new global::UnityEngine.MonoBehaviour[0];

		// Token: 0x04000576 RID: 1398
		private global::UnityEngine.Camera _Camera;
	}
}
