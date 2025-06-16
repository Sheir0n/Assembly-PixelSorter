using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using CLibrary;
using System.Runtime.CompilerServices;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Collections.Concurrent;
using System.IO;


namespace JA_PixelSorter
{
	public partial class SorterWindow : Form
	{
		[DllImport(@"..\..\..\..\..\JA PixelSorter\x64\Debug\JAAsm.dll")]
		//static extern int AsmSort(float min, float max, int option, int pxheight, HSLColor[] tab);
		static extern void AsmSort(float min, float max, int option, int pxheight, [In, Out] HSLColor[] tab);

		private string imagePath;
		private HSLColor[][] hslMap;
		private bool imageLoaded = false;


		private int threadCount;

		private readonly object _lockVar = new object();

		bool processing = false;

		public SorterWindow()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			threadCount = Environment.ProcessorCount;
			threadSlider.Value = threadCount;
			threadCountTextBox.Text = threadCount.ToString();

			minValueText.Text = "Min: " + minValueBar.Value;
			maxValueText.Text = "Max: " + maxValueBar.Value;

			progressBar.Visible = false;
		}
		//regular methods

		//panel events

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}

		private void imgChoseButton_Click(object sender, EventArgs e)
		{
			dlgOpenFile.FileName = "";
			dlgOpenFile.Filter = "Obrazy (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
			dlgOpenFile.ShowDialog();

			if (!string.IsNullOrEmpty(dlgOpenFile.FileName))
			{
				imageLoaded = false;
				topPictureBox.Image = Image.FromFile(@dlgOpenFile.FileName);
				topPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
				botPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

				imagePath = @dlgOpenFile.FileName;
				hslMap = ConvertImageToHSLMap(imagePath);
				imageLoaded = true;
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			threadCountTextBox.Text = threadSlider.Value.ToString();
		}

		private void threadButton_Click(object sender, EventArgs e)
		{
			threadSlider.Value = threadCount;
			threadCountTextBox.Text = threadCount.ToString();
		}

		private void saveImgBtn_Click(object sender, EventArgs e)
		{
			//if (botPictureBox.Image != null)
			if (botPictureBox.Image != null)
			{
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
					saveFileDialog.Title = "Zapisz obraz";
					saveFileDialog.DefaultExt = "png";

					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						string filePath = saveFileDialog.FileName;
						botPictureBox.Image.Save(filePath);
						MessageBox.Show("Zapisano", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			else
			{
				MessageBox.Show("Brak sortowanego obrazu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void executeButton_Click(object sender, EventArgs e)
		{
			if (topPictureBox.Image == null && imageLoaded)
			{
				MessageBox.Show("Nie wybrano obrazu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (processing)
				return;

			processing = true;
			timeTextbox.Text = "";
			fullTimeTextbox.Text = "";

			HSLColor[][] hslMapCopy = new HSLColor[hslMap.Length][];
			for (int i = 0; i < hslMap.Length; i++)
			{
				hslMapCopy[i] = new HSLColor[hslMap[i].Length];
				Array.Copy(hslMap[i], hslMapCopy[i], hslMap[i].Length);
			}

			Stopwatch sortStopwatch = new Stopwatch();
			Stopwatch fullStopwatch = new Stopwatch();

			progressBar.Value = 0;
			progressBar.Maximum = hslMap.Length;
			progressBar.Visible = true;


			int option = 0;
			if (hueSelect.Checked)
				option = 0;
			if (saturationSelect.Checked)
				option = 1;
			if (lightnessSelect.Checked)
				option = 2;

			var progress = new Progress<int>(value =>
			{
				progressBar.Value = value;
				progressText.Text = value + " / " + progressBar.Maximum + " Lines finished   -   " + ((int)(value*100/progressBar.Maximum)).ToString() + " %";
			});

			if(testCheckBox.Checked)
			{
				Console.WriteLine("Testing libraries");
				await ProgramTesting(option, progress);
				processing = false;
				return;
			}
			else if (libCSelect.Checked)
			{
				Console.WriteLine("Using C# library");
				Action<float, float, int, int, HSLColor[]> sortFunc = CSorter.Sort;

				sortStopwatch.Start();
				fullStopwatch.Start();
				await StartSortMultithreading(sortFunc, hslMapCopy, option, progress, threadSlider.Value);
				sortStopwatch.Stop();
			}
			else
			{
				Console.WriteLine("Using Asm library");
				Action<float, float, int, int, HSLColor[]> sortFunc = AsmSort;

				sortStopwatch.Start();
				fullStopwatch.Start();
				await StartSortMultithreading(sortFunc, hslMapCopy, option, progress, threadSlider.Value);
				sortStopwatch.Stop();
		
				Console.WriteLine("finished asm");
			}

			botPictureBox.Image = ConvertHSLMapToImage(hslMapCopy);
			fullStopwatch.Stop();
			timeTextbox.Text = $"Czas sortowania: {sortStopwatch.Elapsed.TotalMilliseconds} ms";
			fullTimeTextbox.Text = $"Razem z konwersją: {fullStopwatch.Elapsed.TotalMilliseconds} ms";

			progressBar.Visible = false;
			processing = false;
			progressText.Text = "";
		}


		//conversion functions

		private HSLColor[][] ConvertImageToHSLMap(string filename)
		{
			BitmapData bitmapData = null;
			Bitmap bitmap = new Bitmap(filename);
			Console.WriteLine(filename);
			int width = bitmap.Width;
			int height = bitmap.Height;

			HSLColor[][] matrix = new HSLColor[width][];
			try
			{
				bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				IntPtr ptr = bitmapData.Scan0;

				Parallel.For(0, width, x =>
				{
					matrix[x] = new HSLColor[height];

					for (int y = 0; y < height; y++)
					{
						int pixelIndex = (y * bitmapData.Stride) + (x * 4);
						byte blue = Marshal.ReadByte(ptr, pixelIndex);
						byte green = Marshal.ReadByte(ptr, pixelIndex + 1);
						byte red = Marshal.ReadByte(ptr, pixelIndex + 2);
						Color color = Color.FromArgb(red, green, blue);
						matrix[x][y] = new HSLColor(color);
					}
				});
			}
			finally
			{
				if (bitmapData != null)
				{
					bitmap.UnlockBits(bitmapData);
				}
			}

			return matrix;
		}

		private Bitmap ConvertHSLMapToImage(HSLColor[][] matrix)
		{
			int width = matrix.Length;
			int height = matrix[0].Length;

			Bitmap bitmap = new Bitmap(width, height);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			IntPtr ptr = bitmapData.Scan0;


			Parallel.For(0, width, x =>
			{
				for (int y = 0; y < height; y++)
				{		
					int pixelIndex = (y * bitmapData.Stride) + (x * 4);
					Color rgb = matrix[x][y].GetRGB();

					byte red = rgb.R;
					byte green = rgb.G;
					byte blue = rgb.B;

					Marshal.WriteByte(ptr, pixelIndex, blue);     
					Marshal.WriteByte(ptr, pixelIndex + 1, green); 
					Marshal.WriteByte(ptr, pixelIndex + 2, red);   
					Marshal.WriteByte(ptr, pixelIndex + 3, (byte)255); 
				}
			});
			bitmap.UnlockBits(bitmapData);

			return bitmap;
		}

		private void minValueBar_Scroll(object sender, EventArgs e)
		{
			if (maxValueBar.Value <= minValueBar.Value)
			{
				maxValueBar.Value = minValueBar.Value;
				if (hueSelect.Checked)
					maxValueText.Text = "Max: " + maxValueBar.Value;
				else
					maxValueText.Text = "Max: " + maxValueBar.Value + "%";
			}

			if (hueSelect.Checked)
				minValueText.Text = "Min: " + minValueBar.Value;
			else
				minValueText.Text = "Min: " + minValueBar.Value + "%";
		}

		private void maxValueBar_Scroll(object sender, EventArgs e)
		{
			if (minValueBar.Value >= maxValueBar.Value)
			{

				minValueBar.Value = maxValueBar.Value;
				if (hueSelect.Checked)
					minValueText.Text = "Min: " + minValueBar.Value;
				else
					minValueText.Text = "Min: " + minValueBar.Value + "%";
			}

			if (hueSelect.Checked)
				maxValueText.Text = "Max: " + maxValueBar.Value;
			else
				maxValueText.Text = "Max: " + maxValueBar.Value + "%";
		}

		private void hueSelect_CheckedChanged(object sender, EventArgs e)
		{
			minValueBar.Maximum = 360;
			maxValueBar.Maximum = 360;
			minValueBar.Value = 120;
			maxValueBar.Value = 180;

			minValueText.Text = "Min:" + minValueBar.Value;
			maxValueText.Text = "Max:" + maxValueBar.Value;
		}

		private void saturationSelect_CheckedChanged(object sender, EventArgs e)
		{
			minValueBar.Maximum = 100;
			maxValueBar.Maximum = 100;
			minValueBar.Value = 40;
			maxValueBar.Value = 60;

			minValueText.Text = "Min: " + minValueBar.Value + "%";
			maxValueText.Text = "Max: " + maxValueBar.Value + "%";
		}

		private void lightnessSelect_CheckedChanged(object sender, EventArgs e)
		{
			minValueBar.Maximum = 100;
			maxValueBar.Maximum = 100;
			minValueBar.Value = 40;
			maxValueBar.Value = 60;

			minValueText.Text = "Min: " + minValueBar.Value + "%";
			maxValueText.Text = "Max: " + maxValueBar.Value + "%";
		}

		private async Task StartSortMultithreading(Action<float, float, int, int, HSLColor[]> sortFunc, HSLColor[][] map, int option, IProgress<int> progress, int threadCount)
		{
			float min = minValueBar.Value;
			float max = maxValueBar.Value;

			int pixelWidth = map.Length;
			int processedCount = 0;

			object _lockVar = new object();
			Task[] tasks = new Task[threadCount];

			var queue = new ConcurrentQueue<int>();
			for (int i = 0; i < pixelWidth; i++)
			{
				queue.Enqueue(i);
			}

			for (int t = 0; t < threadCount; t++)
			{
				tasks[t] = Task.Run(() =>
				{
					while (!queue.IsEmpty)
					{
						if (queue.TryDequeue(out int currColumn))
						{
							sortFunc(min, max, option, map[currColumn].Length, map[currColumn]);
							int currentProgress = Interlocked.Increment(ref processedCount);
							progress.Report(currentProgress);
						}
					}
				});
			}

			await Task.WhenAll(tasks);
		}


		private async Task ProgramTesting(int option, IProgress<int> progress)
		{
			string folderPath = @"..\..\..\..\Tests";
			if(!Directory.Exists(folderPath))
				Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log");
			File.WriteAllText(filePath, "Test działania programu PixelSorter - Jakub Haberek 2025\n");
			File.AppendAllText(filePath, "========================================================\n");
			File.AppendAllText(filePath, "Obraz: " + imagePath + "\n");
			File.AppendAllText(filePath, "Rozmiar Obrazu: " + hslMap.Length + " x " + hslMap[0].Length + "\n");
			File.AppendAllText(filePath, "Parametr: " + option + " | " + minValueBar.Value + " - " + maxValueBar.Value + "\n");

			Stopwatch testStopwatch = new Stopwatch();
			List<float> times = new List<float>();

			Action<float, float, int, int, HSLColor[]> cSortFunc = CSorter.Sort;
			Action<float, float, int, int, HSLColor[]> asmSortFunc = AsmSort;
			progressBar.Visible = true;

			for (int bit = 1; bit<=64; bit=bit<<1)
			{
				HSLColor[][] hslMapCopyC = new HSLColor[hslMap.Length][];
				HSLColor[][] hslMapCopyAsm = new HSLColor[hslMap.Length][];
				for (int i = 0; i < hslMap.Length; i++)
				{
					hslMapCopyC[i] = new HSLColor[hslMap[i].Length];
					hslMapCopyAsm[i] = new HSLColor[hslMap[i].Length];
					Array.Copy(hslMap[i], hslMapCopyC[i], hslMap[i].Length);
					Array.Copy(hslMap[i], hslMapCopyAsm[i], hslMap[i].Length);
				}

				File.AppendAllText(filePath, "\n");
				File.AppendAllText(filePath, "Pomiar: " + bit + " wątków\n");

				progressBar.Value = 0;
				times.Clear();
				for (int j = 1; j <= 5; j++)
				{
					timeTextbox.Text = "C# test " + j + "/5 - " + bit + " threads used.";
					testStopwatch.Restart();
					await StartSortMultithreading(cSortFunc, hslMapCopyC, option, progress, bit);
					testStopwatch.Stop();
					times.Add((float)testStopwatch.Elapsed.TotalMilliseconds);
				}
				File.AppendAllText(filePath, "C#  " + times.Average() + "ms\n");


				progressBar.Value = 0;
				times.Clear();
				for (int j = 1; j <= 5; j++)
				{
					timeTextbox.Text = "Asm test " + j + "/5 - " + bit + " threads used.";
					testStopwatch.Restart();
					await StartSortMultithreading(asmSortFunc, hslMapCopyAsm, option, progress, bit);
					testStopwatch.Stop();
					times.Add((float)testStopwatch.Elapsed.TotalMilliseconds);
				}
				File.AppendAllText(filePath, "Asm " + times.Average() + "ms\n");

			}
			progressBar.Visible = false;
			timeTextbox.Text = "Testing results saved.";
			progressText.Text = "";
		}
	}
}
