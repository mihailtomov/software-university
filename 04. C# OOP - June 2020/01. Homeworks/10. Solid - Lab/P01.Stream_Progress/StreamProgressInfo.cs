namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStream streamType;

        public StreamProgressInfo(IStream streamType)
        {
            this.streamType = streamType;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamType.BytesSent * 100) / this.streamType.Length;
        }
    }
}
