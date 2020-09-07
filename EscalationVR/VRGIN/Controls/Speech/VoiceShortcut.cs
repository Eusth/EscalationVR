using System;
using SpeechTransport;
using VRGIN.Core;

namespace VRGIN.Controls.Speech
{
	// Token: 0x020000C8 RID: 200
	public class VoiceShortcut : global::VRGIN.Controls.IShortcut, global::System.IDisposable
	{
		// Token: 0x060004A2 RID: 1186 RVA: 0x00017D5C File Offset: 0x00015F5C
		public VoiceShortcut(global::VRGIN.Controls.Speech.VoiceCommand command, global::System.Action action)
		{
			this._Action = action;
			this._Command = command;
			bool flag = global::VRGIN.Core.VR.Speech;
			if (flag)
			{
				global::VRGIN.Core.VR.Speech.SpeechRecognized += new global::System.EventHandler<global::VRGIN.Controls.Speech.SpeechRecognizedEventArgs>(this.OnRecognized);
			}
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00017DB0 File Offset: 0x00015FB0
		private void OnRecognized(object sender, global::VRGIN.Controls.Speech.SpeechRecognizedEventArgs e)
		{
			bool flag = e.Result.ID >= this._MinID;
			if (flag)
			{
				this._LastResult = new global::SpeechTransport.SpeechResult?(e.Result);
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00017DEC File Offset: 0x00015FEC
		public void Dispose()
		{
			bool flag = global::VRGIN.Core.VR.Speech;
			if (flag)
			{
				global::VRGIN.Core.VR.Speech.SpeechRecognized -= new global::System.EventHandler<global::VRGIN.Controls.Speech.SpeechRecognizedEventArgs>(this.OnRecognized);
			}
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00017E24 File Offset: 0x00016024
		public void Evaluate()
		{
			bool flag = this._LastResult != null;
			if (flag)
			{
				bool flag2 = this._Command.Matches(this._LastResult.Value.Text);
				if (flag2)
				{
					bool flag3 = this._LastResult.Value.Confidence > 0.20000000298023224 || this._LastResult.Value.Final;
					if (flag3)
					{
						global::VRGIN.Core.VRLog.Info(this._Command);
						this._Action.Invoke();
						this._MinID = this._LastResult.Value.ID + 1;
					}
				}
			}
			this._LastResult = default(global::SpeechTransport.SpeechResult?);
		}

		// Token: 0x0400063B RID: 1595
		private global::SpeechTransport.SpeechResult? _LastResult;

		// Token: 0x0400063C RID: 1596
		private int _MinID = 0;

		// Token: 0x0400063D RID: 1597
		private global::System.Action _Action;

		// Token: 0x0400063E RID: 1598
		private global::VRGIN.Controls.Speech.VoiceCommand _Command;
	}
}
