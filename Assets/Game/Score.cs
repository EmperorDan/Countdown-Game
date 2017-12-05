namespace Game
{
    public class Score
    {
        private float _value;

        public float Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        public void Increment(float amount = 1)
        {
            _value+=amount;
        }

        public void Decrement(float amount = 1)
        {
           _value-=amount;
        }
    }
}
