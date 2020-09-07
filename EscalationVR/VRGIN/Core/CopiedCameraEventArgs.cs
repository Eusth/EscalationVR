using System;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000AB RID: 171
	public class CopiedCameraEventArgs : global::System.EventArgs
	{
		// Token: 0x06000347 RID: 839 RVA: 0x00011AC7 File Offset: 0x0000FCC7
		public CopiedCameraEventArgs(global::UnityEngine.Camera camera)
		{
			this.Camera = camera;
		}

		// Token: 0x04000574 RID: 1396
		public readonly global::UnityEngine.Camera Camera;
	}
}
