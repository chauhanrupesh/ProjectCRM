﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;

namespace Microsoft.Dynamics365.UIAutomation.Api.UCI
{
    public class Dashboard : Element
    {
        private readonly WebClient _client;

        public SubGrid SubGrid => this.GetElement<SubGrid>(_client);

        public Dashboard(WebClient client)
        {
            _client = client;
        }

        public T GetElement<T>(WebClient client)
            where T : Element
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { client });
        }

        /// <summary>
        /// Selects the Dashboard provided
        /// </summary>
        /// <param name="dashboardName">Name of the dashboard to select</param>
        public void SelectDashboard(string dashboardName)
        {
            _client.SelectDashboard(dashboardName);
        }
    }
}
