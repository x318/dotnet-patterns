using System.Reflection.Metadata;

namespace lab2
{
    public class Lazyinitialization
    {
        private Blob? _blob = null;

        public Blob BlobData
        {
            get => _blob ??= new Blob();
        }
    }
}
