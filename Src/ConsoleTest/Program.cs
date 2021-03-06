﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class Program
    {
        private static readonly HttpClient HttpClient = new HttpClient {BaseAddress = new Uri("https://www.baidu.com")};

        private static void Main(string[] args)
        {
            ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);
            Console.WriteLine($"init: workerThreads: {workerThreads} completionPortThreads: {completionPortThreads}");
            ThreadPool.SetMinThreads(2, 200);
            ThreadPool.SetMaxThreads(5, 200);
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine($"current: workerThreads: {workerThreads} completionPortThreads: {completionPortThreads}");

            var batch = 10;
            var tasks = new List<Task<string>>();
            for (var i = 0; i < batch; i++)
            {
                tasks.Add(Task.Run(DoIOTaskAsync));
            }

            int j = 0;
            foreach (var task in tasks)
            {
                var result = task.Result;
                Console.WriteLine($"{result} {j++}");
            }

            Console.ReadLine();
        }

        private static async Task<string> DoTaskAsync()
        {
            ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);
            Console.WriteLine($"DoTaskAsync enter: workerThreads: {workerThreads} completionPortThreads: {completionPortThreads}");
            await Task.Delay(200);
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine($"DoTaskAsync leave: workerThreads: {workerThreads} completionPortThreads: {completionPortThreads}");
            return "DoTaskAsync done";
        }

        private static async Task<string> DoIOTaskAsync()
        {
            //ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);
            //Console.WriteLine($"DoIOTaskAsync enter: workerThreads: {workerThreads} completionPortThreads: {completionPortThreads}");
            var result = await HttpClient.GetAsync($"api/command?wd={DateTime.Now.ToShortDateString()}");

            //ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            //Console.WriteLine($"DoIOTaskAsync: workerThreads: {workerThreads} completionPortThreads: {completionPortThreads}");

            var ret = await result.Content
                                  .ReadAsStringAsync();
            //ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            //Console.WriteLine($"DoIOTaskAsync leave: workerThreads: {workerThreads} completionPortThreads: {completionPortThreads}");
            return "DoIOTaskAsync done";
        }
    }
}