﻿namespace MoneyMCS.Areas.Identity.Data
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }

        public string Category { get; set; }

        public string FilePath { get; set; }

        public string FileType { get; set; }
    }
}
