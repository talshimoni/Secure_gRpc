﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecureGrpc.Server.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ServerGrpcSubscribers _serverGrpcSubscribers;

        public IndexModel(ServerGrpcSubscribers serverGrpcSubscribers)
        {
            _serverGrpcSubscribers = serverGrpcSubscribers;
        }

        public void OnGet()
        {

        }

        public async Task OnPostAsync(string message)
        {
            await _serverGrpcSubscribers.BroadcastMessageAsync(
              new Duplex.MyMessage { Message = message, Name = "Server" });
        }
    }
}
