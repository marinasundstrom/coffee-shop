using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Client
{
    public class BrowserInterop
    {
        private readonly IJSRuntime jSRuntime;

        public BrowserInterop(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task TopFunction()
        {
            await jSRuntime.InvokeAsync<object>("topFunction");
        }
    }
}
