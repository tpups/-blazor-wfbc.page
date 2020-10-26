﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wfbc.page.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace wfbc.page.Client.Pages
{
    public class CommishDataModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        protected List<Manager> manList = new List<Manager>();
        protected Manager man = new Manager();

        protected override async Task OnInitializedAsync()
        {
            await GetManagers();
        }
        protected async Task GetManagers()
        {
            manList = await Http.GetFromJsonAsync<List<Manager>>("api/Manager");
        }
        protected void DeleteConfirm(string ID)
        {
            man = manList.FirstOrDefault(x => x.Id == ID);
        }
        protected async Task DeleteManager(string manID)
        {
            await Http.DeleteAsync("api/Manager/" + manID);
            await GetManagers();
        }
    }
}
