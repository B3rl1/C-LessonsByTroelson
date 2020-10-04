using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASyns
{
	class Program
	{
		static void Main(string[] args)
		{
			/*int nWorkerThreads;
			int nCompletionThreads;
			ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionThreads);
			Console.WriteLine("Максимальное количество потоков: " + nWorkerThreads
				+ "\nПотоков ввода-вывода доступно: " + nCompletionThreads);

			for (int i = 0; i < 5; i++)
				ThreadPool.QueueUserWorkItem(JobForAThread);
			Thread.Sleep(3000);
			Console.ReadLine();*/

			new Thread(new ThreadStart(() => { Console.WriteLine($"MyThread is {Thread.CurrentThread.IsThreadPoolThread}"); })).Start();
			
			var result = SetSomething();
			var result1 = SetSomething();

			

			for(int i = 0; i < 5; i++)
			{ Thread.Sleep(1000); Console.WriteLine(Thread.CurrentThread.ManagedThreadId); }

			Console.WriteLine(result.Result + " " + result1.Result);
		}

		static async Task<string> SetSomething()
		{
			return await Task.Run(() =>
			{
				for (int i = 0; i < 5; i++)
				{
					Thread.Sleep(1000);
					Console.WriteLine("Async " + Thread.CurrentThread.ManagedThreadId + " " + Thread.CurrentThread.IsThreadPoolThread);
				}
				return Thread.CurrentThread.ManagedThreadId.ToString();
			});
			
		}

		static void JobForAThread(object state)
		{
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1} {2}",
					i, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
				Thread.Sleep(50);
			}
		}
	}
}
