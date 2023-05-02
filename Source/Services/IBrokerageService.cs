﻿using System;

namespace FastBuild.Dashboard.Services;

internal interface IBrokerageService
{
    string[] WorkerNames { get; }
    string BrokeragePath { get; set; }
    string CoordinatorAddress { get; set; }

    event EventHandler<WorkerListChangedEventArgs> WorkerListChanged;
    event EventHandler WorkerCountChanged;
}