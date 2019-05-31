using DlibDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_dlibdotnet
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "photo.jpg");

			using (var faceDetector = Dlib.GetFrontalFaceDetector())
			using (var img = Dlib.LoadImage<RgbPixel>(path))
			{
				Dlib.PyramidUp(img);

				var detectedFaces = faceDetector.Operator(img);

				Console.WriteLine($"Detected Faces: { detectedFaces.Count() }");

				Console.ReadKey();
			}
		}
	}
}
