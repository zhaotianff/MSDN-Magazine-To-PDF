using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDN_Magazine_To_PDF.Model
{
    public class Metadata
    {
        public bool open_to_public_contributors { get; set; }

        public string breadcrumb_path { get; set; }

        public bool extendBreadcrumb { get; set; }

        public string feedback_system { get; set; }

        public string ROBOTS { get; set; }
 
        public bool is_archived { get; set; }

        public string uhfHeaderId { get; set; }
 
        public string author { get; set; }

        /// <summary>
        /// ms.author
        /// </summary>
        [JsonProperty("ms.author")]
        public string ms_author { get; set; }

        /// <summary>
        /// ms.prod
        /// </summary>
        [JsonProperty("ms.prod")]
        public string ms_prod { get; set; }

        /// <summary>
        /// ms.topic
        /// </summary>
        [JsonProperty("ms.topic")]
        public string ms_topic { get; set; }
    }

    public class ChildrenItem
    {

        public string href { get; set; }

        public string toc_title { get; set; }
    }

    public class Children
    {
        public string toc_title { get; set; }

        public List<ChildrenItem> children { get; set; }
    }

    public class Items
    {
        public string href { get; set; }

        public string toc_title { get; set; }

        public List<Children> children { get; set; }
    }

    public class MagazineRoot
    {
        public Metadata metadata { get; set; }

        public List<Items> items { get; set; }
    }
}
