using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FinalDLTools
{
    public class ImageModel
    {
        public BitmapSource ImageBitmap { get; set; }
        public string PathFile { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public int NumofImage { get; set; } = 0;

    }

    public class LabelModel
    {
        public string Color { get; set; }
        public string LabelName { get; set; } = string.Empty;
        public string ShortCut { get; set; } = string.Empty;
        public int NumofSample { get; set; } = 0;

    }

    public class ProjectModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Describe { get; set; }
        public string Method { get; set; }
        public List<LabelModel> Labels { get; set; }
        public List<ImageModel> Images { get; set; }

    }
}
