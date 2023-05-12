using System;
using System.Drawing.Imaging;
using System.IO;
using FellowOakDicom;
using FellowOakDicom.Imaging;
using FellowOakDicom.Imaging.Codec;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            new DicomSetupBuilder()
              .RegisterServices(s => s.AddFellowOakDicom().AddTranscoderManager<FellowOakDicom.Imaging.NativeCodec.NativeTranscoderManager>())
              .RegisterServices(s => s.AddFellowOakDicom().AddImageManager<WinFormsImageManager>())
              .SkipValidation()
              .Build();
            DicomImage dicomImage;
            DicomFile dicomFile = DicomFile.Open(@"DICOM\1.dcm");
            dicomImage = new DicomImage(dicomFile.Dataset, 1);
            var image = dicomImage.RenderImage(0);
            image.AsClonedBitmap().Save(@"DICOM\123.jpeg", ImageFormat.Jpeg);
        }
    }
}
