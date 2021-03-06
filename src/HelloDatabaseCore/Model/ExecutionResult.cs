﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDatabaseCore.Model
{
    public class ExecutionResult
    {
        public int Id { get; set; }
        public DateTime? RunTime { get; set; }
        public TimeSpan? RunDuration { get; set; }
        public string StandardOutput { get; set; }
        public string ErrorOutput { get; set; }
        public Exception Exception { get; set; }
        public string OsDescription { get; set; }
    }
}
