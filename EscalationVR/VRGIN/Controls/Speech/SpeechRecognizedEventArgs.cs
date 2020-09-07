using System;
using SpeechTransport;

namespace VRGIN.Controls.Speech
{
	// Token: 0x020000C5 RID: 197
	public class SpeechRecognizedEventArgs : global::System.EventArgs
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x00017705 File Offset: 0x00015905
		// (set) Token: 0x06000491 RID: 1169 RVA: 0x0001770D File Offset: 0x0001590D
		public global::SpeechTransport.SpeechResult Result { get; private set; }

		// Token: 0x06000492 RID: 1170 RVA: 0x00017716 File Offset: 0x00015916
		public SpeechRecognizedEventArgs(global::SpeechTransport.SpeechResult result)
		{
			this.Result = result;
		}
	}
}
