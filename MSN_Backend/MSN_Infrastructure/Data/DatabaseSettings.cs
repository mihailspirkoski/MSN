using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Infrastructure.Data
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string MusicRecordCollectionName { get; set; }

        public string MSNUserCollectionName { get; set; }
        public string ForumPostCollectionName { get; set; }
    }
}
