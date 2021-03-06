﻿using System;
using System.IO;
using StuffOnHarold.Interfaces;
using StuffOnHarold.iOS.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileAssistant))]
namespace StuffOnHarold.iOS.Implementations {
	public class FileAssistant : IHelpWithFiles {
		string _documentsPath = "";

		public FileAssistant() {
			_documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		}

		public void DeleteFile(string fileName) {
			File.Delete(GetFullPath(fileName));
		}

		public bool DoesFileExist(string fileName) {
			return File.Exists(GetFullPath(fileName));
		}

		public byte[] GetFile(string fileName) {
			return File.ReadAllBytes(GetFullPath(fileName));
		}

		public void SaveFile(string fileName, byte[] data) {
			File.WriteAllBytes(GetFullPath(fileName), data);
		}

		public string GetFullPath(string fileName){
			return Path.Combine(_documentsPath, fileName);
		}

		public Stream GetFileStream(string fileName) {
			return File.OpenRead(GetFullPath(fileName));
		}
	}
}
