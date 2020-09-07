using System;
using UnityEngine;

namespace EscalationVR
{
	// Token: 0x02000004 RID: 4
	public static class SilenceClip
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000025A8 File Offset: 0x000007A8
		public static global::UnityEngine.AudioClip Create()
		{
			return global::UnityEngine.AudioClip.Create("Silence", 44100, 1, 44100, true, new global::UnityEngine.AudioClip.PCMReaderCallback(global::EscalationVR.SilenceClip.OnAudioRead));
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000025DC File Offset: 0x000007DC
		private static void OnAudioRead(float[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = 0f;
			}
		}
	}
}
