﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using FMUtils.Screenshot;

namespace ProSnap
{
    public class ExtendedScreenshot : ComposedScreenshot
    {
        internal MemoryStream EditedScreenshotPNGImageStream()
        {
            return ComposedScreenshotImage.ToMemoryStream(ImageFormat.Png);
        }

        internal MemoryStream GetEditedScreenshotPNGImageThumbnailStream()
        {
            return ComposedScreenshotThumbnail.ToMemoryStream(ImageFormat.Png);
        }

        public string InternalFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_internalfilename))
                    _internalfilename = Path.Combine(Configuration.LocalPath, "screenshots", Helper.ExpandParameters(Configuration.DefaultFileName, this));

                return _internalfilename;
            }
        }
        string _internalfilename;

        public string SavedFileName { get; set; }
        public bool isFlagged { get; set; }

        public RemoteImage Remote = new RemoteImage();

        public ExtendedScreenshot(IntPtr targetWindow, ScreenshotMethod method = ScreenshotMethod.DWM, bool withSolidGlass = true)
            : base(targetWindow, method, withSolidGlass) { }

        public ExtendedScreenshot(ScreenshotMethod method = ScreenshotMethod.DWM, bool withSolidGlass = true)
            : base(method, withSolidGlass) { }

        public ExtendedScreenshot(Rectangle r)
            : base(r) { }

        public ExtendedScreenshot()
            : base(ScreenshotMethod.DWM, true) { }
    }

    public class RemoteImage
    {
        public string ImageLink { get; set; }
        public string DeleteLink { get; set; }

        public RemoteImage()
        {
        }

        public RemoteImage(string imageLink, string deleteLink)
        {
            this.ImageLink = imageLink;
            this.DeleteLink = deleteLink;
        }
    }
}
