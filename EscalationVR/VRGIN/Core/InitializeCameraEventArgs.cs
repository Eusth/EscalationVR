using System;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000AA RID: 170
	public class InitializeCameraEventArgs : global::System.EventArgs
	{
		// Token: 0x06000346 RID: 838 RVA: 0x00011AAF File Offset: 0x0000FCAF
		public InitializeCameraEventArgs(global::UnityEngine.Camera camera, global::UnityEngine.Camera blueprint)
		{
			this.Camera = camera;
			this.Blueprint = blueprint;
		}

		// Token: 0x04000572 RID: 1394
		public readonly global::UnityEngine.Camera Camera;

		// Token: 0x04000573 RID: 1395
		public readonly global::UnityEngine.Camera Blueprint;
	}
}
