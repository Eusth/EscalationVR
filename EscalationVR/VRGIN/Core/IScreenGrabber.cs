using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000A6 RID: 166
	public interface IScreenGrabber
	{
		// Token: 0x0600032F RID: 815
		bool Check(global::UnityEngine.Camera camera);

		// Token: 0x06000330 RID: 816
		global::System.Collections.Generic.IEnumerable<global::UnityEngine.RenderTexture> GetTextures();

		// Token: 0x06000331 RID: 817
		void OnAssign(global::UnityEngine.Camera camera);
	}
}
