using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }

        public Task Task { get; set; }
    }
}
