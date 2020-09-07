using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using SpeechTransport;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Controls.Speech
{
	// Token: 0x020000C6 RID: 198
	public class SpeechManager : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000493 RID: 1171 RVA: 0x00017728 File Offset: 0x00015928
		// (remove) Token: 0x06000494 RID: 1172 RVA: 0x00017760 File Offset: 0x00015960
		[global::System.Diagnostics.DebuggerBrowsable(0)]
		public event global::System.EventHandler<global::VRGIN.Controls.Speech.SpeechRecognizedEventArgs> SpeechRecognized = delegate(object <p0>, global::VRGIN.Controls.Speech.SpeechRecognizedEventArgs <p1>)
		{
		};

		// Token: 0x06000495 RID: 1173 RVA: 0x00017795 File Offset: 0x00015995
		protected override void OnStart()
		{
			base.OnStart();
			this.InitializeDictionary();
			this.StartServer();
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x000177B0 File Offset: 0x000159B0
		private void StartServer()
		{
			this._ServerPath = global::UnityEngine.Application.dataPath + "/../Plugins/VR/SpeechServer.exe";
			bool flag = !global::System.IO.File.Exists(this._ServerPath);
			if (flag)
			{
				global::VRGIN.Core.VRLog.Error("Could not find SpeechServer at {0}", new object[]
				{
					this._ServerPath
				});
				base.enabled = false;
			}
			else
			{
				global::System.IO.FileInfo fileInfo = new global::System.IO.FileInfo(this._ServerPath);
				bool flag2 = global::VRGIN.Controls.Speech.SpeechManager.server == null;
				if (flag2)
				{
					global::VRGIN.Core.VRLog.Info(fileInfo.FullName, global::System.Array.Empty<object>());
					global::VRGIN.Controls.Speech.SpeechManager.server = new global::System.Diagnostics.Process();
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.FileName = fileInfo.FullName;
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.UseShellExecute = false;
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.CreateNoWindow = true;
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.Arguments = string.Format("--words \"{0}\" --locale {1}", this.GetVoiceCommands(), global::VRGIN.Core.VR.Settings.Locale);
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.RedirectStandardOutput = true;
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.RedirectStandardError = true;
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.RedirectStandardInput = true;
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.StandardOutputEncoding = global::System.Text.Encoding.UTF8;
					global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.StandardErrorEncoding = global::System.Text.Encoding.UTF8;
					global::VRGIN.Controls.Speech.SpeechManager.server.OutputDataReceived += new global::System.Diagnostics.DataReceivedEventHandler(this.OnOutputReceived);
					global::VRGIN.Controls.Speech.SpeechManager.server.ErrorDataReceived += new global::System.Diagnostics.DataReceivedEventHandler(this.OnErrorReceived);
					global::VRGIN.Core.VRLog.Info("Starting speech server: {0}", new object[]
					{
						global::VRGIN.Controls.Speech.SpeechManager.server.StartInfo.Arguments
					});
					global::VRGIN.Controls.Speech.SpeechManager.server.Start();
					global::VRGIN.Controls.Speech.SpeechManager.server.BeginOutputReadLine();
					global::VRGIN.Controls.Speech.SpeechManager.server.BeginErrorReadLine();
					global::VRGIN.Core.VRLog.Info("Started!", global::System.Array.Empty<object>());
				}
			}
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00017986 File Offset: 0x00015B86
		private void OnErrorReceived(object sender, global::System.Diagnostics.DataReceivedEventArgs e)
		{
			global::VRGIN.Core.VRLog.Error(e.Data, global::System.Array.Empty<object>());
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001799C File Offset: 0x00015B9C
		private void InitializeDictionary()
		{
			string text = this.CombinePath(new string[]
			{
				global::UnityEngine.Application.dataPath,
				"..",
				"UserData\\dictionaries",
				global::VRGIN.Core.VR.Settings.Locale + ".txt"
			});
			global::VRGIN.Controls.Speech.DictionaryReader dictionaryReader = new global::VRGIN.Controls.Speech.DictionaryReader(global::VRGIN.Core.VR.Context.VoiceCommandType);
			global::VRGIN.Core.VRLog.Info("Loading dictionary at {0}...", new object[]
			{
				text
			});
			dictionaryReader.LoadDictionary(text);
			global::VRGIN.Core.VRLog.Info("Saving dictionary at {0}...", new object[]
			{
				text
			});
			dictionaryReader.SaveDictionary(text);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00017A30 File Offset: 0x00015C30
		private string CombinePath(params string[] paths)
		{
			string text = paths[0];
			for (int i = 1; i < paths.Length; i++)
			{
				text = global::System.IO.Path.Combine(text, paths[i]);
			}
			return text;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00017A68 File Offset: 0x00015C68
		private void OnOutputReceived(object sender, global::System.Diagnostics.DataReceivedEventArgs e)
		{
			try
			{
				object @lock = this.LOCK;
				lock (@lock)
				{
					this.result = new global::SpeechTransport.SpeechResult?(global::SpeechTransport.SpeechResult.Deserialize(e.Data));
					global::VRGIN.Core.VRLog.Info("RECEIVED MESSAGE: " + e.Data, global::System.Array.Empty<object>());
				}
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Error(obj);
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00017AF4 File Offset: 0x00015CF4
		private string GetVoiceCommands()
		{
			return string.Join(";", global::System.Linq.Enumerable.ToArray<string>(global::System.Linq.Enumerable.SelectMany<global::VRGIN.Controls.Speech.VoiceCommand, string>(global::VRGIN.Controls.Speech.DictionaryReader.ExtractCommandObjects(global::VRGIN.Core.VR.Context.VoiceCommandType), (global::VRGIN.Controls.Speech.VoiceCommand command) => command.Texts)));
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00017B48 File Offset: 0x00015D48
		private void OnDisable()
		{
			bool flag = this.receiveThread != null;
			if (flag)
			{
				this.receiveThread.Abort();
				this.receiveThread = null;
			}
			this.client.Close();
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00017B84 File Offset: 0x00015D84
		protected override void OnUpdate()
		{
			object @lock = this.LOCK;
			lock (@lock)
			{
				bool flag2 = this.result != null;
				if (flag2)
				{
					base.SendMessage("OnSpeech", this.result.Value);
					this.SpeechRecognized.Invoke(this, new global::VRGIN.Controls.Speech.SpeechRecognizedEventArgs(this.result.Value));
					this.result = default(global::SpeechTransport.SpeechResult?);
				}
			}
		}

		// Token: 0x04000629 RID: 1577
		private global::System.Threading.Thread receiveThread;

		// Token: 0x0400062A RID: 1578
		private global::System.Net.Sockets.UdpClient client;

		// Token: 0x0400062B RID: 1579
		private global::SpeechTransport.SpeechResult? result;

		// Token: 0x0400062C RID: 1580
		private const string LOCALHOST = "127.0.0.1";

		// Token: 0x0400062D RID: 1581
		private const string CAMEL_CASE_REGEX = "(\\B[A-Z]+?(?=[A-Z][^A-Z])|\\B[A-Z]+?(?=[^A-Z]))";

		// Token: 0x0400062E RID: 1582
		private const string DICT_PATH = "UserData\\dictionaries";

		// Token: 0x0400062F RID: 1583
		private string _ServerPath;

		// Token: 0x04000630 RID: 1584
		private object LOCK = new object();

		// Token: 0x04000631 RID: 1585
		private static global::System.Diagnostics.Process server;
	}
}
