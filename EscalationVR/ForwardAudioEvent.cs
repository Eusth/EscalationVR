using System;
using UnityEngine;

namespace EscalationVR
{
	// Token: 0x020000EB RID: 235
	public class ForwardAudioEvent : global::UnityEngine.MonoBehaviour
	{
		// Token: 0x060005F7 RID: 1527 RVA: 0x0001D114 File Offset: 0x0001B314
		private void OnAudioFilterRead(float[] data, int channels)
		{
			this.AudioFilterRead.Invoke(data, channels);
		}

		// Token: 0x04000695 RID: 1685
		public global::System.Action<float[], int> AudioFilterRead = delegate(float[] floats, int i)
		{
		};
	}
}
