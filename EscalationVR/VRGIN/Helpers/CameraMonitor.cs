using System;
using System.Diagnostics;
using VRGIN.Core;

namespace VRGIN.Helpers
{
	// Token: 0x020000D4 RID: 212
	public class CameraMonitor : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x06000545 RID: 1349 RVA: 0x0001A9A0 File Offset: 0x00018BA0
		public void OnPreCull()
		{
			this._Stopwatch.Reset();
			this._Stopwatch.Start();
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001A9BC File Offset: 0x00018BBC
		public void OnPreRender()
		{
			this._Stopwatch.Stop();
			global::VRGIN.Core.VRLog.Info("{0}: Cull {1}ms", new object[]
			{
				base.gameObject.name,
				this._Stopwatch.Elapsed.TotalMilliseconds
			});
			this._Stopwatch.Reset();
			this._Stopwatch.Start();
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001AA28 File Offset: 0x00018C28
		public void OnPostRender()
		{
			this._Stopwatch.Stop();
			global::VRGIN.Core.VRLog.Info("{0}: Render {1}ms", new object[]
			{
				base.gameObject.name,
				this._Stopwatch.Elapsed.TotalMilliseconds
			});
		}

		// Token: 0x0400065E RID: 1630
		private global::System.Diagnostics.Stopwatch _Stopwatch = new global::System.Diagnostics.Stopwatch();
	}
}
