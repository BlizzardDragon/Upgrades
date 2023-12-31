namespace AI.Iterators
{
    public sealed class YoyoIterator<T> : Iterator<T>
    {
        public bool Forward { get; set; }

        public YoyoIterator(T[] items) : base(items)
        {
        }

        public override bool MoveNext()
        {
            if (this.Forward)
            {
                if (this.pointer + 1 < this.movePoints.Length)
                {
                    this.pointer++;
                }
                else
                {
                    this.Forward = false;
                    this.pointer--;
                }
            }
            else
            {
                if (this.pointer - 1 >= 0)
                {
                    this.pointer--;
                }
                else
                {
                    this.Forward = true;
                    this.pointer++;
                }
            }

            return true;
        }

        public override void Reset()
        {
            this.pointer = 0;
            this.Forward = true;
        }

        public override void Dispose()
        {
        }
    }
}