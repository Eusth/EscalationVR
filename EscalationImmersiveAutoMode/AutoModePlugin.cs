using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EscalationVR
{
	// Token: 0x02000002 RID: 2
	[global::BepInEx.BepInPlugin("ch.zomg.escalation.automode", "Escalation immersive auto mode", "1.0.0.0")]
	public class AutoModePlugin : global::BepInEx.BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Start()
		{
			this._jTalkerPath = global::System.IO.Path.Combine(global::System.IO.Path.GetDirectoryName(global::System.Reflection.Assembly.GetExecutingAssembly().Location), "Speech", "JTalker.exe");
			this._speakerProp = typeof(global::WindowManager).GetField("speaker", 36);
			this._messageProp = typeof(global::WindowManager).GetField("str0", 36);
			this._voiceProp = typeof(global::WindowManager).GetField("Vstr", 36);
			this._autoplayingProp = typeof(global::WindowManager).GetField("autoplaying", 36);
			this._autoplayingZProp = typeof(global::WindowManager).GetField("autoplaying_Z", 36);
			this._okuriTime = typeof(global::WindowManager).GetField("okuritime", 36);
			this._messageFlashProp = typeof(global::WindowManager).GetField("message_flash", 36);
			this._messageTurnProp = typeof(global::WindowManager).GetField("message_turn", 36);
			this._hideWindowProp = typeof(global::WindowManager).GetField("window_dis", 36);
			this._messageSpeedProp = typeof(global::WindowManager).GetField("message_speed", 40);
			this._autoSpeedProp = typeof(global::WindowManager).GetField("autospeed", 40);
			this._silence = global::EscalationVR.SilenceClip.Create();
			global::UnityEngine.SceneManagement.SceneManager.activeSceneChanged += delegate(global::UnityEngine.SceneManagement.Scene arg0, global::UnityEngine.SceneManagement.Scene scene)
			{
				this._windowManager = global::UnityEngine.Object.FindObjectOfType<global::WindowManager>();
			};
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000021D4 File Offset: 0x000003D4
		private void Update()
		{
			bool flag = this._windowManager;
			if (flag)
			{
				bool flag2 = !this.IsAutoplaying;
				if (flag2)
				{
					bool wasAutoPlaying = this._wasAutoPlaying;
					if (wasAutoPlaying)
					{
						this._hideWindowProp.SetValue(this._windowManager, false);
					}
					this._wasAutoPlaying = false;
					return;
				}
				this._wasAutoPlaying = true;
				this._hideWindowProp.SetValue(this._windowManager, true);
				string text = this._messageProp.GetValue(this._windowManager) as string;
				bool flag3 = text != this._text;
				if (flag3)
				{
					this._text = text;
					int num = (int)this._speakerProp.GetValue(this._windowManager);
					bool flag4 = num == 99;
					if (flag4)
					{
						this.Speak(text);
						this.IsAutoplayingVoice = true;
					}
					else
					{
						this.AbortSpeak();
					}
					bool flag5 = this._voiceProp.GetValue(this._windowManager) as string == "";
					if (flag5)
					{
						this._messageSpeedProp.SetValue(null, 1000);
						this._autoSpeedProp.SetValue(null, 0f);
					}
				}
			}
			bool flag6 = this._speakProcess != null && this._speakProcess.HasExited;
			if (flag6)
			{
				global::UnityEngine.AudioSource audio_ = global::UnityEngine.Object.FindObjectOfType<global::LipSyncCore>().audio_;
				audio_.loop = false;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002354 File Offset: 0x00000554
		private void Speak(string text)
		{
			this.AbortSpeak();
			this._speakProcess = global::System.Diagnostics.Process.Start(new global::System.Diagnostics.ProcessStartInfo(this._jTalkerPath)
			{
				Arguments = global::EscalationVR.ProcessUtils.EncodeParameterArgument(text, false),
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			});
			global::UnityEngine.AudioSource audio_ = global::UnityEngine.Object.FindObjectOfType<global::LipSyncCore>().audio_;
			audio_.clip = this._silence;
			audio_.loop = true;
			audio_.Play();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000023D0 File Offset: 0x000005D0
		private void AbortSpeak()
		{
			bool flag = this._speakProcess != null;
			if (flag)
			{
				bool flag2 = !this._speakProcess.HasExited;
				if (flag2)
				{
					this._speakProcess.Kill();
				}
				global::UnityEngine.AudioSource audio_ = global::UnityEngine.Object.FindObjectOfType<global::LipSyncCore>().audio_;
				audio_.loop = false;
				this._speakProcess = null;
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002427 File Offset: 0x00000627
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000243F File Offset: 0x0000063F
		private bool IsAutoplaying
		{
			get
			{
				return (bool)this._autoplayingProp.GetValue(this._windowManager);
			}
			set
			{
				this._autoplayingProp.SetValue(this._windowManager, value);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002459 File Offset: 0x00000659
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002471 File Offset: 0x00000671
		private bool IsAutoplayingVoice
		{
			get
			{
				return (bool)this._autoplayingZProp.GetValue(this._windowManager);
			}
			set
			{
				this._autoplayingZProp.SetValue(this._windowManager, value);
			}
		}

		// Token: 0x04000001 RID: 1
		private const int SPEAKER_NARRATION = 99;

		// Token: 0x04000002 RID: 2
		private const int SPEAKER_MAN = 1;

		// Token: 0x04000003 RID: 3
		private string _text;

		// Token: 0x04000004 RID: 4
		private global::System.Diagnostics.Process _speakProcess;

		// Token: 0x04000005 RID: 5
		private bool _resetPosition = false;

		// Token: 0x04000006 RID: 6
		private global::WindowManager _windowManager;

		// Token: 0x04000007 RID: 7
		private global::System.Reflection.FieldInfo _speakerProp;

		// Token: 0x04000008 RID: 8
		private global::System.Reflection.FieldInfo _messageProp;

		// Token: 0x04000009 RID: 9
		private global::System.Reflection.FieldInfo _voiceProp;

		// Token: 0x0400000A RID: 10
		private global::System.Reflection.FieldInfo _autoplayingProp;

		// Token: 0x0400000B RID: 11
		private global::System.Reflection.FieldInfo _autoplayingZProp;

		// Token: 0x0400000C RID: 12
		private global::System.Reflection.FieldInfo _okuriTime;

		// Token: 0x0400000D RID: 13
		private global::System.Reflection.FieldInfo _messageFlashProp;

		// Token: 0x0400000E RID: 14
		private global::System.Reflection.FieldInfo _messageTurnProp;

		// Token: 0x0400000F RID: 15
		private global::System.Reflection.FieldInfo _autoSpeedProp;

		// Token: 0x04000010 RID: 16
		private global::System.Reflection.FieldInfo _messageSpeedProp;

		// Token: 0x04000011 RID: 17
		private global::UnityEngine.AudioClip _silence;

		// Token: 0x04000012 RID: 18
		private string _jTalkerPath;

		// Token: 0x04000013 RID: 19
		private global::System.Reflection.FieldInfo _hideWindowProp;

		// Token: 0x04000014 RID: 20
		private bool _wasAutoPlaying = false;
	}
}
