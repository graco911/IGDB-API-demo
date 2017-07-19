using System;
using System.Collections.Generic;

namespace Entities
{
    public class GameDetailInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public Videos[] videos { get; set; }
        public Cover cover { get; set; }
    }

    public class Cover
    {
        public string url { get; set; }
        public string cloudinary_id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Videos
    {
        public string name { get; set; }
        public string video_id { get; set; }
    }

}